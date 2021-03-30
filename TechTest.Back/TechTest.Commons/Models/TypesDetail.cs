using System;
using System.Collections.Generic;

#nullable disable

namespace TechTest.Models
{
    public partial class TypesDetail
    {
        public TypesDetail()
        {
            Clients = new HashSet<Client>();
            OrderOrderPriorityNavigations = new HashSet<Order>();
            OrderOrderStatusNavigations = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TypesId { get; set; }
        public byte Status { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastModified { get; set; }

        public virtual Type Types { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Order> OrderOrderPriorityNavigations { get; set; }
        public virtual ICollection<Order> OrderOrderStatusNavigations { get; set; }
    }
}
