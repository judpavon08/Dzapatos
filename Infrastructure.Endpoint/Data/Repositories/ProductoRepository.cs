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
    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {
        public ProductoRepository(ISqlDbConnection sqlDbConnection, ISqlCommandOperationBuilder operationBuilder)
            : base(sqlDbConnection, operationBuilder) { }

        public async Task<List<Producto>> GetAsync()
        {
            DataTable dataTable = await GetDataTableAsync();
            return dataTable.AsEnumerable()
                .Select(MapEntityFromDataRow)
                .ToList();
        }

        public async Task<Producto> GetByIdAsync(int id)
        {
            DataTable dataTable = await GetDataTableByIdAsync(id);
            return dataTable.AsEnumerable()
                .Select(MapEntityFromDataRow)
                .FirstOrDefault();
        }

        private Producto MapEntityFromDataRow(DataRow row)
        {
            Producto producto = new Producto
            {        
                ID_PRODUCTO = sqlDbConnection.GetDataRowValue<int>(row,"ID_PRODUCTO"),
                descripcion = sqlDbConnection.GetDataRowValue<string>(row, "descripcion"),
                NOMBRE_PRODUCTO= sqlDbConnection.GetDataRowValue<string>(row,"NOMBRE_PRODUCTO"),
                ID_COLOR = sqlDbConnection.GetDataRowValue<int>(row,"ID_COLOR"),
                EXISTENCIA = sqlDbConnection.GetDataRowValue<string>(row, "EXISTENCIA"),
                ID_MARCA = sqlDbConnection.GetDataRowValue<int>(row, "ID_MARCA"),
                ID_MATERIAL = sqlDbConnection.GetDataRowValue<int>(row, "ID_MATERIAL"),
                ID_CATEGORIA = sqlDbConnection.GetDataRowValue<int>(row, "ID_CATEGORIA"),
                ID_BODEGA = sqlDbConnection.GetDataRowValue<int>(row, "ID_BODEGA"),
                ID_TALLA = sqlDbConnection.GetDataRowValue<int>(row, "ID_TALLA"),
                Estado = sqlDbConnection.GetDataRowValue<bool>(row, "Estado")
                // Agrega más propiedades de la entidad Marca y mapea los valores desde el DataRow si es necesario.
            };

            return producto;
        }
    }
}