using AutoVin_Code_Challenge.Infrastructure.Contract;
using System;

namespace AutoVin_Code_Challenge.Infrastructure.Entities
{
    public class Transaction : AuditableEntity
    {
        public Guid CustomerAccountId { get; set; }
        public CustomerAccount CustomerAccount { get; set; }
        public Guid TransactionTypeId { get; set; }
        public TransactionType TransactionType { get; set; }
        public double Amount { get; set; }
    }
}
