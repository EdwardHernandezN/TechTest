using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using TechTest.Back.Commons.Utils;
using TechTest.Commons.Adapters;
using TechTest.Commons.Convrters;
using TechTest.Commons.Entities.ProductDTO;
using TechTest.Models;

namespace TechTest.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        /// <summary>
        /// Fábrica para objetos logger
        /// </summary>
        private readonly ILoggerFactory _loggerFactory;
        /// <summary>
        /// Contexto Entidad BD
        /// </summary>
        private readonly TechTestOrdersContext _context;

        /// <summary>
        /// Contrucutor por parámetro del controlador de Instalaciones ECP
        /// </summary>
        /// <param name="loggerFactory">Objeto fábrica logger</param>
        /// <param name="context">Objeto contexto de negocio</param>
        public ProductController(ILoggerFactory loggerFactory, TechTestOrdersContext context)
        {
            _loggerFactory = loggerFactory;
            _context = context;
        }

        //GET: api/product
        [HttpGet]
        public ActionResult<IEnumerable<ProductResponse>> GeProducts()
        {
            try
            {
                IEnumerable<Product> res = new ProductAdapter(_loggerFactory, _context).findAll();
                return new OkObjectResult(ProductConverter.getObjectEntity(res));
            }
            catch (DomainException)
            {
                return new List<ProductResponse>();
            }
        }

        //GET: api/product/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<ProductResponse>> GeProduct(Guid id)
        {
            try
            {
                IEnumerable<Product> res = new ProductAdapter(_loggerFactory, _context).findById(id);
                return new OkObjectResult(ProductConverter.getObjectEntity(res));
            }
            catch (DomainException)
            {
                return NotFound();
            }
        }

        // PUT: api/product/5
        [HttpPut("{id}")]
        public ActionResult<ProductResponse> PutProduct(Guid id, PutProductRequest entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            try
            {
                Product res = new ProductAdapter(_loggerFactory, _context).update(id, ProductConverter.getObjectEntity(entity));
                return new OkObjectResult(ProductConverter.getObjectEntity(res));
            }
            catch (DomainException)
            {
                return NoContent();
            }
        }

        // POPST: api/product/
        [HttpPost]
        public ActionResult<ProductResponse> PostProduct(PostProductRequest entity)
        {
            try
            {
                Product res = new ProductAdapter(_loggerFactory, _context).add(ProductConverter.getObjectEntity(entity));
                return new OkObjectResult(ProductConverter.getObjectEntity(res));
            }
            catch (DomainException)
            {
                return NoContent();
            }
        }
    }
}
