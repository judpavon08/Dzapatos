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
    public class MaterialRepository : GenericRepository<Material>, IMaterialRepository
    {
        public MaterialRepository(ISqlDbConnection sqlDbConnection, ISqlCommandOperationBuilder operationBuilder)
            : base(sqlDbConnection, operationBuilder) { }

        public async Task<List<Material>> GetAsync()
        {
            DataTable dataTable = await GetDataTableAsync();
            return dataTable.AsEnumerable()
                .Select(MapEntityFromDataRow)
                .ToList();
        }

        public async Task<Material> GetByIdAsync(int id)
        {
            DataTable dataTable = await GetDataTableByIdAsync(id);
            return dataTable.AsEnumerable()
                .Select(MapEntityFromDataRow)
                .FirstOrDefault();
        }

        private Material MapEntityFromDataRow(DataRow row)
        {
            Material material = new Material
            {
                ID_MATERIAL = sqlDbConnection.GetDataRowValue<int>(row, "ID_MATERIAL"),
                estado = sqlDbConnection.GetDataRowValue<bool>(row, "estado"),
                detalles_material = sqlDbConnection.GetDataRowValue<string>(row, "detalles_material"),
                NOMBRE_MATERIAL = sqlDbConnection.GetDataRowValue<string>(row, "NOMBRE_MATERIAL")
                // Agrega más propiedades de la entidad Tallas y mapea los valores desde el DataRow si es necesario.
            };

            return material;
        }
    }
}
