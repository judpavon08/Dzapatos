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
    public class TallasRepository : GenericRepository<Tallas>, ITallasRepository
    {
        public TallasRepository(ISqlDbConnection sqlDbConnection, ISqlCommandOperationBuilder operationBuilder)
            : base(sqlDbConnection, operationBuilder) { }

        public async Task<List<Tallas>> GetAsync()
        {
            DataTable dataTable = await GetDataTableAsync();
            return dataTable.AsEnumerable()
                .Select(MapEntityFromDataRow)
                .ToList();
        }

        public async Task<Tallas> GetByIdAsync(int id)
        {
            DataTable dataTable = await GetDataTableByIdAsync(id);
            return dataTable.AsEnumerable()
                .Select(MapEntityFromDataRow)
                .FirstOrDefault();
        }

        private Tallas MapEntityFromDataRow(DataRow row)
        {
            Tallas tallas = new Tallas
            {                
                ID_TALLA = sqlDbConnection.GetDataRowValue<int>(row, "ID_TALLA"),
                NUM_TALLA = sqlDbConnection.GetDataRowValue<string>(row, "NUM_TALLA"),
                // Agrega más propiedades de la entidad Tallas y mapea los valores desde el DataRow si es necesario.
            };

            return tallas;
        }
    }
}
