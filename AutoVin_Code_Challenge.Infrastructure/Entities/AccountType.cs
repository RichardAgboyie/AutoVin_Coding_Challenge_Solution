using AutoVin_Code_Challenge.Infrastructure.Contract;
using System;
using System.ComponentModel.DataAnnotations;

namespace AutoVin_Code_Challenge.Infrastructure.Entities
{
    public class AccountType : AuditableEntity
    {
        public Guid BankId { get; set; }
        public Bank Bank { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
    }
}
