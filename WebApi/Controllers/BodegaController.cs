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
    public class BodegaController : ApiController
    {
        private readonly IBodegaService bodegaService;

        public BodegaController(IBodegaService bodegaService)
        {
            this.bodegaService = bodegaService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetBodega()
        {
            List<Bodega> bodega = await bodegaService.GetAll();
            return Ok(bodega);
        }

        [HttpGet]
        [Route("api/Bodega/{idBodega}")]
        public async Task<IHttpActionResult> GetBodegaById(int idBodega)
        {
            Bodega bodega = await bodegaService.GetByIdAsync(idBodega);
            return Ok(bodega);
        }

        [HttpPost]
        [ResponseType(typeof(Bodega))]
        public async Task<IHttpActionResult> CreateBodega(CreateBodegaDTO bodegaDTO)
        {
            Bodega bodega = await bodegaService.CreateAsync(bodegaDTO);
            var url = Url.Content("~/") + "/api/bodega/" + bodega.ID_BODEGA;
            return Created(url, bodega);
        }

        [HttpPut]
        [Route("api/Bodega/{idBodega}")]
        public async Task<IHttpActionResult> UpdateBodega(int idBodega, UpdateBodegaDTO bodegaDTO)
        {
            Bodega bodega = await bodegaService.UpdateAsync(idBodega, bodegaDTO);
            return Ok(bodega);
        }

        [HttpDelete]
        [Route("api/Bodega/{idBodega}")]
        public async Task<IHttpActionResult> DeleteBodega(int idBodega)
        {
            try
            {
                await bodegaService.DeleteAsync(idBodega);
                return Ok($"Bodega con ID {idBodega} eliminado exitosamente.");
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
