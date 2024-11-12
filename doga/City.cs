using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doga
{
    internal class Varos
    {
        public string VarosNev { get; set; }
        public string Orszag { get; set; }
        public double Nepesseg { get; set; }



        public Varos(string sor)
        {
            var e = sor.Split(';');
            VarosNev = e[0];
            Orszag = e[1];
            Nepesseg = double.Parse(e[2].Replace(",", "."), CultureInfo.InvariantCulture);
        }



        public override string ToString() =>
            $"{VarosNev}, {Orszag}, {Nepesseg:F2} millió fo";
    }
}