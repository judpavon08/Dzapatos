using Domain.Endpoint.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Endpoint.Entities
{
    public class Tallas : BaseEntity
    {
        [Key]
        public int ID_TALLA { get; set; }
        public string NUM_TALLA { get; set; }
    }
}
