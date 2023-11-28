using Domain.Endpoint.Interfaces.Repositories;
using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }

        public async Task<Categoria> CreateAsync(CreateCategoriaDTO categoriaDTO)
        {
            Categoria categoria = new Categoria
            {
                ID_CATEGORIA = categoriaDTO.ID_CATEGORIA,
                Estado = categoriaDTO.Estado,
                Descripcion = categoriaDTO.Descripcion,
                Nombre_Categoria = categoriaDTO.Nombre_Categoria,
                Nombre = categoriaDTO.Nombre,
                FechaIngreso = categoriaDTO.FechaIngreso,               
            };
            await categoriaRepository.CreateAsync(categoria);

            return categoria;
        }

        public async Task DeleteAsync(int id)
        {
            // Get the existing Marca from the repository
            Categoria dbCategoria = await GetByIdAsync(id);

            // Check if the Marca exists
            if (dbCategoria == null)
            {
                // Handle the case where the Marca with the given id is not found
                throw new InvalidOperationException($"Categoria con ID {id} no encontrada.");
            }

            // Call the repository to delete the Marca
            await categoriaRepository.DeleteAsync(dbCategoria);
        }



        public Task<List<Categoria>> GetAll()
        {
            return categoriaRepository.GetAsync();
        }

        public Task<Categoria> GetByIdAsync(int id) // Cambiado de Guid a int
        {
            return categoriaRepository.GetByIdAsync(id);
        }

        public async Task<Categoria> UpdateAsync(int id, UpdateCategoriaDTO categoriaDTO)
        {
            // Get the existing Marca from the repository
            Categoria dbCategoria = await GetByIdAsync(id);

            // Check if the Marca exists
            if (dbCategoria == null)
            {
                // Handle the case where the Marca with the given id is not found
                throw new InvalidOperationException($"Categoria con ID {id} no encontrada.");
            }

            // Update the properties of the existing Marca with the values from DTO
            dbCategoria.Estado = categoriaDTO.Estado;
            dbCategoria.Descripcion = categoriaDTO.Descripcion;
            dbCategoria.Nombre_Categoria = categoriaDTO.Nombre_Categoria;
            dbCategoria.Nombre = categoriaDTO.Nombre;
            dbCategoria.FechaIngreso = categoriaDTO.FechaIngreso;

            // Call the repository to update the Marca
            await categoriaRepository.UpdateAsync(dbCategoria);

            // Return the updated Marca
            return dbCategoria;
        }

    }
}
