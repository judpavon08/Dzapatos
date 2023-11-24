using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.Entities
{
    public class Material : BaseEntity
    {
        public int ID_MATERIAL { get; set; }
        public bool estado { get; set; }
        public string detalles_material { get; set; }
        public string NOMBRE_MATERIAL { get; set;}
    }
}
