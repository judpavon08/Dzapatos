using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.DTOs
{
    public class CreateTablaUsuarioDTO
    {
        public int ID_USUARIO { get; set; }
        public string Nombre_Completo { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
        public DateTime Fecha_Creacion { get; set; }
    }

    public class UpdateTablaUsuarioDTO
    {
        public int ID_USUARIO { get; set; }
        public string Nombre_Completo { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
        public DateTime Fecha_Creacion { get; set; }
    }
}
