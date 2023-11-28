using Domain.Endpoint.Interfaces.Repositories;
using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            this.productoRepository = productoRepository;
        }

        public async Task<Producto> CreateAsync(CreateProductoDTO productoDTO)
        {
            Producto producto = new Producto
            {
                ID_PRODUCTO = productoDTO.ID_PRODUCTO,
                descripcion = productoDTO.descripcion,
                NOMBRE_PRODUCTO=productoDTO.NOMBRE_PRODUCTO,
                ID_COLOR= productoDTO.ID_COLOR,
                EXISTENCIA=productoDTO.EXISTENCIA,
                ID_MARCA=productoDTO.ID_MARCA,
                ID_MATERIAL=productoDTO.ID_MATERIAL,
                ID_CATEGORIA=productoDTO.ID_CATEGORIA,
                ID_BODEGA=productoDTO.ID_BODEGA,
                ID_TALLA=productoDTO.ID_TALLA,
                Estado =productoDTO.Estado,
               
            };
            await productoRepository.CreateAsync(producto);

            return producto;
        }

        public async Task DeleteAsync(int id)
        {
            // Get the existing Marca from the repository
            Producto dbProducto = await GetByIdAsync(id);

            // Check if the Marca exists
            if (dbProducto == null)
            {
                // Handle the case where the Marca with the given id is not found
                throw new InvalidOperationException($"Producto con ID {id} no encontrado.");
            }

            // Call the repository to delete the Marca
            await productoRepository.DeleteAsync(dbProducto);
        }



        public Task<List<Producto>> GetAll()
        {
            return productoRepository.GetAsync();
        }

        public Task<Producto> GetByIdAsync(int id) // Cambiado de Guid a int
        {
            return productoRepository.GetByIdAsync(id);
        }

        public async Task<Producto> UpdateAsync(int id, UpdateProductoDTO productoDTO)
        {
            // Get the existing Marca from the repository
            Producto dbProducto = await GetByIdAsync(id);

            // Check if the Marca exists
            if (dbProducto == null)
            {
                // Handle the case where the Marca with the given id is not found
                throw new InvalidOperationException($"Producto con ID {id} no encontrado.");
            }

            // Update the properties of the existing Marca with the values from DTO
            dbProducto.descripcion= productoDTO.descripcion;
            dbProducto.NOMBRE_PRODUCTO = productoDTO.NOMBRE_PRODUCTO;
            dbProducto.ID_COLOR= productoDTO.ID_COLOR;
            dbProducto.EXISTENCIA= productoDTO.EXISTENCIA;
            dbProducto.ID_MARCA= productoDTO.ID_MARCA;
            dbProducto.ID_MATERIAL= productoDTO.ID_MATERIAL;
            dbProducto.ID_CATEGORIA= productoDTO.ID_CATEGORIA;
            dbProducto.ID_BODEGA= productoDTO.ID_BODEGA;
            dbProducto.ID_TALLA= productoDTO.ID_TALLA;
            dbProducto.Estado = productoDTO.Estado;

            // Call the repository to update the Marca
            await productoRepository.UpdateAsync(dbProducto);

            // Return the updated Marca
            return dbProducto;
        }

    }
}
