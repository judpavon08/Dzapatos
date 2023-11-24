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
    public class TallasService : ITallasService
    {
        private readonly ITallasRepository tallasRepository;

        public TallasService(ITallasRepository tallasRepository)
        {
            this.tallasRepository = tallasRepository;
        }

        public async Task<Tallas> CreateAsync(CreateTallasDto tallasDto)
        {
            Tallas talla = new Tallas
            {
                ID_TALLA = tallasDto.ID_TALLA,                
                NUM_TALLA = tallasDto.NUM_TALLA
            };
            await tallasRepository.CreateAsync(talla);

            return talla;
        }        

        public async Task DeleteAsync(int id)
        {
            // Get the existing Marca from the repository
            Tallas dbTalla = await GetByIdAsync(id);

            // Check if the Marca exists
            if (dbTalla == null)
            {
                // Handle the case where the Marca with the given id is not found
                throw new InvalidOperationException($"Marca with ID {id} not found.");
            }

            // Call the repository to delete the Marca
            await tallasRepository.DeleteAsync(dbTalla);
        }



        public Task<List<Tallas>> GetAll()
        {
            return tallasRepository.GetAsync();
        }

        public Task<Tallas> GetByIdAsync(int id) // Cambiado de Guid a int
        {
            return tallasRepository.GetByIdAsync(id);
        }

        public async Task<Tallas> UpdateAsync(int id, UpdateTallasDto tallasDto)
        {
            // Get the existing Marca from the repository
            Tallas dbTalla = await GetByIdAsync(id);

            // Check if the Marca exists
            if (dbTalla == null)
            {
                // Handle the case where the Marca with the given id is not found
                throw new InvalidOperationException($"Marca with ID {id} not found.");
            }

            // Update the properties of the existing Marca with the values from DTO
            dbTalla.NUM_TALLA = tallasDto.NUM_TALLA;

            // Call the repository to update the Marca
            await tallasRepository.UpdateAsync(dbTalla);

            // Return the updated Marca
            return dbTalla;
        }

    }
}
