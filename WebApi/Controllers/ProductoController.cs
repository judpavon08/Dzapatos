using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApi.Controllers
{
    public class ProductoController : ApiController
    {
        private readonly IProductoService productoService;

        public ProductoController(IProductoService productoService)
        {
            this.productoService = productoService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetProducto()
        {
            List<Producto> producto = await productoService.GetAll();
            return Ok(producto);
        }

        [HttpGet]
        [Route("api/Producto/{idProducto}")]
        public async Task<IHttpActionResult> GetProductoById(int idProducto)
        {
            Producto producto = await productoService.GetByIdAsync(idProducto);
            return Ok(producto);
        }

        [HttpPost]
        [ResponseType(typeof(Producto))]
        public async Task<IHttpActionResult> CreateProducto(CreateProductoDTO productoDTO)
        {
            Producto producto = await productoService.CreateAsync(productoDTO);
            var url = Url.Content("~/") + "/api/producto/" + producto.ID_PRODUCTO;
            return Created(url, producto);
        }

        [HttpPut]
        [Route("api/Producto/{idProducto}")]
        public async Task<IHttpActionResult> UpdateProducto(int idProducto, UpdateProductoDTO productoDTO)
        {
            Producto producto = await productoService.UpdateAsync(idProducto, productoDTO);
            return Ok(producto);
        }

        [HttpDelete]
        [Route("api/Producto/{idProducto}")]
        public async Task<IHttpActionResult> DeleteProducto(int idProducto)
        {
            try
            {
                await productoService.DeleteAsync(idProducto);
                return Ok($"Producto con ID {idProducto} eliminado exitosamente.");
            }
            catch (InvalidOperationException ex)
            {
                // Devuelve una respuesta HTTP 404 con un mensaje personalizado
                return Content(HttpStatusCode.NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return InternalServerError(ex);
            }
        }

    }
}
