using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjektinioProgramavimoUzduotis
{
    public class Siunta
    {
        public Gabaritai SiuntosMatmenys { get; set; }

        // Skaiciuojant siuntos dydi sumuoju prekiu maziausią matmenį ('kraunu į aukštį')
        // Likę du siuntos matmenys bus didžiausi kitų prekių matmenys
        public void SiuntaSkaiciavimas(List<Preke> krp)
        {
            SiuntosMatmenys = new Gabaritai
            {
                GabaritaiX = 0,
                GabaritaiY = 0,
                GabaritaiZ = 0
            };
            int maxY = 0;
            int maxZ = 0;
            List <int> coord;
            foreach (var item in krp)
            {
                coord = new List<int>{ item.Ilgis, item.Plotis, item.Aukstis };
                SiuntosMatmenys.GabaritaiX += coord.Min();
                coord.Remove(coord.Where(p => p == coord.Min()).First());

                if (maxY > maxZ)
                {
                    if (coord.Min() > maxZ)
                    {
                        maxZ = coord.Min();
                        coord.Remove(coord.Where(p => p == coord.Min()).First());
                        if (coord.Min() > maxY)
                        {
                            maxY = coord.Min();
                        }
                    }
                    else if (coord.Min() > maxY)
                    {
                        maxY = coord.Min();
                        coord.Remove(coord.Where(p => p == coord.Min()).First());
                    }
                }
                else 
                {
                    if (coord.Min() > maxY)
                    {
                        maxY = coord.Min();
                        coord.Remove(coord.Where(p => p == coord.Min()).First());
                        if (coord.Min() > maxZ)
                        {
                            maxZ = coord.Min();
                        }
                    }
                    else if (coord.Min() > maxZ)
                    {
                        maxZ = coord.Min();
                        coord.Remove(coord.Where(p => p == coord.Min()).First());
                    }
                }                  
            }
            SiuntosMatmenys.GabaritaiZ = maxZ;
            SiuntosMatmenys.GabaritaiY = maxY;

            SiuntosDydis = SiuntosDydzioNustatymas(SiuntosMatmenys);
        }
        public string PristatymoBudas { get; set; }
        public char SiuntosDydis { get; set; }
        public char SiuntosDydzioNustatymas(Gabaritai matmenys)
        {
            if (matmenys.GabaritaiX<=9 & matmenys.GabaritaiY<=38 & matmenys.GabaritaiZ<=64)
            {
                return 'S';
            }
            if (matmenys.GabaritaiX <= 19 & matmenys.GabaritaiY <= 38 & matmenys.GabaritaiZ <= 64)
            {
                return 'M';
            }
            if (matmenys.GabaritaiX <= 39 & matmenys.GabaritaiY <= 38 & matmenys.GabaritaiZ <= 64)
            {
                return 'L';
            }
            return 'X';         
        }
        public double PristatymoKaina(List<Preke> krp)
        {
            SiuntaSkaiciavimas(krp);
            switch (SiuntosDydis)
            {
                case 'S':
                    return 2.69;
                case 'M':
                    return 3.49;
                case 'L':
                    return 4.49;
                case 'X':
                    return 20;
            }
            return 0;
        }

    }
}
