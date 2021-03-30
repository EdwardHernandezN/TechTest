using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTest.Commons.Helpers;
using TechTest.Models;
using Type = TechTest.Models.Type;

namespace TechTest.Commons.Adapters
{
    public class TypeAdapter : IRepositoryDb<Type>
    {
        /// <summary>
        /// Contexto de Base de datos
        /// </summary>
        private readonly TechTestOrdersContext _context;
        /// <summary>
        /// LoggerFactory de la clase
        /// </summary>
        private readonly ILoggerFactory _loggerFactory;

        public TypeAdapter(ILoggerFactory loggerFactory, TechTestOrdersContext context)
        {
            _context = context;
            _loggerFactory = loggerFactory;
        }

        public Type add(Type entity)
        {
            try
            {
                _context.Types.Add(entity);
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
            Type entity = findById(id).FirstOrDefault();
            entity.Status = 0;
            entity.LastModified = DateTime.Now;
            update(id, entity);
        }

        public IEnumerable<Type> findAll()
        {
            return _context.Types.Where(s => s.Status == 1).ToList();
        }

        public IEnumerable<Type> findById(Guid id)
        {
            return _context.Types.AsNoTracking().Where(s => s.Id == id && s.Status == 1).ToList();
        }

        public IEnumerable<Type> findByParameters(Type entity)
        {
            throw new NotImplementedException();
        }

        public Type update(Guid id, Type entity)
        {
            try
            {
                _context.Types.Update(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Types.Any(e => e.Id == id))
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
