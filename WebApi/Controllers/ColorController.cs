using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using Domain.Endpoint.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApi.Controllers
{
    public class ColorController : ApiController
    {
        private readonly IColorService colorService;

        public ColorController(IColorService colorService)
        {
            this.colorService = colorService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetColor()
        {
            List<Color> color = await colorService.GetAll();
            return Ok(color);
        }

        [HttpGet]
        [Route("api/Color/{idColor}")]
        public async Task<IHttpActionResult> GetColorById(int idColor)
        {
            Color color = await colorService.GetByIdAsync(idColor);
            return Ok(color);
        }

        [HttpPost]
        [ResponseType(typeof(Color))]
        public async Task<IHttpActionResult> CreateColor(CreateColorDTO colorDTO)
        {
            Color color = await colorService.CreateAsync(colorDTO);
            var url = Url.Content("~/") + "/api/color/" + color.ID_COLOR;
            return Created(url, color);
        }

        [HttpPut]
        [Route("api/Color/{idColor}")]
        public async Task<IHttpActionResult> UpdateColor(int idColor, UpdateColorDTO colorDTO)
        {
            Color color = await colorService.UpdateAsync(idColor, colorDTO);
            return Ok(color);
        }

        [HttpDelete]
        [Route("api/Color/{idColor}")]
        public async Task<IHttpActionResult> DeleteColor(int idColor)
        {
            try
            {
                await colorService.DeleteAsync(idColor);
                return Ok($"Color con el ID {idColor} borrado exitosamente.");
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
