using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface IMarcaService
    {
        Task<List<Marca>> GetAll();
        //Task<Marca> GetByIdAsync(Guid id);
        Task<Marca> GetByIdAsync(int id); // Cambiado de Guid a int
        Task<Marca> CreateAsync(CreateMarcaDTO marcaDTO);
        //Task<Marca> UpdateAsync(Guid id, UpdateMarcaDTO marcaDTO);
        Task<Marca> UpdateAsync(int id, UpdateMarcaDTO marcaDTO);
        //Task<Marca> DeleteAsync(int id);
        Task DeleteAsync(int id);
    }
}