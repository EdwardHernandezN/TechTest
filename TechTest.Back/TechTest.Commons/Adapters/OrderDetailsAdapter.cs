using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTest.Commons.Helpers;
using TechTest.Models;

namespace TechTest.Commons.Adapters
{
    public class OrderDetailsAdapter : IRepositoryDb<OrderDetail>
    {
        /// <summary>
        /// Contexto de Base de datos
        /// </summary>
        private readonly TechTestOrdersContext _context;
        /// <summary>
        /// LoggerFactory de la clase
        /// </summary>
        private readonly ILoggerFactory _loggerFactory;

        public OrderDetailsAdapter(ILoggerFactory loggerFactory, TechTestOrdersContext context)
        {
            _context = context;
            _loggerFactory = loggerFactory;
        }

        public OrderDetail add(OrderDetail entity)
        {
            try
            {
                _context.OrderDetails.Add(entity);
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
            OrderDetail entity = findById(id).FirstOrDefault();
            entity.Status = 0;
            entity.LastModified = DateTime.Now;
            update(id, entity);
        }

        public IEnumerable<OrderDetail> findAll()
        {
            return _context.OrderDetails.Where(s => s.Status == 1).ToList();
        }

        public IEnumerable<OrderDetail> findById(Guid id)
        {
            return _context.OrderDetails.AsNoTracking().Where(s => s.Id == id && s.Status == 1).ToList();
        }

        public IEnumerable<OrderDetail> findByParameters(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public OrderDetail update(Guid id, OrderDetail entity)
        {
            try
            {
                _context.OrderDetails.Update(entity);
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
