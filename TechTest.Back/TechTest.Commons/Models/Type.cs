using System;
using System.Collections.Generic;

#nullable disable

namespace TechTest.Models
{
    public partial class Type
    {
        public Type()
        {
            TypesDetails = new HashSet<TypesDetail>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte Status { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastModified { get; set; }

        public virtual ICollection<TypesDetail> TypesDetails { get; set; }
    }
}
