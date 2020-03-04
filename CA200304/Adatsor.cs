using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CA200304
{
    class Adatsor
    {
        TimeSpan Ido { set; get; }
        public int Db { get; set; }
        public string Sofor { get; set; }
        public int OsszPerc => (int)Ido.TotalMinutes;

        public Adatsor(string s)
        {
            var t = s.Split(';');
            Ido = new TimeSpan(int.Parse(t[0]), int.Parse(t[1]), 0);
            Db = int.Parse(t[2]);
            Sofor = t[3];
        }
    }
}
