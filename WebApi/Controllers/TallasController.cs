using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using Domain.Talla.DTOs;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApi.Controllers
{
    public class TallaController : ApiController
    {
        private readonly ITallasService tallasService;

        public TallaController(ITallasService tallasService)
        {
            this.tallasService = tallasService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetTalla()
        {
            List<Tallas> tallas = await tallasService.GetAll();
            return Ok(tallas);
        }

        [HttpGet]
        [Route("api/Talla/{idTalla}")]
        public async Task<IHttpActionResult> GetTallaById(int idTalla)
        {
            Tallas tallas = await tallasService.GetByIdAsync(idTalla);
            return Ok(tallas);
        }

        [HttpPost]
        [ResponseType(typeof(Tallas))]
        public async Task<IHttpActionResult> CreateTalla(CreateTallasDto tallasDto)
        {
            Tallas tallas = await tallasService.CreateAsync(tallasDto);
            var url = Url.Content("~/") + "/api/tallas/" + tallas.ID_TALLA;
            return Created(url, tallas);
        }

        [HttpPut]
        [Route("api/talla/{idTalla}")]
        public async Task<IHttpActionResult> UpdateTalla(int idTalla, UpdateTallasDto tallasDto)
        {
            Tallas talla = await tallasService.UpdateAsync(idTalla, tallasDto);
            return Ok(talla);
        }

        [HttpDelete]
        [Route("api/talla/{idTalla}")]
        public async Task<IHttpActionResult> DeleteTalla(int idTalla)
        {
            try
            {
                await tallasService.DeleteAsync(idTalla);
                return Ok($"Marca with ID {idTalla} deleted successfully.");
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
