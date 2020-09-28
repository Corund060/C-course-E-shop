using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjektinioProgramavimoUzduotis;

namespace ObjektinioProgramavimoUzduotis_UnitTest
{
    [TestClass]
    public class Siuntos_UnitTest
    {
        [TestMethod]
        public void SiuntaSkaiciavimas_Duodam_S_siunta_Tikimes269()
        {
            List<Preke> krp = new List<Preke>();
            krp.Add(new Preke { 
                Ilgis=1,
                Plotis=1,
                Aukstis=1
            });
            krp.Add(new Preke
            {
                Ilgis = 1,
                Plotis = 1,
                Aukstis = 1
            });

            Siunta siunta = new Siunta();
            double kaina = siunta.PristatymoKaina(krp);

            Assert.AreEqual(2.69, kaina);
        }

        [TestMethod]
        public void SiuntaSkaiciavimas_Duodam_S_siunta_TikimesSatsakymo()
        {
            List<Preke> krp = new List<Preke>();
            krp.Add(new Preke
            {
                Ilgis = 1,
                Plotis = 1,
                Aukstis = 1
            });
            krp.Add(new Preke
            {
                Ilgis = 1,
                Plotis = 1,
                Aukstis = 1
            });

            Siunta siunta = new Siunta();
            double kaina = siunta.PristatymoKaina(krp);

            Assert.AreEqual('S', siunta.SiuntosDydis);
        }

        [TestMethod]
        public void SiuntaSkaiciavimas_Duodam_M_siunta_Tikimes349()
        {
            List<Preke> krp = new List<Preke>();
            krp.Add(new Preke
            {
                Ilgis = 17,
                Plotis = 37,
                Aukstis = 60
            });
            krp.Add(new Preke
            {
                Ilgis = 1,
                Plotis = 37,
                Aukstis = 60
            });

            Siunta siunta = new Siunta();
            double kaina = siunta.PristatymoKaina(krp);

            Assert.AreEqual(3.49, kaina);
        }

        [TestMethod]
        public void SiuntaSkaiciavimas_Duodam_M_siunta_TikimesMatsakymo()
        {
            List<Preke> krp = new List<Preke>();
            krp.Add(new Preke
            {
                Ilgis = 17,
                Plotis = 37,
                Aukstis = 64
            });
            krp.Add(new Preke
            {
                Ilgis = 1,
                Plotis = 37,
                Aukstis = 64
            });

            Siunta siunta = new Siunta();
            double kaina = siunta.PristatymoKaina(krp);

            Assert.AreEqual('M', siunta.SiuntosDydis);
        }

        [TestMethod]
        public void SiuntaSkaiciavimas_Duodam_L_siunta_Tikimes449()
        {
            List<Preke> krp = new List<Preke>();
            krp.Add(new Preke
            {
                Ilgis = 37,
                Plotis = 37,
                Aukstis = 64
            });
            krp.Add(new Preke
            {
                Ilgis = 1,
                Plotis = 37,
                Aukstis = 64
            });

            Siunta siunta = new Siunta();
            double kaina = siunta.PristatymoKaina(krp);

            Assert.AreEqual(4.49, kaina);
        }

        [TestMethod]
        public void SiuntaSkaiciavimas_Duodam_L_siunta_TikimesLatsakymo()
        {
            List<Preke> krp = new List<Preke>();
            krp.Add(new Preke
            {
                Ilgis = 37,
                Plotis = 37,
                Aukstis = 64
            });
            krp.Add(new Preke
            {
                Ilgis = 1,
                Plotis = 37,
                Aukstis = 64
            });

            Siunta siunta = new Siunta();
            double kaina = siunta.PristatymoKaina(krp);

            Assert.AreEqual('L', siunta.SiuntosDydis);
        }

        [TestMethod]
        public void SiuntaSkaiciavimas_Duodam_X_siunta_Tikimes20()
        {
            List<Preke> krp = new List<Preke>();
            krp.Add(new Preke
            {
                Ilgis = 100,
                Plotis = 1,
                Aukstis = 1
            });
            krp.Add(new Preke
            {
                Ilgis = 1,
                Plotis = 1,
                Aukstis = 1
            });

            Siunta siunta = new Siunta();
            double kaina = siunta.PristatymoKaina(krp);

            Assert.AreEqual(20, kaina);
        }

        [TestMethod]
        public void SiuntaSkaiciavimas_Duodam_X_siunta_TikimesXatsakymo()
        {
            List<Preke> krp = new List<Preke>();
            krp.Add(new Preke
            {
                Ilgis = 100,
                Plotis = 1,
                Aukstis = 1
            });
            krp.Add(new Preke
            {
                Ilgis = 1,
                Plotis = 1,
                Aukstis = 1
            });

            Siunta siunta = new Siunta();
            double kaina = siunta.PristatymoKaina(krp);

            Assert.AreEqual('X', siunta.SiuntosDydis);
        }
    }
}
