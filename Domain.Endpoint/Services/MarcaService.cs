using Domain.Endpoint.Interfaces.Repositories;
using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository)
        {
            this.marcaRepository = marcaRepository;
        }

        public async Task<Marca> CreateAsync(CreateMarcaDTO marcaDTO)
        {
            Marca marca = new Marca
            {
                ID_MARCA = marcaDTO.ID_MARCA,
                estado = marcaDTO.estado,
                NOMBRE_MARCA = marcaDTO.NOMBRE_MARCA
            };
            await marcaRepository.CreateAsync(marca);

            return marca;
        }

        public async Task DeleteAsync(int id)
        {
            // Get the existing Marca from the repository
            Marca dbMarca = await GetByIdAsync(id);

            // Check if the Marca exists
            if (dbMarca == null)
            {
                // Handle the case where the Marca with the given id is not found
                throw new InvalidOperationException($"Marca with ID {id} not found.");
            }

            // Call the repository to delete the Marca
            await marcaRepository.DeleteAsync(dbMarca);
        }



        public Task<List<Marca>> GetAll()
        {
            return marcaRepository.GetAsync();
        }

        public Task<Marca> GetByIdAsync(int id) // Cambiado de Guid a int
        {
            return marcaRepository.GetByIdAsync(id);
        }

        //public async Task<Marca> UpdateAsync(int id, UpdateMarcaDTO marcaDTO) // Cambiado de Guid a int
        //{
        //    Marca dbMarca = await GetByIdAsync(id);

        //    Marca marca = new Marca
        //    {
        //        NOMBRE_MARCA = marcaDTO.NOMBRE_MARCA
        //    };

        //    await marcaRepository.UpdateAsync(marca);
        //    return marca;
        //}

        public async Task<Marca> UpdateAsync(int id, UpdateMarcaDTO marcaDTO)
        {
            // Get the existing Marca from the repository
            Marca dbMarca = await GetByIdAsync(id);

            // Check if the Marca exists
            if (dbMarca == null)
            {
                // Handle the case where the Marca with the given id is not found
                throw new InvalidOperationException($"Marca with ID {id} not found.");
            }

            // Update the properties of the existing Marca with the values from DTO
            dbMarca.NOMBRE_MARCA = marcaDTO.NOMBRE_MARCA;

            // Call the repository to update the Marca
            await marcaRepository.UpdateAsync(dbMarca);

            // Return the updated Marca
            return dbMarca;
        }

    }
}
