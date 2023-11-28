using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface ICategoriaService
    {
        Task<List<Categoria>> GetAll();
        //Task<Marca> GetByIdAsync(Guid id);
        Task<Categoria> GetByIdAsync(int id); // Cambiado de Guid a int
        Task<Categoria> CreateAsync(CreateCategoriaDTO categoriaDTO);
        //Task<Marca> UpdateAsync(Guid id, UpdateMarcaDTO marcaDTO);
        Task<Categoria> UpdateAsync(int id, UpdateCategoriaDTO categoriaDTO);
        //Task<Marca> DeleteAsync(int id);
        Task DeleteAsync(int id);
    }
}
