using System;

namespace PersonalNumberValidatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RunPersonalNumberValidator();
        }

        static void RunPersonalNumberValidator()
        {
            var validator = new PersonalNumberValidator();

            while (true)
            {
                Console.Clear();
                DisplayWelcomeMessage();

                string input = GetUserInput();

                if (IsExitCommand(input))
                {
                    ExitProgram();
                    break;
                }

                ValidateAndDisplayResult(input, validator);

                PromptToContinue();
            }
        }

        
        /// Visar välkomstmeddelande med instruktioner.
        
        static void DisplayWelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=======================================");
            Console.WriteLine("  Välkommen till Personnummer Validerare");
            Console.WriteLine("=======================================");
            Console.ResetColor();
            Console.WriteLine("Skriv ett personnummer i formatet ÅÅÅÅMMDDXXXX.");
            Console.WriteLine("Skriv 'x' för att avsluta programmet.\n");
        }

        
        /// Hämtar användarens inmatning.
        
        static string GetUserInput()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Ange personnummer: ");
            Console.ResetColor();
            return Console.ReadLine();
        }

        /// <summary>
        /// Kontrollerar om användaren vill avsluta programmet.
        /// </summary>
        /// <param name="input">Användarens inmatning.</param>
        /// <returns>True om användaren vill avsluta, annars false.</returns>
        static bool IsExitCommand(string input)
        {
            return input.Trim().ToLower() == "x";
        }

        /// <summary>
        /// Visar avslutningsmeddelande och avslutar programmet.
        /// </summary>
        static void ExitProgram()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n=====================================");
            Console.WriteLine(" Programmet avslutas. Tack för att du använde oss!");
            Console.WriteLine("=====================================");
            Console.ResetColor();
        }

        /// <summary>
        /// Validerar personnumret och visar resultatet.
        /// </summary>
        /// <param name="input">Användarens inmatning.</param>
        /// <param name="validator">Instans av PersonalNumberValidator.</param>
        static void ValidateAndDisplayResult(string input, PersonalNumberValidator validator)
        {
            Console.WriteLine();  // Utrymme för bättre läsbarhet

            if (validator.ValidatePersonalNumber(input))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ Personnumret är giltigt!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Ogiltigt personnummer!");
            }

            Console.ResetColor();
        }

        /// <summary>
        /// Ber användaren att trycka på en tangent för att fortsätta.
        /// </summary>
        static void PromptToContinue()
        {
            Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }
    }
}
