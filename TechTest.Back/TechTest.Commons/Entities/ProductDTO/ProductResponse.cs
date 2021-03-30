using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTest.Commons.Entities.ProductDTO
{
    public class ProductResponse : PutProductRequest
    {
        public DateTime? CreationDate { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
