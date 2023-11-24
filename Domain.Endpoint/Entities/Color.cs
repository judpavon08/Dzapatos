using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.Entities
{
    public class Color : BaseEntity
    {
        [Key]
        public int ID_COLOR { get; set; }
        public string NOMBRE_COLOR { get; set; }
    }
}

