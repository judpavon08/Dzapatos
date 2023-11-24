using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using Domain.Talla.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface IMaterialService
    {
        Task<List<Material>> GetAll();
        Task<Material> GetByIdAsync(int id);
        Task<Material> CreateAsync(CreateMaterialDTO materialDTO);
        Task<Material> UpdateAsync(int id, UpdateMaterialDTO materialDTO);
        Task<Material> DeleteAsync(int id);
        //Task<Tallas> UpdateAsync(Guid id, UpdateTallasDto tallaDto);
        //Task<Tallas> UpdateAsync(Guid id, UpdateTallasDto tallasDto);
    }
}
