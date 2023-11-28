using Domain.Endpoint.Interfaces.Repositories;
using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository proveedorRepository;

        public ProveedorService(IProveedorRepository proveedorRepository)
        {
            this.proveedorRepository = proveedorRepository;
        }

        public async Task<Proveedor> CreateAsync(CreateProveedorDTO proveedorDTO)
        {
            Proveedor proveedor = new Proveedor
            {
                ID_PROVEEDOR = proveedorDTO.ID_PROVEEDOR,
               CIUDAD_PROVEEDOR = proveedorDTO.CIUDAD_PROVEEDOR,
               CORREO_ELECTRONICO = proveedorDTO.CORREO_ELECTRONICO,
               NOMBRE_CONTACTO = proveedorDTO.NOMBRE_CONTACTO,
               id_fac_compra = proveedorDTO.id_fac_compra,
               NOMBRE_EMPRESA = proveedorDTO.NOMBRE_EMPRESA,
               Estado = proveedorDTO.Estado,

            };
            await proveedorRepository.CreateAsync(proveedor);

            return proveedor;
        }

        public async Task DeleteAsync(int id)
        {
            // Get the existing Marca from the repository
            Proveedor dbProveedor = await GetByIdAsync(id);

            // Check if the Marca exists
            if (dbProveedor == null)
            {
                // Handle the case where the Marca with the given id is not found
                throw new InvalidOperationException($"Proveedor con ID {id} no encontrado.");
            }

            // Call the repository to delete the Marca
            await proveedorRepository.DeleteAsync(dbProveedor);
        }



        public Task<List<Proveedor>> GetAll()
        {
            return proveedorRepository.GetAsync();
        }

        public Task<Proveedor> GetByIdAsync(int id) // Cambiado de Guid a int
        {
            return proveedorRepository.GetByIdAsync(id);
        }

        public async Task<Proveedor> UpdateAsync(int id, UpdateProveedorDTO proveedorDTO)
        {
            // Get the existing Marca from the repository
            Proveedor dbProveedor = await GetByIdAsync(id);

            // Check if the Marca exists
            if (dbProveedor == null)
            {
                // Handle the case where the Marca with the given id is not found
                throw new InvalidOperationException($"Proveedor con ID {id} no encontrado.");
            }

            // Update the properties of the existing Marca with the values from DTO
            dbProveedor.CIUDAD_PROVEEDOR = proveedorDTO.CIUDAD_PROVEEDOR;
            dbProveedor.CORREO_ELECTRONICO = proveedorDTO.CORREO_ELECTRONICO;
            dbProveedor.NOMBRE_CONTACTO = proveedorDTO.NOMBRE_CONTACTO;
            dbProveedor.id_fac_compra = proveedorDTO.id_fac_compra;
            dbProveedor.NOMBRE_EMPRESA = proveedorDTO.NOMBRE_EMPRESA;
            dbProveedor.Estado = proveedorDTO.Estado;

            // Call the repository to update the Marca
            await proveedorRepository.UpdateAsync(dbProveedor);

            // Return the updated Marca
            return dbProveedor;
        }

    }
}
