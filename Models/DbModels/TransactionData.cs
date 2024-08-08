namespace MyAccounting.Api.Models.DbModels
{
    public class TransactionData
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}