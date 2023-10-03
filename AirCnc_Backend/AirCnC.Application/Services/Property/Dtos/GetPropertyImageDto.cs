﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirCnC.Application.Services.Property.Dtos
{
    public class GetPropertyImageDto
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public int PropertyID { get; set; }
    }
}
