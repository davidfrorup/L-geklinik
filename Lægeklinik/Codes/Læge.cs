using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lægeklinik.Codes
{
    internal class Læge : Person
    {
        public string Specialle { get; set; }
        public List<Patient> Patienter { get; }

        public Læge(string forNavn, string efterNavn, string specialle, string telefonNummer) : base(forNavn, efterNavn, telefonNummer)
        {
            Specialle = specialle;
            Patienter = new List<Patient>();
        }
    }
}
