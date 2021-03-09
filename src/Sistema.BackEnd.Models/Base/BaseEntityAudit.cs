using System;

namespace Sistema.BackEnd.Models.Base
{
    public abstract class BaseEntityAudit : BaseEntity
    {
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
