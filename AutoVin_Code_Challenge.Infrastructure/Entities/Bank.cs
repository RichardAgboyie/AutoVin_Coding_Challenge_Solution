using AutoVin_Code_Challenge.Infrastructure.Contract;
using System.ComponentModel.DataAnnotations;

namespace AutoVin_Code_Challenge.Infrastructure.Entities
{
    public class Bank : AuditableEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
