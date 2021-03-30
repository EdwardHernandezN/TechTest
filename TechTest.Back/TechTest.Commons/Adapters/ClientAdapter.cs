using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTest.Commons.Helpers;
using TechTest.Models;

namespace TechTest.Commons.Adapters
{
    public class ClientAdapter : IRepositoryDb<Client>
    {
        /// <summary>
        /// Contexto de Base de datos
        /// </summary>
        private readonly TechTestOrdersContext _context;
        /// <summary>
        /// LoggerFactory de la clase
        /// </summary>
        private readonly ILoggerFactory _loggerFactory;

        public ClientAdapter(ILoggerFactory loggerFactory, TechTestOrdersContext context)
        {
            _context = context;
            _loggerFactory = loggerFactory;
        }

        public Client add(Client entity)
        {
            try
            {
                _context.Clients.Add(entity);
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
            Client entity = findById(id).FirstOrDefault();
            entity.Status = 0;
            entity.LastModified = DateTime.Now;
            update(id, entity);
        }

        public IEnumerable<Client> findAll()
        {
            return _context.Clients.Where(s => s.Status == 1).ToList();
        }

        public IEnumerable<Client> findById(Guid id)
        {
            return _context.Clients.AsNoTracking().Where(s => s.Id == id && s.Status == 1).ToList();
        }

        public IEnumerable<Client> findByParameters(Client entity)
        {
            throw new NotImplementedException();
        }

        public Client update(Guid id, Client entity)
        {
            try
            {
                _context.Clients.Update(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Clients.Any(e => e.Id == id))
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
