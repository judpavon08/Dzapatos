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
    public class TablaUsuarioRepository : GenericRepository<TablaUsuario>, ITablaUsuarioRepository
    {
        public TablaUsuarioRepository(ISqlDbConnection sqlDbConnection, ISqlCommandOperationBuilder operationBuilder)
            : base(sqlDbConnection, operationBuilder) { }

        public async Task<List<TablaUsuario>> GetAsync()
        {
            DataTable dataTable = await GetDataTableAsync();
            return dataTable.AsEnumerable()
                .Select(MapEntityFromDataRow)
                .ToList();
        }

        public async Task<TablaUsuario> GetByIdAsync(int id)
        {
            DataTable dataTable = await GetDataTableByIdAsync(id);
            return dataTable.AsEnumerable()
                .Select(MapEntityFromDataRow)
                .FirstOrDefault();
        }

        private TablaUsuario MapEntityFromDataRow(DataRow row)
        {
            TablaUsuario tablaUsuario = new TablaUsuario
            {
                ID_USUARIO = sqlDbConnection.GetDataRowValue<int>(row, "ID_USUARIO"),
                Nombre_Completo = sqlDbConnection.GetDataRowValue<string>(row, "NOMBRE_COMPLETO"),
                Correo = sqlDbConnection.GetDataRowValue<string>(row, "Correo"),
                Telefono = sqlDbConnection.GetDataRowValue<string>(row, "Telefono"),
                Estado = sqlDbConnection.GetDataRowValue<bool>(row, "Estado"),
                Fecha_Creacion = sqlDbConnection.GetDataRowValue<DateTime>(row, "Fecha_Creacion")
            };

            return tablaUsuario;
        }
    }
}