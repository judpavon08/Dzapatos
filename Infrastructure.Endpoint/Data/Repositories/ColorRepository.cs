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
    public class ColorRepository : GenericRepository<Color>, IColorRepository
    {
        public ColorRepository(ISqlDbConnection sqlDbConnection, ISqlCommandOperationBuilder operationBuilder)
            : base(sqlDbConnection, operationBuilder) { }

        public async Task<List<Color>> GetAsync()
        {
            DataTable dataTable = await GetDataTableAsync();
            return dataTable.AsEnumerable()
                .Select(MapEntityFromDataRow)
                .ToList();
        }

        public async Task<Color> GetByIdAsync(int id)
        {
            DataTable dataTable = await GetDataTableByIdAsync(id);
            return dataTable.AsEnumerable()
                .Select(MapEntityFromDataRow)
                .FirstOrDefault();
        }

        private Color MapEntityFromDataRow(DataRow row)
        {
            Color color = new Color
            {
                ID_COLOR = sqlDbConnection.GetDataRowValue<int>(row, "ID_COLOR"),                
                NOMBRE_COLOR = sqlDbConnection.GetDataRowValue<string>(row, "NOMBRE_COLOR"),
                // Agrega más propiedades de la entidad Color y mapea los valores desde el DataRow si es necesario.
            };

            return color;
        }
    }
}