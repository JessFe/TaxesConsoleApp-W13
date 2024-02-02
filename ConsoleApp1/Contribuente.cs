using System;

namespace ConsoleApp1
{
    public class Contribuente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public string CodiceFiscale { get; set; }
        public string Sesso { get; set; }
        public string ComuneResidenza { get; set; }
        public double RedditoAnnuale { get; set; }

        public Contribuente(string nome, string cognome, DateTime dataNascita, string codiceFiscale, string sesso, string comuneResidenza, double redditoAnnuale)
        {
            Nome = nome;
            Cognome = cognome;
            DataNascita = dataNascita;
            CodiceFiscale = codiceFiscale;
            Sesso = sesso;
            ComuneResidenza = comuneResidenza;
            RedditoAnnuale = redditoAnnuale;
        }

        // METODO PER STAMPARE IL RIEPILOGO DATI E CALCOLO IMPOSTA
        public string RiepilogoImposta()
        {
            double imposta = CalcolaImposta();

            Console.WriteLine("\n\n----------------------------------------");
            Console.WriteLine(" RIEPILOGO DEI DATI:");
            Console.WriteLine($"  Contribuente: {Nome} {Cognome},");
            Console.WriteLine($"  Sesso: {Sesso},");
            Console.WriteLine($"  Data di nascita: {DataNascita.ToString("dd/MM/yyyy")},");
            Console.WriteLine($"  Codice fiscale: {CodiceFiscale},");
            Console.WriteLine($"  Residente a: {ComuneResidenza},");
            Console.WriteLine($"  Reddito dichiarato: euro {RedditoAnnuale:0.00}.");
            Console.WriteLine("----------------------------------------");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($" IMPOSTA DA VERSARE: euro {imposta:0.00}.");
            Console.ResetColor();

            Console.WriteLine("----------------------------------------");

            return "";
        }

        // METODO PER CALCOLARE L'IMPOSTA DOVUTA
        private double CalcolaImposta()
        {
            if (RedditoAnnuale <= 15000)
            {
                return RedditoAnnuale * 0.23;
            }
            else if (RedditoAnnuale <= 28000)
            {
                return 3450 + (RedditoAnnuale - 15000) * 0.27;
            }
            else if (RedditoAnnuale <= 55000)
            {
                return 6960 + (RedditoAnnuale - 28000) * 0.38;
            }
            else if (RedditoAnnuale <= 75000)
            {
                return 17220 + (RedditoAnnuale - 55000) * 0.41;
            }
            else
            {
                return 25420 + (RedditoAnnuale - 75000) * 0.43;
            }
        }
    }
}