using Microsoft.EntityFrameworkCore;
using Stable.Business.Abstract.Processes;
using Stable.Business.Concrete.Helpers;
using Stable.Business.Concrete.Requests;
using Stable.Business.Concrete.Responses.BuyingCurrencyDto;
using Stable.Entity.Concrete;
using Stable.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stable.Business.Concrete.Processes
{
    public class BuyingCurrencyProcess : IBuyingCurrencyProcess
    {
        private readonly IUnitOfWork _unitOfWork;
        public BuyingCurrencyProcess(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BuyingCurrencyDto> ExecuteAsync(BuyingCurrencyRequest buyingCurrencyRequest, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetQuery()
                .Include(u => u.Accounts).AsNoTracking().FirstOrDefaultAsync(u => u.Id == buyingCurrencyRequest.UserId && u.Accounts.Any(a => a.Status == Core.Enums.AccountStatus.Active));

            if (user == null)
            {
                throw new Exception("Bu kullanıcı sistemde kayıtlı değildir.");
            }

            var balanceIds = user.Accounts.Select(a => a.BalanceId).ToList();

            var sourceBalance = await _unitOfWork.Balances.GetAsync(x => x.CurrencyType.Name == buyingCurrencyRequest.SourceCurrency && balanceIds.Contains(x.Id));
            if (sourceBalance == null)
            {
                throw new Exception(buyingCurrencyRequest.SourceCurrency + "Tipinde bir hesabınız bulunmamaktadır.");
            }

            var targetBalance = await _unitOfWork.Balances.GetAsync(x => x.CurrencyType.Name == buyingCurrencyRequest.TargetCurrency && balanceIds.Contains(x.Id));
            if (targetBalance == null)
            {
                throw new Exception(buyingCurrencyRequest.TargetCurrency + "Tipinde bir hesabınız bulunmamaktadır.");
            }

            var sourceRate = 1m;
            var targetRate = 1m;
            var getCurrencyModel = GetCurrencyHelper.GetCurrency(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, true);

            var sourceCurrencyName = getCurrencyModel.Currencies.FirstOrDefault(c => c.Name == buyingCurrencyRequest.SourceCurrency);

            if (sourceCurrencyName != null)
            {
                sourceRate = sourceCurrencyName.ForexBuying;
            }

            var targetCurrencyName = getCurrencyModel.Currencies.FirstOrDefault(c => c.Name.ToLower() == (buyingCurrencyRequest.TargetCurrency.ToLower() == "Dollar".ToLower() ? "ABD DOLARI".ToLower() : buyingCurrencyRequest.TargetCurrency.ToLower()));

            if (targetCurrencyName != null)
            {
                targetRate = targetCurrencyName.ForexSelling;
            }

            if (sourceBalance.Amount < buyingCurrencyRequest.Amount)
            {
                throw new Exception("Bakiyeniz yetersizdir.");
            }

            sourceBalance.Amount -= buyingCurrencyRequest.Amount;
            targetBalance.Amount += buyingCurrencyRequest.Amount * (sourceRate / targetRate);

            var transaction = new Transaction()
            {
                Description = Decimal.Round(buyingCurrencyRequest.Amount * (sourceRate / targetRate), 2) + " " + targetCurrencyName.Name + " alım işleminiz gercekleşmiştir. " +
                sourceCurrencyName?.Name ?? "TL" + " hesabınızdan " + Decimal.Round(buyingCurrencyRequest.Amount, 2) + " düşülmüştür.",
                AccountId = user.Accounts.First(a => a.BalanceId == sourceBalance.Id).Id,
            };

            await _unitOfWork.Transactions.CreateAsync(transaction);
            await _unitOfWork.SaveAsync();

            return new BuyingCurrencyDto()
            {
                Message = Decimal.Round(buyingCurrencyRequest.Amount * (sourceRate / targetRate), 2) + " " + targetCurrencyName.Name + " alım işleminiz gercekleşmiştir. " +
                sourceCurrencyName?.Name ?? "TL" + " hesabınızdan " + Decimal.Round(buyingCurrencyRequest.Amount, 2) + " düşülmüştür.",
            };
        }
    }
}
