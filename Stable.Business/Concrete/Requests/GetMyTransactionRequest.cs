namespace Stable.Business.Concrete.Requests
{
    public class GetMyTransactionRequest
    {
        public long UserId { get; set; }
        public long AccountId { get; set; }
    }
}
