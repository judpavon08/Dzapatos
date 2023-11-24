using Domain.Endpoint.Interfaces.Repositories;
using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Services
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository colorRepository;

        public ColorService(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }

        public async Task<Color> CreateAsync(CreateColorDTO colorDTO)
        {
            Color color = new Color
            {
                ID_COLOR = colorDTO.ID_COLOR,                
                NOMBRE_COLOR = colorDTO.NOMBRE_COLOR
            };
            await colorRepository.CreateAsync(color);

            return color;
        }
        

        public async Task DeleteAsync(int id)
        {
            // Get the existing Color from the repository
            Color dbColor = await GetByIdAsync(id);

            // Check if the Color exists
            if (dbColor == null)
            {
                // Handle the case where the Color with the given id is not found
                throw new InvalidOperationException($"Color con ID {id} no fue encontrado.");
            }

            // Call the repository to delete the Color
            await colorRepository.DeleteAsync(dbColor);
        }



        public Task<List<Color>> GetAll()
        {
            return colorRepository.GetAsync();
        }

        public Task<Color> GetByIdAsync(int id) // Cambiado de Guid a int
        {
            return colorRepository.GetByIdAsync(id);
        }

        public async Task<Color> UpdateAsync(int id, UpdateColorDTO colorDTO)
        {
            // Get the existing Marca from the repository
            Color dbColor = await GetByIdAsync(id);

            // Check if the Marca exists
            if (dbColor == null)
            {
                // Handle the case where the Marca with the given id is not found
                throw new InvalidOperationException($"Co with ID {id} not found.");
            }

            // Update the properties of the existing Marca with the values from DTO
            dbColor.NOMBRE_COLOR = colorDTO.NOMBRE_COLOR;

            // Call the repository to update the Marca
            await colorRepository.UpdateAsync(dbColor);

            // Return the updated Marca
            return dbColor;
        }

    }
}
