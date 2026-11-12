using System;
using System.Collections.Generic;
using System.Text;

namespace Erronka
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

        // Constructor vacío para leer el JSON
        public Bezeroa()
        {
            Mezuak = new List<Mezua>();
            Atasak = new List<Atasa>();
        }

        // Constructor que ya utilizabas
        public Bezeroa(int id, string izena, int mota)
        {
            Id = id;
            Izena = izena;
            OstatuMota = mota;

            Mezuak = new List<Mezua>();
            Atasak = new List<Atasa>();
        }
    }
}
