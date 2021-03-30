using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTest.Entities
{
    public class OrderResponse
    {
        public OrderResponse()
        {
            OrderDetails = new HashSet<OrderDetailResponse>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public Guid? OrderStatus { get; set; }
        public Guid? OrderPriority { get; set; }
        public Guid ClientId { get; set; }
        public byte Status { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastModified { get; set; }

        public virtual ClientResponse Client { get; set; }
        public virtual TypesResponse OrderPriorityNavigation { get; set; }
        public virtual TypesResponse OrderStatusNavigation { get; set; }
        public virtual ICollection<OrderDetailResponse> OrderDetails { get; set; }
    }
}
