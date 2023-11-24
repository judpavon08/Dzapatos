using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.DTOs
{
    public class CreateMaterialDTO
    {
        public int ID_MATERIAL { get; set; }
        public bool estado { get; set; }
        public string detalles_material { get; set; }
        public string NOMBRE_MATERIAL { get; set; }
    }

    public class UpdateMaterialDTO
    {
        public int ID_MATERIAL { get; set; }
        public bool estado { get; set; }
        public string detalles_material { get; set; }
        public string NOMBRE_MATERIAL { get; set; }
    }
}
