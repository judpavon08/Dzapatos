using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.DTOs
{
    public class CreateProductoDTO
    {
        public int ID_PRODUCTO { get; set; }
        public string descripcion { get; set; }
        public string NOMBRE_PRODUCTO { get; set; }
        public int ID_COLOR { get; set; }
        public string EXISTENCIA { get; set; }
        public int ID_MARCA { get; set; }
        public int ID_MATERIAL { get; set; }
        public int ID_CATEGORIA { get; set; }
        public int ID_BODEGA { get; set; }
        public int ID_TALLA { get; set; }
        public bool Estado { get; set; }
    }

    public class UpdateProductoDTO
    {
        public int ID_PRODUCTO { get; set; }
        public string descripcion { get; set; }
        public string NOMBRE_PRODUCTO { get; set; }
        public int ID_COLOR { get; set; }
        public string EXISTENCIA { get; set; }
        public int ID_MARCA { get; set; }
        public int ID_MATERIAL { get; set; }
        public int ID_CATEGORIA { get; set; }
        public int ID_BODEGA { get; set; }
        public int ID_TALLA { get; set; }
        public bool Estado { get; set; }
    }
}
