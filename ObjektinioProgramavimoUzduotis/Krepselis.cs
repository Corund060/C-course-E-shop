using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjektinioProgramavimoUzduotis
{
    class Krepselis
    {
        public Krepselis()
        {
            UzsakomosPrekes = new List<Preke>();            
        }

        public List<Preke> UzsakomosPrekes { get; set; }
        public double MoketinaSuma { get; set; }       
        public string Pristatymas { get; set; }               

    }
}
