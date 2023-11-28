using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface IColorService
    {
        Task<List<Color>> GetAll();
        //Task<Marca> GetByIdAsync(Guid id);
        Task<Color> GetByIdAsync(int id); // Cambiado de Guid a int
        Task<Color> CreateAsync(CreateColorDTO colorDTO);
        //Task<Marca> UpdateAsync(Guid id, UpdateMarcaDTO marcaDTO);
        Task<Color> UpdateAsync(int id, UpdateColorDTO colorDTO);
        //Task<Marca> DeleteAsync(int id);
        Task DeleteAsync(int id);
    }
}
