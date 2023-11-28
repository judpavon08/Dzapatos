using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.DTOs
{
    public class CreateCategoriaDTO
    {
        public int ID_CATEGORIA { get; set; }
        public bool Estado { get; set; }
        public string Descripcion { get; set; }
        public string Nombre_Categoria { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
    }

    public class UpdateCategoriaDTO
    {
        public int ID_CATEGORIA { get; set; }
        public bool Estado { get; set; }
        public string Descripcion { get; set; }
        public string Nombre_Categoria { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}
