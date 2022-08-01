﻿using Stable.Business.Abstract.Processes;
using Stable.Business.Concrete.Constants;
using Stable.Business.Concrete.Exceptions;
using Stable.Business.Concrete.Extensions;
using Stable.Business.Concrete.Responses.UserRegisterDto;
using Stable.Business.Requests;
using Stable.Core.Utilities.Results.ComplexTypes.Enums;
using Stable.Entity.Concrete;
using Stable.Repository.Abstract;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stable.Business.Concrete.Processes
{
    public class UserRegisterProcess : IUserRegisterProcess
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserRegisterProcess(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<UserRegisterDto> ExecuteAsync(UserRegisterRequest userRegisterRequest, CancellationToken cancellationToken)
        {
            var isExist = await _unitOfWork.Users.AnyAsync(u => u.Emails.Any(u => u.IsActiveEmailAddress && u.EmailAddress == userRegisterRequest.Email));

            if (isExist)
            {
                throw new RegisteredUserException(ExceptionMessage.UserAlreadyRegistered, "009");
            }

            var user = new User()
            {
                PhoneNumber = userRegisterRequest.PhoneNumber
            };

            var password = new Password()
            {
                PasswordText = userRegisterRequest.Password.Md5Encryption(),
                IsActivePassword = true,
            };

            user.Passwords.Add(password);

            var email = new Email()
            {
                EmailAddress = userRegisterRequest.Email,
                IsActiveEmailAddress = true,
            };

            user.Emails.Add(email);

            var address = new Address()
            {
                AddressText = userRegisterRequest.Address,
                Name = userRegisterRequest.AddressName,
                Postcode = userRegisterRequest.Postcode,
                IsActiveAddress = true,
            };

            user.Addresses.Add(address);

            var account = new Account()
            {
                AccountNumber = Guid.NewGuid().ToString().Substring(0, 34),
                Status = AccountStatus.Active,
                Balance = new Balance()
                {
                    Amount = 0,
                    CurrencyTypeId = userRegisterRequest.CurrencyTypeId
                },

                Name = userRegisterRequest.AccountName,
                AccountTypeId = userRegisterRequest.AccountTypeId,
            };

            user.Accounts.Add(account);

            if (userRegisterRequest.UserType == UserType.Individual)
            {
                var individualUser = new IndividualUser()
                {
                    BirthDate = userRegisterRequest.BirthDate,
                    FirstName = userRegisterRequest.FirstName,
                    LastName = userRegisterRequest.LastName,
                    IdentityNumber = userRegisterRequest.IdentityNumber,
                };
                user.IndividualUser = individualUser;
            }

            else
            {
                var corporateUser = new CorporateUser()
                {
                    Name = userRegisterRequest.CorporateName,
                    TaxNumber = userRegisterRequest.TaxNumber,
                };
                user.CorporateUser = corporateUser;
            }

            await _unitOfWork.Users.CreateAsync(user);
            await _unitOfWork.SaveAsync();

            return new UserRegisterDto() { Message = "Bankamıza kaydınız başarıyla gerçekleşmiştir." };
        }
    }
}
