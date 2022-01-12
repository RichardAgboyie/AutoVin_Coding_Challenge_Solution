using System;

namespace AutoVin_Code_Challenge.Infrastructure.Contract
{
    public interface IAuditableEntity
    {
        DateTime CreatedOn { get; set; }
        DateTime? LastModifiedOn { get; set; }
    }
}
