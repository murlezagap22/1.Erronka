using System;
using System.Collections.Generic;
using System.Text;

namespace Erronka
{
    public class Atasa
    {
        public string Testua { get; set; }
        public string Langilea { get; set; }
        public bool Eginda { get; set; }

        public Atasa(string testua, string langilea = "", bool eginda = false)
        {
            Testua = testua;
            Langilea = langilea;
            Eginda = eginda;
        }
    }
}
