using System;
using System.Collections.Generic;

#nullable disable

namespace TechTest.Models
{
    public partial class Client
    {
        public Client()
        {
            Orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DocNumber { get; set; }
        public Guid? Gender { get; set; }
        public byte Status { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastModified { get; set; }

        public virtual TypesDetail GenderNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
