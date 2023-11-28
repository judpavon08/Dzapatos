using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface IProveedorService
    {
        Task<List<Proveedor>> GetAll();
        //Task<Marca> GetByIdAsync(Guid id);
        Task<Proveedor> GetByIdAsync(int id); // Cambiado de Guid a int
        Task<Proveedor> CreateAsync(CreateProveedorDTO proveedorDTO);
        //Task<Marca> UpdateAsync(Guid id, UpdateMarcaDTO marcaDTO);
        Task<Proveedor> UpdateAsync(int id, UpdateProveedorDTO proveedorDTO);
        //Task<Marca> DeleteAsync(int id);
        Task DeleteAsync(int id);
    }
}
