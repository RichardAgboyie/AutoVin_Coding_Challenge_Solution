using AutoVin_Code_Challenge.Infrastructure.Contract;
using System;
using System.ComponentModel.DataAnnotations;

namespace AutoVin_Code_Challenge.Infrastructure.Entities
{
    public class Customer : AuditableEntity
    {          
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }
        [MaxLength(50)]
        public string OtherName { get; set; }
        public Guid BankId { get; set; }
        public Bank Bank { get; set; }
    }
}
