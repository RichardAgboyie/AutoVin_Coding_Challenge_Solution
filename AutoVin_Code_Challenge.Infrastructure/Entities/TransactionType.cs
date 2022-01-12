using AutoVin_Code_Challenge.Infrastructure.Contract;
using System.ComponentModel.DataAnnotations;

namespace AutoVin_Code_Challenge.Infrastructure.Entities
{
    public class TransactionType : AuditableEntity
    {
        [Required]
        [MaxLength(10)]
        public string Name { get; set; }
    }
}
