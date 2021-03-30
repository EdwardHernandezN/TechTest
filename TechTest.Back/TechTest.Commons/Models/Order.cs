using System;
using System.Collections.Generic;

#nullable disable

namespace TechTest.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public Guid? OrderStatus { get; set; }
        public Guid? OrderPriority { get; set; }
        public Guid ClientId { get; set; }
        public byte Status { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastModified { get; set; }

        public virtual Client Client { get; set; }
        public virtual TypesDetail OrderPriorityNavigation { get; set; }
        public virtual TypesDetail OrderStatusNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
