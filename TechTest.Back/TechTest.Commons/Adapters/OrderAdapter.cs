using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTest.Commons.Helpers;
using TechTest.Models;

namespace TechTest.Commons.Adapters
{
    public class OrderAdapter : IRepositoryDb<Order>
    {
        /// <summary>
        /// Contexto de Base de datos
        /// </summary>
        private readonly TechTestOrdersContext _context;
        /// <summary>
        /// LoggerFactory de la clase
        /// </summary>
        private readonly ILoggerFactory _loggerFactory;

        public OrderAdapter(ILoggerFactory loggerFactory, TechTestOrdersContext context)
        {
            _context = context;
            _loggerFactory = loggerFactory;
        }

        public Order add(Order entity)
        {
            try
            {
                _context.Orders.Add(entity);
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
            Order entity = findById(id).FirstOrDefault();
            entity.Status = 0;
            entity.LastModified = DateTime.Now;
            update(id, entity);
        }

        public IEnumerable<Order> findAll()
        {
            return _context.Orders.Where(s => s.Status == 1).ToList();
        }

        public IEnumerable<Order> findById(Guid id)
        {
            return _context.Orders.AsNoTracking().Where(s => s.Id == id && s.Status == 1).ToList();
        }

        public IEnumerable<Order> findByParameters(Order entity)
        {
            throw new NotImplementedException();
        }

        public Order update(Guid id, Order entity)
        {
            try
            {
                _context.Orders.Update(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Orders.Any(e => e.Id == id))
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
