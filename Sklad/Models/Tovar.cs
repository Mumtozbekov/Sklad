using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad.Models
{
    public class Tovar:ICloneable
    {
        private double? narxi { get; set; }
        private double? quantity { get; set; }
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime? Sana { get; set; }
        public double? Quantity {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
                if (Narxi != null)
                    Summa = Quantity * Narxi;

            }
        }
        
        public string ShtrixKod { get; set; }
        public string Turi { get; set; }
        public string OlchoviBirligi { get; set; }
        public double? Narxi {
            get
            {
                return narxi;
            }
            set
            {
                narxi = value;
                if(Quantity!=null)
                    Summa = Quantity * Narxi;

            }
        }
        public double? Summa { get; set; }
        public Kontragent Kontragent_m { get;  set; }
        public Skladi Sklad_m { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
