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
    public class ProveedorRepository : GenericRepository<Proveedor>, IProveedorRepository
    {
        public ProveedorRepository(ISqlDbConnection sqlDbConnection, ISqlCommandOperationBuilder operationBuilder)
            : base(sqlDbConnection, operationBuilder) { }

        public async Task<List<Proveedor>> GetAsync()
        {
            DataTable dataTable = await GetDataTableAsync();
            return dataTable.AsEnumerable()
                .Select(MapEntityFromDataRow)
                .ToList();
        }

        public async Task<Proveedor> GetByIdAsync(int id)
        {
            DataTable dataTable = await GetDataTableByIdAsync(id);
            return dataTable.AsEnumerable()
                .Select(MapEntityFromDataRow)
                .FirstOrDefault();
        }

        private Proveedor MapEntityFromDataRow(DataRow row)
        {
            Proveedor proveedor = new Proveedor
            {
                ID_PROVEEDOR = sqlDbConnection.GetDataRowValue<int>(row, "ID_PROVEEDOR"),
                CIUDAD_PROVEEDOR = sqlDbConnection.GetDataRowValue<string>(row, "CIUDAD_PROVEEDOR"),
                CORREO_ELECTRONICO = sqlDbConnection.GetDataRowValue<string>(row, "CORREO_ELECTRONICO"),
                NOMBRE_CONTACTO = sqlDbConnection.GetDataRowValue<string>(row, "NOMBRE_CONTACTO"),
                id_fac_compra = sqlDbConnection.GetDataRowValue<int>(row, "id_fac_compra"),
                NOMBRE_EMPRESA = sqlDbConnection.GetDataRowValue<string>(row, "NOMBRE_EMPRESA"),
                Estado = sqlDbConnection.GetDataRowValue<bool>(row, "Estado")
            };

            return proveedor;
        }
    }
}