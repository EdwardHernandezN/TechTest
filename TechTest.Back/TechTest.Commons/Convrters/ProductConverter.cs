using System;
using System.Collections.Generic;
using TechTest.Commons.Entities.ProductDTO;
using TechTest.Models;

namespace TechTest.Commons.Convrters
{
    public static class ProductConverter
    {
        public static ProductResponse getObjectEntity(Product entity)
        {
            if (entity == null)
            {
                return new ProductResponse();
            }

            return new ProductResponse
            {
                Id = entity.Id,
                Code = entity.Code,
                Name = entity.Name,
                Price = entity.Price,
                Status = entity.Status,
                CreationDate = entity.CreationDate,
                LastModified = entity.LastModified
            };
        }

        public static List<ProductResponse> getObjectEntity(IEnumerable<Product> entities)
        {
            List<ProductResponse> response = new List<ProductResponse>();
            if (entities == null)
            {
                return response;
            }

            foreach (var item in entities)
            {
                response.Add(getObjectEntity(item));
            }
            return response;
        }

        public static Product getObjectEntity(PutProductRequest entity)
        {
            if(entity == null)
            {
                return new Product();
            }

            return new Product 
            {
                Id = entity.Id,
                Code = entity.Code,
                Name = entity.Name,
                Price = entity.Price,
                Status = entity.Status,
                LastModified = DateTime.Now
            };
        }
        public static Product getObjectEntity(PostProductRequest entity)
        {
            if (entity == null)
            {
                return new Product();
            }

            return new Product
            {
                Id = Guid.NewGuid(),
                Code = entity.Code,
                Name = entity.Name,
                Price = entity.Price,
                Status = entity.Status,
                CreationDate = DateTime.Now,
                LastModified = DateTime.Now
            };
        }
    }
}
