using AutoVin_Code_Challenge.Infrastructure.Contract;
using System;
using System.ComponentModel.DataAnnotations;

namespace AutoVin_Code_Challenge.Infrastructure.Entities
{
    public class CustomerAccount : AuditableEntity
    {
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Guid AccountTypeId { get; set; }
        public AccountType AccountType { get; set; }
        [Required]
        [MaxLength(12)]
        public string AccountNumber { get; set; }
    }
}
