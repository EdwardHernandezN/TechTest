using System;
using System.Collections.Generic;

#nullable disable

namespace TechTest.Models
{
    public partial class OrderDetail
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public double Cuantity { get; set; }
        public byte Status { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastModified { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
