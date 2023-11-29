using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface ITablaUsuarioService
    {
        Task<List<TablaUsuario>> GetAll();
        //Task<Marca> GetByIdAsync(Guid id);
        Task<TablaUsuario> GetByIdAsync(int id); // Cambiado de Guid a int
        Task<TablaUsuario> CreateAsync(CreateTablaUsuarioDTO tablaUsuarioDTO);
        //Task<Marca> UpdateAsync(Guid id, UpdateMarcaDTO marcaDTO);
        Task<TablaUsuario> UpdateAsync(int id, UpdateTablaUsuarioDTO tablaUsuarioDTO);
        //Task<Marca> DeleteAsync(int id);
        Task DeleteAsync(int id);
    }
}
