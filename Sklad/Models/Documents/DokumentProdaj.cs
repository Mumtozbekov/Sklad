using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad.Models.Documents
{
    class DokumentProdaj
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime? Sana { get; set; }
        public bool Naqd { get; set; }
        public bool Otkazma {
            get { return !Naqd; }
         set
            {
                    Tolov_turi = value? "O'tkazma":"Naqd";
            } 
        }
        public string Tolov_turi { get; set; }
        public double Summa { get; set; }
        public Skladi Sklad_m { get; set; }
        public Xaridor Xaridor_m { get; set; }
        public List<Tovar> Tovars { get; set; }
    }
}
