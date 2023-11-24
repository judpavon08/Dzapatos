using Domain.Endpoint.Interfaces.Repositories;
using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Talla.DTOs;

namespace Domain.Endpoint.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository materialRepository;
        public MaterialService(IMaterialRepository materialRepository)
        {
            this.materialRepository = materialRepository;
        }

        public async Task<Material> CreateAsync(CreateMaterialDTO materialDTO)
        {
            Material material = new Material
            {
                //Id = Guid.NewGuid(),
                ID_MATERIAL = materialDTO.ID_MATERIAL,
                estado= materialDTO.estado,
                detalles_material= materialDTO.detalles_material,
                NOMBRE_MATERIAL= materialDTO.NOMBRE_MATERIAL
            };
            await materialRepository.CreateAsync(material);

            return material;
        }

        //public Task<Tallas> CreateAsync(CreateTallasDto tallasDto)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Material> DeleteAsync(int id)
        {
            Material material = await GetByIdAsync(id);
            await materialRepository.DeleteAsync(material);
            return material;
        }

        public Task<List<Material>> GetAll()
        {
            return materialRepository.GetAsync();
        }

        public Task<Material> GetByIdAsync(int id)
        {
            return materialRepository.GetByIdAsync(id);
        }

        //public async Task<Material> UpdateAsync(int id, UpdateMaterialDTO materialDTO)
        //{
        //    Material dbMaterial = await GetByIdAsync(id);

        //    Material material = new Material
        //    {                
        //        estado = materialDTO.estado,
        //        detalles_material = materialDTO.detalles_material,
        //        NOMBRE_MATERIAL = materialDTO.NOMBRE_MATERIAL
        //    };

        //    await materialRepository.UpdateAsync(material);
        //    return material;
        //}

        public async Task<Material> UpdateAsync(int id, UpdateMaterialDTO materialDTO)
        {
            try
            {
                Material dbMaterial = await GetByIdAsync(id);

                if (dbMaterial == null)
                {
                    // Manejar el caso en el que el material no se encuentre
                    throw new InvalidOperationException($"Material with ID {id} not found.");
                }

                // Actualizar las propiedades del material existente con los valores del DTO
                dbMaterial.estado = materialDTO.estado;
                dbMaterial.detalles_material = materialDTO.detalles_material;
                dbMaterial.NOMBRE_MATERIAL = materialDTO.NOMBRE_MATERIAL;

                // Luego, actualiza el material en el repositorio
                await materialRepository.UpdateAsync(dbMaterial);

                return dbMaterial;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw;
            }
        }



    }
}
