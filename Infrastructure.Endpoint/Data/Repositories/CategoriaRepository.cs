using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Repositories;
using Infrastructure.Endpoint.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Endpoint.Data.Repositories
{
    public class CategoriaRepository : GenericRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ISqlDbConnection sqlDbConnection, ISqlCommandOperationBuilder operationBuilder)
            : base(sqlDbConnection, operationBuilder) { }

        public async Task<List<Categoria>> GetAsync()
        {
            DataTable dataTable = await GetDataTableAsync();
            return dataTable.AsEnumerable()
                .Select(MapEntityFromDataRow)
                .ToList();
        }

        public async Task<Categoria> GetByIdAsync(int id)
        {
            DataTable dataTable = await GetDataTableByIdAsync(id);
            return dataTable.AsEnumerable()
                .Select(MapEntityFromDataRow)
                .FirstOrDefault();
        }

        private Categoria MapEntityFromDataRow(DataRow row)
        {
            Categoria categoria = new Categoria
            {
                ID_CATEGORIA = sqlDbConnection.GetDataRowValue<int>(row, "ID_CATEGORIA"),
                Estado = sqlDbConnection.GetDataRowValue<bool>(row, "Estado"),
                Descripcion = sqlDbConnection.GetDataRowValue<string>(row, "Descripcion"),
                Nombre_Categoria = sqlDbConnection.GetDataRowValue<string>(row, "Nombre_Categoria"),
                Nombre = sqlDbConnection.GetDataRowValue<string>(row, "Nombre"),
                FechaIngreso = sqlDbConnection.GetDataRowValue<DateTime>(row, "FechaIngreso")
            };

            return categoria;
        }
    }
}