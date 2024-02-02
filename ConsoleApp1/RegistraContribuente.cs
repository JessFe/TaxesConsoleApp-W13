using System;
using System.Threading;

namespace ConsoleApp1
{
    public static class RegistraContribuente
    {
        public static void ProcessoRegistrazione()
        {
            // INSERIMENTO NOME
            //  + controllo lunghezza
            string nome = "";
            do
            {
                Console.WriteLine("\nInserisci il tuo nome:");
                nome = Console.ReadLine();
                nome = PrimaLettMaiusc(nome);
                if (nome.Length < 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Il nome deve avere almeno 3 lettere.");
                    Console.ResetColor();
                }
            } while (nome.Length < 3);

            // INSERIMENTO COGNOME
            //  + controllo lunghezza
            string cognome = "";
            do
            {
                Console.WriteLine("\nInserisci il tuo cognome:");
                cognome = Console.ReadLine();
                cognome = PrimaLettMaiusc(cognome);
                if (cognome.Length < 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Il cognome deve avere almeno 2 lettere.");
                    Console.ResetColor();
                }
            } while (cognome.Length < 2);

            // INSERIMENTO DATA DI NASCITA
            //  + controllo formato
            DateTime dataNascita;
            while (true)
            {
                Console.WriteLine("\nInserisci la tua data di nascita (dd/mm/yyyy):");
                if (DateTime.TryParse(Console.ReadLine(), out dataNascita))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Formato data non valido.");
                    Console.ResetColor();
                }
            }

            // INSERIMENTO CODICE FISCALE
            //  + controllo lunghezza
            string codiceFiscale = "";
            do
            {
                Console.WriteLine("\nInserisci il tuo codice fiscale:");
                codiceFiscale = Console.ReadLine();
                codiceFiscale = codiceFiscale.ToUpper();
                if (codiceFiscale.Length != 16)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Il codice fiscale deve essere di 16 caratteri.");
                    Console.ResetColor();
                }
            } while (codiceFiscale.Length != 16);

            // INSERIMENTO SESSO
            //  + controllo dato ricevuto
            string sesso = "";
            do
            {
                Console.WriteLine("\nInserisci il tuo sesso (M/F):");
                sesso = Console.ReadLine().ToUpper();
                if (sesso != "M" && sesso != "F")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sesso non valido. Inserire M o F.");
                    Console.ResetColor();
                }
            } while (sesso != "M" && sesso != "F");

            // INSERIMENTO RESIDENZA
            //  + controllo lunghezza
            string comuneResidenza = "";
            do
            {
                Console.WriteLine("\nInserisci il tuo comune di residenza:");
                comuneResidenza = Console.ReadLine();
                comuneResidenza = PrimaLettMaiusc(comuneResidenza);
                if (comuneResidenza.Length < 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Il comune di residenza deve avere almeno 2 caratteri.");
                    Console.ResetColor();
                }
            } while (comuneResidenza.Length < 2);

            // INSERIMENTO REDDITO ANNUO
            //  + controllo formato
            double redditoAnnuale;
            while (true)
            {
                Console.WriteLine("\nInserisci il tuo reddito annuale:");
                if (double.TryParse(Console.ReadLine(), out redditoAnnuale))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Reddito annuale non valido. Inserire un numero.");
                    Console.ResetColor();
                }
            }


            // COSTRUTTORE ISTANZA CONTRIBUENTE
            Contribuente contribuente = new Contribuente(nome, cognome, dataNascita, codiceFiscale, sesso, comuneResidenza, redditoAnnuale);


            // MESSAGGI DI CONFERMA INSERIMENTO E AVVIO CALCOLO
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nDati inseriti con successo!");
            Console.ResetColor();

            string message = "Calcolo imposta in corso . . . . . . .";
            foreach (char letter in message)
            {
                Console.Write(letter);
                Thread.Sleep(70);
            }

            Thread.Sleep(700);


            // STAMPA RIEPILOGO DATI E CALCOLO IMPOSTA
            Console.WriteLine(contribuente.RiepilogoImposta());

            Console.WriteLine("\nDigita 1 per tornare al menu principale");
            while (Console.ReadLine() != "1") ;
        }

        // METODO PER CONVERTIRE IN MAIUSCOLO LA PRIMA LETTERA DI OGNI PAROLA
        private static string PrimaLettMaiusc(string input)
        {
            string[] words = input.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                {
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                }
            }

            return string.Join(" ", words);
        }
    }


}
