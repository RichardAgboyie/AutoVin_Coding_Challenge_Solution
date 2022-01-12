using AutoVin_Code_Challenge.Shared.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AutoVin_Code_Challenge.Shared.DTO.Request
{
    public class TransactionRequest
    {
        [Required]
        public Guid CustomerAccountId { get; set; }
        [Required]
        public Guid TransactionTypeId { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public AccountType AccountType { get; set; }
    }
}
