using System;

namespace Stable.Core.Entities.Abstract
{
    public class EntityBase : IEntity
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }

    }
}
