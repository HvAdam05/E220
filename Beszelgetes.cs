using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cseveges
{
    internal class Beszelgetes
    {
        public DateTime Kezdet;
        public DateTime Veg;
        public string Kezdemenyezo;
        public string Fogado;
    public Beszelgetes(string sor)
    {
            var s = sor.Split(';');
            this.Kezdet = DateTime.ParseExact(s[0], "yy.MM.dd-HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
            this.Veg = DateTime.ParseExact(s[1], "yy.MM.dd-HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
            this.Kezdemenyezo = s[2];
            this.Fogado = s[3];

    }
    }
}
