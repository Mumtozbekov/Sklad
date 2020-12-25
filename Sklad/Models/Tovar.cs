using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad.Models
{
    public class Tovar
    {
        private double? quantity { get; set; }

        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime? Sana { get; set; }
        public double? Quantity { get 
            {
                return quantity;
            }
            set
            {
                quantity = value;
                Summa = quantity * Narxi;
            }
        }
        public string ShtrixKod { get; set; }
        public string Turi { get; set; }
        public string OlchoviBirligi { get; set; }
        public double? Narxi { get; set;}
        public double? Summa { get; set; }
        public Kontragent Kontragent_m { get; 
            set; }
        public Skladi Sklad_m { get; set; }
    }
}
