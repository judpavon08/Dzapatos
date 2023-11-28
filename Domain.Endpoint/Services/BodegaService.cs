using Domain.Endpoint.Interfaces.Repositories;
using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Services
{
    public class BodegaService : IBodegaService
    {
        private readonly IBodegaRepository bodegaRepository;

        public BodegaService(IBodegaRepository bodegaRepository)
        {
            this.bodegaRepository = bodegaRepository;
        }

        public async Task<Bodega> CreateAsync(CreateBodegaDTO bodegaDTO)
        {
            Bodega bodega = new Bodega
            {
                ID_BODEGA = bodegaDTO.ID_BODEGA,
                NOMBRE_BODEGA = bodegaDTO.NOMBRE_BODEGA,
                ID_PRODUCTO = bodegaDTO.ID_PRODUCTO,
                DIRECCION = bodegaDTO.DIRECCION,

            };
            await bodegaRepository.CreateAsync(bodega);

            return bodega;
        }

        public async Task DeleteAsync(int id)
        {
            // Get the existing Marca from the repository
            Bodega dbBodega = await GetByIdAsync(id);

            // Check if the Marca exists
            if (dbBodega == null)
            {
                // Handle the case where the Marca with the given id is not found
                throw new InvalidOperationException($"Bodega con ID {id} no encontrado.");
            }

            // Call the repository to delete the Marca
            await bodegaRepository.DeleteAsync(dbBodega);
        }



        public Task<List<Bodega>> GetAll()
        {
            return bodegaRepository.GetAsync();
        }

        public Task<Bodega> GetByIdAsync(int id) // Cambiado de Guid a int
        {
            return bodegaRepository.GetByIdAsync(id);
        }

        public async Task<Bodega> UpdateAsync(int id, UpdateBodegaDTO bodegaDTO)
        {
            // Get the existing Marca from the repository
            Bodega dbBodega = await GetByIdAsync(id);

            // Check if the Marca exists
            if (dbBodega == null)
            {
                // Handle the case where the Marca with the given id is not found
                throw new InvalidOperationException($"Bodega con ID {id} no encontrado.");
            }

            // Update the properties of the existing Marca with the values from DTO
            dbBodega.NOMBRE_BODEGA = bodegaDTO.NOMBRE_BODEGA;
            dbBodega.ID_PRODUCTO = bodegaDTO.ID_PRODUCTO;
            dbBodega.DIRECCION = bodegaDTO.DIRECCION;

            // Call the repository to update the Marca
            await bodegaRepository.UpdateAsync(dbBodega);

            // Return the updated Marca
            return dbBodega;
        }

    }
}
