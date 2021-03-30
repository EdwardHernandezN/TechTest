using System;
using System.Collections.Generic;
using TechTest.Commons.Entities.ProductDTO;
#nullable disable

namespace TechTest.Models
{
    public partial class Product : ProductResponse
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
