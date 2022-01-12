using System;

namespace AutoVin_Code_Challenge.Infrastructure.Contract
{
    public abstract class AuditableEntity : IAuditableEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
