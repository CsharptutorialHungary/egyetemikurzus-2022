using NUnit.Framework;
using Beadando;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace AdatbekerTests

{ //Ide kell még több UNIT
    [TestFixture]
    internal class Tests
    {
        [TestCase(4, 8, 2, 1)]
        [TestCase(3, 2, 3, 1)]
        [TestCase(0, 0, 4, 2)]

        public void BiztositjaHogyAHajoLehelyezhetoE(int x, int y, int tipus, int orientacio)
        {
            Hajo hajo = new Beadando.Hajo();
            hajo.X = x;
            hajo.Y = y;
            hajo.Tipus = tipus;
            hajo.Orientacio = orientacio;
            JatekTabla j = new JatekTabla(10, 10);
            j.PalyatGeneral();
            // Arrange + Act
            bool result = j.HajoLehelyezhetoE(hajo);
            Assert.IsTrue(result);
        }
        [TestCase(-1, 0, 5, 1)]
        [TestCase(0, -1, 4, 2)]
        [TestCase(10, -1, 5, 1)]
        [TestCase(10, 1, 2, 2)]
        [TestCase(0, 14, 2, 2)]
        public void BiztositjaHogyAHajoNemLehelyezheto(int x, int y, int tipus, int orientacio)
        {
            Hajo hajo = new Beadando.Hajo();
            hajo.X = x;
            hajo.Y = y;
            hajo.Tipus = tipus;
            hajo.Orientacio = orientacio;
            JatekTabla j = new JatekTabla(10, 10);
            j.PalyatGeneral();
            // Arrange + Act
            bool result = j.HajoLehelyezhetoE(hajo);
            Assert.IsFalse(result);
        }
        [TestCase(4,4,4,4)]
        [TestCase(4,5,4,5)]
        [TestCase(4,4,5,5)]
        public void JatekosHajotLoTestSikertelen(int x, int y, int hajoX, int hajoY)
        {

            JatekTabla lovoTabla = new JatekTabla(10, 10);
            lovoTabla.PalyatGeneral();
            JatekTabla palya = new JatekTabla(10, 10);
            Hajo hajo = new Hajo();
            hajo.SetTipus(2);
            hajo.X = hajoX;
            hajo.Y = hajoY;
            hajo.Orientacio = 1;


            palya.PalyatGeneral();
            palya.HajotElhelyez(hajo);
            bool result = palya.hajotLoJatekos(x, y, lovoTabla);
            Assert.IsFalse(result);
        }
    }
}