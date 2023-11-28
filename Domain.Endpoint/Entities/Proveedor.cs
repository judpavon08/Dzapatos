﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.Entities
{
    public class Proveedor : BaseEntity
    {
        [Key]
        public int ID_PROVEEDOR { get; set; }
        public string CIUDAD_PROVEEDOR { get; set; }
        public string CORREO_ELECTRONICO { get; set; }
        public string NOMBRE_CONTACTO { get; set; }
        public int id_fac_compra { get; set; }
        public string NOMBRE_EMPRESA { get; set; }
        public bool Estado { get; set; }
    }
}
