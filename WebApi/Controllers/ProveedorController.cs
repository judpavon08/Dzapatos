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
    public class ProveedorController : ApiController
    {
        private readonly IProveedorService proveedorService;

        public ProveedorController(IProveedorService proveedorService)
        {
            this.proveedorService = proveedorService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetProveedor()
        {
            List<Proveedor> proveedor = await proveedorService.GetAll();
            return Ok(proveedor);
        }

        [HttpGet]
        [Route("api/Proveedor/{idProveedor}")]
        public async Task<IHttpActionResult> GetProveedorById(int idProveedor)
        {
            Proveedor proveedor = await proveedorService.GetByIdAsync(idProveedor);
            return Ok(proveedor);
        }

        [HttpPost]
        [ResponseType(typeof(Proveedor))]
        public async Task<IHttpActionResult> CreateProveedor(CreateProveedorDTO proveedorDTO)
        {
            Proveedor proveedor = await proveedorService.CreateAsync(proveedorDTO);
            var url = Url.Content("~/") + "/api/proveedor/" + proveedor.ID_PROVEEDOR;
            return Created(url, proveedor);
        }

        [HttpPut]
        [Route("api/Proveedor/{idProveedor}")]
        public async Task<IHttpActionResult> UpdateProveedor(int idProveedor, UpdateProveedorDTO proveedorDTO)
        {
            Proveedor proveedor = await proveedorService.UpdateAsync(idProveedor, proveedorDTO);
            return Ok(proveedor);
        }

        [HttpDelete]
        [Route("api/Proveedor/{idProveedor}")]
        public async Task<IHttpActionResult> DeleteProveedor(int idProveedor)
        {
            try
            {
                await proveedorService.DeleteAsync(idProveedor);
                return Ok($"Proveedor con ID {idProveedor} eliminado exitosamente.");
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
