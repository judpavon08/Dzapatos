﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.DTOs
{
    public class CreateColorDTO
    {
        public int ID_COLOR { get; set; }
        public string NOMBRE_COLOR { get; set; }
    }

    public class UpdateColorDTO
    {
        public int ID_COLOR { get; set; }
        public string NOMBRE_COLOR { get; set; }
    }
}
