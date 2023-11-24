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
    public class MarcaRepository : GenericRepository<Marca>, IMarcaRepository
    {
        public MarcaRepository(ISqlDbConnection sqlDbConnection, ISqlCommandOperationBuilder operationBuilder)
            : base(sqlDbConnection, operationBuilder) { }

        public async Task<List<Marca>> GetAsync()
        {
            DataTable dataTable = await GetDataTableAsync();
            return dataTable.AsEnumerable()
                .Select(MapEntityFromDataRow)
                .ToList();
        }

        public async Task<Marca> GetByIdAsync(int id)
        {
            DataTable dataTable = await GetDataTableByIdAsync(id);
            return dataTable.AsEnumerable()
                .Select(MapEntityFromDataRow)
                .FirstOrDefault();
        }

        private Marca MapEntityFromDataRow(DataRow row)
        {
            Marca marca = new Marca
            {
                ID_MARCA = sqlDbConnection.GetDataRowValue<int>(row, "ID_MARCA"),
                estado = sqlDbConnection.GetDataRowValue<bool>(row, "estado"),
                NOMBRE_MARCA = sqlDbConnection.GetDataRowValue<string>(row, "NOMBRE_MARCA"),
                // Agrega más propiedades de la entidad Marca y mapea los valores desde el DataRow si es necesario.
            };

            return marca;
        }
    }
}