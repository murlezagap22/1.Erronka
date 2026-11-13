using System;
using System.Collections.Generic;
using System.Text;

namespace Erronka.modeloak
{
    public class Mezua
    {
        public string Testua { get; set; }
        public bool Osatuta { get; set; }
        public bool Ezabatuta { get; set; }
        public bool EzabatutaAdmin { get; set; }

        public Mezua(string testua, bool osatuta = false, bool ezabatuta = false, bool ezabatutaAdmin = false)
        {
            Testua = testua;
            Osatuta = osatuta;
            Ezabatuta = ezabatuta;
            EzabatutaAdmin = ezabatutaAdmin;
        }
    }
}
