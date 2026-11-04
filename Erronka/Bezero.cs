using System;
using System.Collections.Generic;
using System.Text;

namespace Erronka
{
    public class Bezeroa
    {
        public int Id { get; set; }
        public string Izena { get; set; }
        public int Mota { get; set; }

        public List<Mezua> Mezuak { get; set; }
        public List<Atasa> Atasak { get; set; }

        public Bezeroa(int id, string izena, int mota)
        {
            Id = id;
            Izena = izena;
            Mota = mota;

            Mezuak = new List<Mezua>();
            Atasak = new List<Atasa>();
        }
    }
}
