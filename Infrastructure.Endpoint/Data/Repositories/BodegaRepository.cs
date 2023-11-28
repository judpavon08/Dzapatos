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
    public class BodegaRepository : GenericRepository<Bodega>, IBodegaRepository
    {
        public BodegaRepository(ISqlDbConnection sqlDbConnection, ISqlCommandOperationBuilder operationBuilder)
            : base(sqlDbConnection, operationBuilder) { }

        public async Task<List<Bodega>> GetAsync()
        {
            DataTable dataTable = await GetDataTableAsync();
            return dataTable.AsEnumerable()
                .Select(MapEntityFromDataRow)
                .ToList();
        }

        public async Task<Bodega> GetByIdAsync(int id)
        {
            DataTable dataTable = await GetDataTableByIdAsync(id);
            return dataTable.AsEnumerable()
                .Select(MapEntityFromDataRow)
                .FirstOrDefault();
        }

        private Bodega MapEntityFromDataRow(DataRow row)
        {
            Bodega bodega = new Bodega
            {
                ID_BODEGA = sqlDbConnection.GetDataRowValue<int>(row, "ID_BODEGA"),
                NOMBRE_BODEGA = sqlDbConnection.GetDataRowValue<string>(row, "NOMBRE_BODEGA"),
                ID_PRODUCTO = sqlDbConnection.GetDataRowValue<string>(row, "ID_PRODUCTO"),
                DIRECCION = sqlDbConnection.GetDataRowValue<string>(row, "DIRECCION")
            };

            return bodega;
        }
    }
}