using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lægeklinik.Codes;

internal class Person
{
    public string ForNavn { get; set; }
    public string EfterNavn { get; set; }
    public string TelefonNummer { get; set; }

    public Person(string forNavn, string efterNavn, string telefonNummer)
    {
        ForNavn = forNavn;
        EfterNavn = efterNavn;
        TelefonNummer = telefonNummer;
    }
}
