using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface IProductoService
    {
        Task<List<Producto>> GetAll();
        //Task<Marca> GetByIdAsync(Guid id);
        Task<Producto> GetByIdAsync(int id); // Cambiado de Guid a int
        Task<Producto> CreateAsync(CreateProductoDTO productoDTO);
        //Task<Marca> UpdateAsync(Guid id, UpdateMarcaDTO marcaDTO);
        Task<Producto> UpdateAsync(int id, UpdateProductoDTO productoDTO);
        //Task<Marca> DeleteAsync(int id);
        Task DeleteAsync(int id);
    }
}
