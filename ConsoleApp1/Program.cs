using System;
using System.Threading;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // LOGO E BENVENUTO
            bool runApp = true;
            while (runApp)
            {
                Console.WriteLine("\n========================");
                Console.WriteLine("   E P I - T A X E S   ");
                Console.WriteLine("========================");

                Console.ForegroundColor = ConsoleColor.Cyan;
                string message = "\nBenvenuto/a in EpiTaxes!";
                foreach (char letter in message)
                {
                    Console.Write(letter);
                    Thread.Sleep(70);
                }
                Console.ResetColor();

                Thread.Sleep(500);

                // MENU PRINCIPALE
                Console.WriteLine("\n\nSeleziona:");
                Console.WriteLine("1. Per registrarti come contribuente");
                Console.WriteLine("2. Per uscire");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        RegistraContribuente.ProcessoRegistrazione();
                        break;
                    case "2":
                        runApp = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nScelta non valida. Riprova.");
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}