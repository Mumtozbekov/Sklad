using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad.Models
{
    class Tovar
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string ShtrixKod { get; set; }
    }
}
