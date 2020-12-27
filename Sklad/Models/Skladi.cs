using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad.Models
{
    public class Skladi
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string More { get; set; }
        public string Adress { get; set; }
    }
}
