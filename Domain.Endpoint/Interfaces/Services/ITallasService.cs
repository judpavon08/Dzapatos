using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using Domain.Talla.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface ITallasService
    {
        Task<List<Tallas>> GetAll();
        //Task<Marca> GetByIdAsync(Guid id);
        Task<Tallas> GetByIdAsync(int id); // Cambiado de Guid a int
        Task<Tallas> CreateAsync(CreateTallasDto tallaDto);
        //Task<Marca> UpdateAsync(Guid id, UpdateMarcaDTO marcaDTO);
        Task<Tallas> UpdateAsync(int id, UpdateTallasDto tallaDto);
        //Task<Marca> DeleteAsync(int id);
        Task DeleteAsync(int id);
    }
}
