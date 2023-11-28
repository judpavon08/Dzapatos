using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.DTOs
{
    public class CreateBodegaDTO
    {
        public int ID_BODEGA { get; set; }
        public string NOMBRE_BODEGA { get; set; }
        public string ID_PRODUCTO { get; set; }
        public string DIRECCION { get; set; }
    }

    public class UpdateBodegaDTO
    {
        public int ID_BODEGA { get; set; }
        public string NOMBRE_BODEGA { get; set; }
        public string ID_PRODUCTO { get; set; }
        public string DIRECCION { get; set; }
    }
}
