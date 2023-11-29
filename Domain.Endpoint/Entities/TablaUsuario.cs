using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.Entities
{
    public class TablaUsuario : BaseEntity
    {
        [Key]
        public int ID_USUARIO { get; set; }
        public string Nombre_Completo { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
        public DateTime Fecha_Creacion { get; set; }
    }
}
