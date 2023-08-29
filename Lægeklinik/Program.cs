using Lægeklinik.Codes;
using Lægeklinik.Menu;
using System;
using System.Collections.Generic;


namespace Lægeklinik;

internal class Program
{
    public static List<Patient> patienter = new List<Patient>();

    public static void Main(string[] args)
    {
        List<Læge> læger = new List<Læge>
            {
               new Læge("Peter", "Hansen", "Øjenlæge", "11111111"),
               new Læge("Martin", "Jensen", "Radiologi", "22222222"),
               new Læge("Thomas", "Olsen", "Kirurgi", "33333333"),
               new Læge("Ole", "Nielsen", "Onkologi", "44444444")
            };

       
        HovedMenu menu = new HovedMenu(læger, patienter);
        menu.Run();
    }
}
