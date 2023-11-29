using Domain.Endpoint.Interfaces.Repositories;
using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Services
{
    public class TablaUsuarioService : ITablaUsuarioService
    {
        private readonly ITablaUsuarioRepository tablaUsuarioRepository;

        public TablaUsuarioService(ITablaUsuarioRepository tablaUsuarioRepository)
        {
            this.tablaUsuarioRepository = tablaUsuarioRepository;
        }

        public async Task<TablaUsuario> CreateAsync(CreateTablaUsuarioDTO tablaUsuarioDTO)
        {
            TablaUsuario tablaUsuario = new TablaUsuario
            {
                ID_USUARIO = tablaUsuarioDTO.ID_USUARIO,
                Nombre_Completo = tablaUsuarioDTO.Nombre_Completo,
                Correo = tablaUsuarioDTO.Correo,
                Telefono = tablaUsuarioDTO.Telefono,
                Estado = tablaUsuarioDTO.Estado,
                Fecha_Creacion = tablaUsuarioDTO.Fecha_Creacion,
            };
            await tablaUsuarioRepository.CreateAsync(tablaUsuario);

            return tablaUsuario;
        }

        public async Task DeleteAsync(int id)
        {
            // Get the existing Marca from the repository
            TablaUsuario dbTablaUsuario = await GetByIdAsync(id);

            // Check if the Marca exists
            if (dbTablaUsuario == null)
            {
                // Handle the case where the Marca with the given id is not found
                throw new InvalidOperationException($"Usuario/a con ID {id} no encontrada.");
            }

            // Call the repository to delete the Marca
            await tablaUsuarioRepository.DeleteAsync(dbTablaUsuario);
        }



        public Task<List<TablaUsuario>> GetAll()
        {
            return tablaUsuarioRepository.GetAsync();
        }

        public Task<TablaUsuario> GetByIdAsync(int id) // Cambiado de Guid a int
        {
            return tablaUsuarioRepository.GetByIdAsync(id);
        }

        public async Task<TablaUsuario> UpdateAsync(int id, UpdateTablaUsuarioDTO tablaUsuarioDTO)
        {
            // Get the existing Marca from the repository
            TablaUsuario dbTablaUsuario = await GetByIdAsync(id);

            // Check if the Marca exists
            if (dbTablaUsuario == null)
            {
                // Handle the case where the Marca with the given id is not found
                throw new InvalidOperationException($"Usuario con ID {id} no encontrada.");
            }

            // actualiza las propiedades del usuario existente con el valor del DTO
            dbTablaUsuario.Nombre_Completo = tablaUsuarioDTO.Nombre_Completo;
            dbTablaUsuario.Correo = tablaUsuarioDTO.Correo;
            dbTablaUsuario.Telefono = tablaUsuarioDTO.Telefono;
            dbTablaUsuario.Estado = tablaUsuarioDTO.Estado;
            dbTablaUsuario.Fecha_Creacion = tablaUsuarioDTO.Fecha_Creacion;
           
            // llama al repo para actualizar el usuario
            await tablaUsuarioRepository.UpdateAsync(dbTablaUsuario);

            // retorna la actualizacion del usuario
            return dbTablaUsuario;
        }

    }
}
