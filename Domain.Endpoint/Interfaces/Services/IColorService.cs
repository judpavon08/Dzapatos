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
        Task<Color> GetByIdAsync(int id); // Cambiado de Guid a int
        Task<Color> CreateAsync(CreateColorDTO colorDTO);        
        Task<Color> UpdateAsync(int id, UpdateColorDTO colorDTO);
        Task DeleteAsync(int id);
    }
}
