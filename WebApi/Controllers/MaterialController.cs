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
    public class MaterialController : ApiController
    {
        private readonly IMaterialService materialService;

        public MaterialController(IMaterialService materialService)
        {
            this.materialService = materialService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetMaterial()
        {
            List<Material> material = await materialService.GetAll();
            return Ok(material);
        }

        [HttpGet]
        [Route("api/Material/{idMaterial}")]
        public async Task<IHttpActionResult> GetMaterialById(int idMaterial)
        {
            Material material = await materialService.GetByIdAsync(idMaterial);
            return Ok(material);
        }

        [HttpPost]
        [ResponseType(typeof(Material))]
        public async Task<IHttpActionResult> CreateMaterial(CreateMaterialDTO materialDTO)
        {
            Material material = await materialService.CreateAsync(materialDTO);
            var url = Url.Content("~/") + "/api/material/" + material.ID_MATERIAL;
            return Created(url, material);
        }

        [HttpPut]
        [Route("api/Material/{idMaterial}")]
        public async Task<IHttpActionResult> UpdateMaterial(int idMaterial, UpdateMaterialDTO materialDTO)
        {
            Material material = await materialService.UpdateAsync(idMaterial, materialDTO);
            return Ok(material);
        }

        [HttpDelete]
        [Route("api/Material/{idMaterial}")]
        public async Task<IHttpActionResult> DeleteMaterial(int idMaterial)
        {
            try
            {
                await materialService.DeleteAsync(idMaterial);
                return Ok($"Marca with ID {idMaterial} deleted successfully.");
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
