using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTest.Commons.Entities.ProductDTO
{
    public class PutProductRequest : PostProductRequest
    {
        public Guid Id { get; set; }
    }
}
