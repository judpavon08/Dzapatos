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
    public class CategoriaController : ApiController
    {
        private readonly ICategoriaService categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            this.categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetCategoria()
        {
            List<Categoria> categoria = await categoriaService.GetAll();
            return Ok(categoria);
        }

        [HttpGet]
        [Route("api/Categoria/{idCategoria}")]
        public async Task<IHttpActionResult> GetCategoriaById(int idCategoria)
        {
            Categoria categoria = await categoriaService.GetByIdAsync(idCategoria);
            return Ok(categoria);
        }

        [HttpPost]
        [ResponseType(typeof(Categoria))]
        public async Task<IHttpActionResult> CreateProveedor(CreateCategoriaDTO categoriaDTO)
        {
            Categoria categoria = await categoriaService.CreateAsync(categoriaDTO);
            var url = Url.Content("~/") + "/api/categoria/" + categoria.ID_CATEGORIA;
            return Created(url, categoria);
        }

        [HttpPut]
        [Route("api/Categoria/{idCategoria}")]
        public async Task<IHttpActionResult> UpdateCategoria(int idCategoria, UpdateCategoriaDTO categoriaDTO)
        {
            Categoria categoria = await categoriaService.UpdateAsync(idCategoria, categoriaDTO);
            return Ok(categoria);
        }

        [HttpDelete]
        [Route("api/Categoria/{idCategoria}")]
        public async Task<IHttpActionResult> DeleteCategoria(int idCategoria)
        {
            try
            {
                await categoriaService.DeleteAsync(idCategoria);
                return Ok($"Categoria con ID {idCategoria} eliminada exitosamente.");
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
