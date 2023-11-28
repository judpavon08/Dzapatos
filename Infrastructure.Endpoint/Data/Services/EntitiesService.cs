using Domain.Endpoint.Entities;
using Infrastructure.Endpoint.Data.Builders;
using Infrastructure.Endpoint.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Infrastructure.Endpoint.Data.Services
{

    public class EntitiesService : IEntitiesService
    {
        private Dictionary<Type, SqlEntitySettings> entities = new Dictionary<Type, SqlEntitySettings>();
        private readonly ISqlEntitySettingsBuilder builder;

        public EntitiesService(ISqlEntitySettingsBuilder builder)
        {
            this.builder = builder;
            BuildEntities();
        }

        public SqlEntitySettings GetSettings<T>() where T : BaseEntity
        {
            //if (typeof(ToDo).Equals(typeof(T))) return BuildToDoSettings();
            if (!entities.ContainsKey(typeof(T))) throw new ArgumentOutOfRangeException(nameof(T), "Entidad no mapeada");

            return entities[typeof(T)];
        }

        private void BuildEntities()
        {
            SqlEntitySettings tallasSettings = BuildTallasSettings();
            SqlEntitySettings marcaSettings = BuildMarcaSettings();
            SqlEntitySettings colorSettings = BuildColorSettings();
            SqlEntitySettings materialSettings = BuildMaterialSettings();
            SqlEntitySettings productoSettings = BuildProductoSettings();
            SqlEntitySettings proveedorSettings = BuildProveedorSettings();
            SqlEntitySettings bodegaSettings = BuildBodegaSettings();


            entities.Add(typeof(Tallas), tallasSettings);
            entities.Add(typeof(Marca), marcaSettings);
            entities.Add(typeof(Color), colorSettings);
            entities.Add(typeof(Material), materialSettings);
            entities.Add(typeof(Producto), productoSettings);
            entities.Add(typeof(Proveedor), proveedorSettings);
            entities.Add(typeof(Bodega), bodegaSettings);

            // Imprimir el diccionario después de construirlo
            foreach (var entity in entities)
            {
                Console.WriteLine($"Entity: {entity.Key.Name}, Primary Key: {entity.Value.Columns.FirstOrDefault(c => c.IsPrimaryKey)?.Name}");
            }
        }


        private SqlEntitySettings BuildTallasSettings()
        {
            return builder.Entity<Tallas>(entity =>
            {
                entity.Table("TALLA"); // Nombre de la tabla en la base de datos para Tallas
                entity.Property(property => property.NUM_TALLA)
                    .SetDefaultName("NUM_TALLA") // Nombre de la columna en la base de datos
                    .WithSqlDbType(SqlDbType.VarChar) // Tipo de datos en la base de datos
                    .AddProperty();

                entity.Property(property => property.ID_TALLA)
                    .SetDefaultName("ID_TALLA") // Nombre de la columna en la base de datos para ID_TALLA
                    .WithSqlDbType(SqlDbType.Int) // Tipo de datos en la base de datos                    
                    .AsPrimaryKey()  // Asegúrate de marcar la columna como clave primaria
                    .AddProperty();

                // Puedes seguir agregando más propiedades si es necesario.
            }).Build();
        }
        private SqlEntitySettings BuildMaterialSettings()
        {
            return builder.Entity<Material>(entity =>
            {
                entity.Table("MATERIAL"); // Nombre de la tabla en la base de datos para Tallas
                entity.Property(property => property.estado)
                    .SetDefaultName("estado") // Nombre de la columna en la base de datos
                    .WithSqlDbType(SqlDbType.Bit) // Tipo de datos en la base de datos
                    .AddProperty();

                entity.Property(property => property.detalles_material)
                   .SetDefaultName("detalles_material") // Nombre de la columna en la base de datos
                   .WithSqlDbType(SqlDbType.VarChar) // Tipo de datos en la base de datos
                   .AddProperty();

                entity.Property(property => property.NOMBRE_MATERIAL)
                   .SetDefaultName("NOMBRE_MATERIAL") // Nombre de la columna en la base de datos
                   .WithSqlDbType(SqlDbType.VarChar) // Tipo de datos en la base de datos
                   .AddProperty();

                entity.Property(property => property.ID_MATERIAL)
                    .SetDefaultName("ID_MATERIAL") // Nombre de la columna en la base de datos para ID_TALLA
                    .WithSqlDbType(SqlDbType.VarChar) // Tipo de datos en la base de datos
                    .AsPrimaryKey()  // Asegúrate de marcar la columna como clave primaria
                    .AddProperty();

                // Puedes seguir agregando más propiedades si es necesario.
            }).Build();
        }
        private SqlEntitySettings BuildColorSettings()
        {
            return builder.Entity<Color>(entity =>
            {
                entity.Table("COLOR"); // Nombre de la tabla en la base de datos para Tallas
                entity.Property(property => property.NOMBRE_COLOR)
                    .SetDefaultName("NOMBRE_COLOR") // Nombre de la columna en la base de datos
                    .WithSqlDbType(SqlDbType.NVarChar) // Tipo de datos en la base de datos
                    .AddProperty();

                entity.Property(property => property.ID_COLOR)
                     .SetDefaultName("ID_COLOR") // Nombre de la columna en la base de datos para ID_TALLA
                     .WithSqlDbType(SqlDbType.Int) // Tipo de datos en la base de datos
                     .AsPrimaryKey()  // Asegúrate de marcar la columna como clave primaria
                     .AddProperty();

                // Puedes seguir agregando más propiedades si es necesario.
            }).Build();
        }

        private SqlEntitySettings BuildMarcaSettings()
        {
            return builder.Entity<Marca>(entity =>
            {
                entity.Table("MARCA"); // Nombre de la tabla en la base de datos para Tallas
                entity.Property(property => property.NOMBRE_MARCA)
                    .SetDefaultName("NOMBRE_MARCA") // Nombre de la columna en la base de datos
                    .WithSqlDbType(SqlDbType.NVarChar) // Tipo de datos en la base de datos
                    .AddProperty();

                entity.Property(property => property.ID_MARCA)
                    .SetDefaultName("ID_MARCA") // Nombre de la columna en la base de datos para ID_TALLA
                    .WithSqlDbType(SqlDbType.Int) // Tipo de datos en la base de datos
                    .AsPrimaryKey()  // Asegúrate de marcar la columna como clave primaria
                    .AddProperty();

                entity.Property(property => property.estado)
                   .SetDefaultName("estado") // Nombre de la columna en la base de datos para ID_TALLA
                   .WithSqlDbType(SqlDbType.Bit) // Tipo de datos en la base de datos
                   .AddProperty();

                // Puedes seguir agregando más propiedades si es necesario.
            }).Build();
        }

        private SqlEntitySettings BuildProductoSettings()
        {
            return builder.Entity<Producto>(entity =>
            {
                entity.Table("Producto"); // Nombre de la tabla en la base de datos para Tallas

                entity.Property(property => property.ID_PRODUCTO)
                    .SetDefaultName("ID_PRODUCTO")
                    .WithSqlDbType(SqlDbType.Int)
                    .AsPrimaryKey()
                    .AddProperty();

                entity.Property(property => property.descripcion)
                    .SetDefaultName("descripcion")
                    .WithSqlDbType(SqlDbType.VarChar)
                    .AddProperty();

                entity.Property(property => property.NOMBRE_PRODUCTO)
                    .SetDefaultName("NOMBRE_PRODUCTO")
                    .WithSqlDbType(SqlDbType.VarChar)
                    .AddProperty();

                entity.Property(property => property.ID_COLOR)
                    .SetDefaultName("ID_COLOR")
                    .WithSqlDbType(SqlDbType.Int)
                    .AddProperty();

                entity.Property(property => property.EXISTENCIA)
                    .SetDefaultName("EXISTENCIA")
                    .WithSqlDbType(SqlDbType.VarChar)
                    .AddProperty();

                entity.Property(property => property.ID_MARCA)
                    .SetDefaultName("ID_MARCA")
                    .WithSqlDbType(SqlDbType.Int)
                    .AddProperty();

                entity.Property(property => property.ID_MATERIAL)
                    .SetDefaultName("ID_MATERIAL")
                    .WithSqlDbType(SqlDbType.Int)
                    .AddProperty();

                entity.Property(property => property.ID_CATEGORIA)
                    .SetDefaultName("ID_CATEGORIA")
                    .WithSqlDbType(SqlDbType.Int)
                    .AddProperty();

                entity.Property(property => property.ID_BODEGA)
                    .SetDefaultName("ID_BODEGA")
                    .WithSqlDbType(SqlDbType.Int)
                    .AddProperty();

                entity.Property(property => property.ID_TALLA)
                    .SetDefaultName("ID_TALLA")
                    .WithSqlDbType(SqlDbType.Int)
                    .AddProperty();

                entity.Property(property => property.Estado)
                    .SetDefaultName("Estado")
                    .WithSqlDbType(SqlDbType.Bit)
                    .AddProperty();

                // Puedes seguir agregando más propiedades si es necesario.
            }).Build();
        }
        private SqlEntitySettings BuildProveedorSettings()
        {
            return builder.Entity<Proveedor>(entity =>
            {
                entity.Table("Proveedor"); // Nombre de la tabla en la base de datos para Tallas
                entity.Property(property => property.ID_PROVEEDOR)
                    .SetDefaultName("ID_PROVEEDOR") // Nombre de la columna en la base de datos para ID_TALLA
                    .WithSqlDbType(SqlDbType.Int) // Tipo de datos en la base de datos
                    .AsPrimaryKey()  // Asegúrate de marcar la columna como clave primaria
                    .AddProperty();
                entity.Property(property => property.CIUDAD_PROVEEDOR)
                    .SetDefaultName("CIUDAD_PROVEEDOR") // Nombre de la columna en la base de datos
                    .WithSqlDbType(SqlDbType.NVarChar) // Tipo de datos en la base de datos
                    .AddProperty();

                entity.Property(property => property.CORREO_ELECTRONICO)
                   .SetDefaultName("CORREO_ELECTRONICO") // Nombre de la columna en la base de datos
                   .WithSqlDbType(SqlDbType.NVarChar) // Tipo de datos en la base de datos
                   .AddProperty();

                entity.Property(property => property.NOMBRE_CONTACTO)
                   .SetDefaultName("NOMBRE_CONTACTO") // Nombre de la columna en la base de datos
                   .WithSqlDbType(SqlDbType.NVarChar) // Tipo de datos en la base de datos
                   .AddProperty();

                entity.Property(property => property.id_fac_compra)
                     .SetDefaultName("id_fac_compra")
                     .WithSqlDbType(SqlDbType.Int)
                     .AddProperty();

                entity.Property(property => property.NOMBRE_EMPRESA)
                   .SetDefaultName("NOMBRE_EMPRESA") // Nombre de la columna en la base de datos
                   .WithSqlDbType(SqlDbType.NVarChar) // Tipo de datos en la base de datos
                   .AddProperty();

                entity.Property(property => property.Estado)
                   .SetDefaultName("Estado") // Nombre de la columna en la base de datos para ID_TALLA
                   .WithSqlDbType(SqlDbType.Bit) // Tipo de datos en la base de datos
                   .AddProperty();

                // Puedes seguir agregando más propiedades si es necesario.
            }).Build();
        }

        private SqlEntitySettings BuildBodegaSettings()
        {
            return builder.Entity<Bodega>(entity =>
            {
                entity.Table("Bodega"); // Nombre de la tabla en la base de datos para Tallas
                entity.Property(property => property.ID_BODEGA)
                    .SetDefaultName("ID_BODEGA") // Nombre de la columna en la base de datos para ID_TALLA
                    .WithSqlDbType(SqlDbType.Int) // Tipo de datos en la base de datos
                    .AsPrimaryKey()  // Asegúrate de marcar la columna como clave primaria
                    .AddProperty();

                entity.Property(property => property.NOMBRE_BODEGA)
                    .SetDefaultName("NOMBRE_BODEGA") // Nombre de la columna en la base de datos
                    .WithSqlDbType(SqlDbType.NVarChar) // Tipo de datos en la base de datos
                    .AddProperty();

                entity.Property(property => property.ID_PRODUCTO)
                   .SetDefaultName("ID_PRODUCTO") // Nombre de la columna en la base de datos
                   .WithSqlDbType(SqlDbType.Int) // Tipo de datos en la base de datos
                   .AddProperty();

                entity.Property(property => property.DIRECCION)
                   .SetDefaultName("DIRECCION") // Nombre de la columna en la base de datos
                   .WithSqlDbType(SqlDbType.NVarChar) // Tipo de datos en la base de datos
                   .AddProperty();                
                // Puedes seguir agregando más propiedades si es necesario.
            }).Build();
        }

    }
}