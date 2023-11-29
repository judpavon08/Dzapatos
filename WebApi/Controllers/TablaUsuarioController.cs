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
    public class TablaUsuarioController : ApiController
    {
        private readonly ITablaUsuarioService tablaUsuarioService;

        public TablaUsuarioController(ITablaUsuarioService tablaUsuarioService)
        {
            this.tablaUsuarioService = tablaUsuarioService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetTablaUsuario()
        {
            List<TablaUsuario> tablaUsuario = await tablaUsuarioService.GetAll();
            return Ok(tablaUsuario);
        }

        [HttpGet]
        [Route("api/TablaUsuario/{idTablaUsuario}")]
        public async Task<IHttpActionResult> GetUsuarioById(int idTablaUsuario)
        {
            TablaUsuario tablaUsuario = await tablaUsuarioService.GetByIdAsync(idTablaUsuario);
            return Ok(tablaUsuario);
        }

        [HttpPost]
        [ResponseType(typeof(TablaUsuario))]
        public async Task<IHttpActionResult> CreateTablaUsuario(CreateTablaUsuarioDTO tablaUsuarioDTO)
        {
            TablaUsuario tablaUsuario = await tablaUsuarioService.CreateAsync(tablaUsuarioDTO);
            var url = Url.Content("~/") + "/api/tablausuario/" + tablaUsuario.ID_USUARIO;
            return Created(url, tablaUsuario);
        }

        [HttpPut]
        [Route("api/TablaUsuario/{idTablaUsuario}")]
        public async Task<IHttpActionResult> UpdateTablaUsuario(int idTablaUsuario, UpdateTablaUsuarioDTO tablaUsuarioDTO)
        {
            TablaUsuario tablaUsuario = await tablaUsuarioService.UpdateAsync(idTablaUsuario, tablaUsuarioDTO);
            return Ok(tablaUsuario);
        }

        [HttpDelete]
        [Route("api/TablaUsuario/{idTabla}")]
        public async Task<IHttpActionResult> DeleteTablaUsuario(int idTablaUsuario)
        {
            try
            {
                await tablaUsuarioService.DeleteAsync(idTablaUsuario);
                return Ok($"Usuario con ID {idTablaUsuario} eliminado exitosamente.");
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
