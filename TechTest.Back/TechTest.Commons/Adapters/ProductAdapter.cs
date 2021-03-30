using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTest.Commons.Helpers;
using TechTest.Models;

namespace TechTest.Commons.Adapters
{
    public class ProductAdapter : IRepositoryDb<Product>
    {
        /// <summary>
        /// Contexto de Base de datos
        /// </summary>
        private readonly TechTestOrdersContext _context;
        /// <summary>
        /// LoggerFactory de la clase
        /// </summary>
        private readonly ILoggerFactory _loggerFactory;

        public ProductAdapter(ILoggerFactory loggerFactory, TechTestOrdersContext context)
        {
            _context = context;
            _loggerFactory = loggerFactory;
        }

        public Product add(Product entity)
        {
            try
            {
                _context.Products.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new InfrastructureException(_loggerFactory, "Error insertando objeto.", e);
            }
            return entity;
        }

        public void delete(Guid id)
        {
            Product entity = findById(id).FirstOrDefault();
            entity.Status = 0;
            entity.LastModified = DateTime.Now;
            update(id, entity);
        }

        public IEnumerable<Product> findAll()
        {
            return _context.Products.Where(s => s.Status == 1).ToList();
        }

        public IEnumerable<Product> findById(Guid id)
        {
            return _context.Products.AsNoTracking().Where(s => s.Id == id && s.Status == 1).ToList();
        }

        public IEnumerable<Product> findByParameters(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product update(Guid id, Product entity)
        {
            try
            {
                _context.Products.Update(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Products.Any(e => e.Id == id))
                {
                    throw new InfrastructureException(_loggerFactory, "No encontrado id=" + id);
                }
                else
                {
                    throw;
                }
            }
            catch (Exception e)
            {
                throw new InfrastructureException(_loggerFactory, "Error actualizando objeto", e);
            }
            return entity;
        }
    }
}
