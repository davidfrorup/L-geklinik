using System;
using System.Collections.Generic;
using Lægeklinik.Codes;
using Lægeklinik.Lyde; // Husk at inkludere din namespace for Lydafspiller

namespace Lægeklinik.Menu
{
    internal class HovedMenu
    {
        private List<Læge> læger;
        private List<Patient> patienter;
        private Lydafspiller lydAfspiller; // Opret en instans af Lydafspiller

        internal HovedMenu(List<Læge> læger, List<Patient> patienter)
        {
            this.læger = læger;
            this.patienter = patienter;

            // Opret en instans af Lydafspiller og initialiser den med lydfilens sti
            lydAfspiller = new Lydafspiller("menulyd.wav");
        }

        public void Run()
        {
            // Afspil baggrundsmusik
            lydAfspiller.PlayBackgroundMusic();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Velkommen til Lægeklinikken!");
                Console.WriteLine("Vælg en handling:");
                Console.WriteLine("1. Registrer patient");
                Console.WriteLine("2. Vis patientliste");
                Console.WriteLine("3. Afslut");

                string valg = Console.ReadLine();

                switch (valg)
                {
                    case "1":
                        StopBackgroundMusic();
                        RegistrerPatient();
                        break;
                    case "2":
                        StopBackgroundMusic();
                        VisPatientliste();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ugyldigt valg. Prøv igen.");
                        break;
                }
            }
        }

        private void RegistrerPatient()
        {
            Console.Clear();
            Console.WriteLine("Indtast patientens oplysninger:");
            Console.Write("Fornavn: ");
            string forNavn = Console.ReadLine();
            Console.Write("Efternavn: ");
            string efterNavn = Console.ReadLine();
            Console.Write("Telefonnummer: ");
            string telefonNummer = Console.ReadLine();

            Console.WriteLine("Vælg en tildelt læge:");
            for (int i = 0; i < læger.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {læger[i].ForNavn} {læger[i].EfterNavn} ({læger[i].Specialle})");
            }
            int lægeValg = int.Parse(Console.ReadLine()) - 1;

            try
            {
                Læge valgtLæge = læger[lægeValg];
                Patient nyPatient = new Patient(forNavn, efterNavn, telefonNummer);
                nyPatient.TildelLæge(valgtLæge);
                patienter.Add(nyPatient);
                Console.WriteLine("Patienten er blevet registreret.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fejl: {ex.Message}");
            }
        }

        private void VisPatientliste()
        {
            Console.Clear();
            Console.WriteLine("Patientliste:");

            foreach (var patient in patienter)
            {
                Console.WriteLine($"{patient.ForNavn} {patient.EfterNavn}, Telefon: {patient.TelefonNummer}");
                Console.Write("Tildelte læger: ");

                foreach (var læge in patient.TildeltLæger)
                {
                    Console.Write($"{læge.ForNavn} {læge.EfterNavn} ({læge.Specialle}), ");
                }

                Console.WriteLine();
            }

            Console.WriteLine("Tryk på en vilkårlig tast for at vende tilbage til menuen");
            Console.ReadKey();
        }

        private void StopBackgroundMusic()
        {
            // Stop baggrundsmusik
            lydAfspiller.StopBackgroundMusic();
        }
    }
}
