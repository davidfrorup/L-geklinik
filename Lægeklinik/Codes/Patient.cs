using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lægeklinik.Codes;

internal class Patient : Person
{
    public List<Læge> TildeltLæger { get; }

    public Patient(string forNavn, string efterNavn, string telefonNummer) : base(forNavn, efterNavn, telefonNummer)
    {
        TildeltLæger = new List<Læge>();
    }

    public void TildelLæge(Læge læge)
    {
        if (TildeltLæger.Count >= 3)
        {
            throw new Exception("Patienten har allerede tildelt 3 læger.");
        }
        if (læge.Specialle == "Kirurgi" && TildeltLæger.Exists(d => d.Specialle == "Onkologi"))
        {
            throw new Exception("Kirurgi patienter kan ikke have Onkologi læger.");
        }
 
        if (læge.Patienter.Count >= 3)
        {
            throw new Exception("Lægen har allerede tildelt 3 patienter.");
        }

        TildeltLæger.Add(læge);
        læge.Patienter.Add(this);
    }
}


