using System;

namespace SingleStore.NET.Domain.Entities
{
    public abstract class AudutableEntity
    {
        public long Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
