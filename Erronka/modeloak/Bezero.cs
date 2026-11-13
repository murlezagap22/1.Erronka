using System;
using System.Collections.Generic;
using System.Text;

namespace Erronka.modeloak
{
    public class Bezeroa
    {
        public int Id { get; set; }
        public string Izena { get; set; }
        public string Abizena { get; set; }
        public string Emaila { get; set; }
        public string Telefonoa { get; set; }
        public int OstatuMota { get; set; }
        public string SortzeEguna { get; set; }

        public List<Mezua> Mezuak { get; set; }
        public List<Atasa> Atasak { get; set; }

        public Bezeroa()
        {
            Mezuak = new List<Mezua>();
            Atasak = new List<Atasa>();
        }

        public Bezeroa(int id, string izena, int mota, string abizena, string emaila, string telefonoa, string sortzeEguna)
        {
            Id = id;
            Izena = izena;
            OstatuMota = mota;
            Abizena = abizena;
            Emaila = emaila;
            Telefonoa = telefonoa;
            SortzeEguna = sortzeEguna;

            Mezuak = new List<Mezua>();
            Atasak = new List<Atasa>();
        }
    }
}
