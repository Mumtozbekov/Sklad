﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad.Models
{
    class Sklad
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
    }
}
