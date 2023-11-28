using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface IBodegaService
    {
        Task<List<Bodega>> GetAll();
        //Task<Marca> GetByIdAsync(Guid id);
        Task<Bodega> GetByIdAsync(int id); // Cambiado de Guid a int
        Task<Bodega> CreateAsync(CreateBodegaDTO bodegaDTO);
        //Task<Marca> UpdateAsync(Guid id, UpdateMarcaDTO marcaDTO);
        Task<Bodega> UpdateAsync(int id, UpdateBodegaDTO bodegaDTO);
        //Task<Marca> DeleteAsync(int id);
        Task DeleteAsync(int id);
    }
}
