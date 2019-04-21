using System;

namespace PlusOuMoins
{
    public class Program
    {	
        public static void Main()
        {
            bool play = true;
            while (play)
            {
                Game();
                Console.WriteLine("Voulez-vous rejouer ? (taper 'y' pour oui et 'n' pour non");
                bool replayInput = false;

                while (!replayInput)
                {
                    String readPlay = Console.ReadLine();
                    if(readPlay == "n")
                    {
                        Console.WriteLine("Merci d'avoir joué");
                        play = false;
                        replayInput = true;
                    } 
                    else if (readPlay == "y")
                    {
                        replayInput = true;
                    }
                    else 
                    {
                        Error();
                    }
                }
            }
        }

        public static void Game()
        {
            int inf = 0;
            int sup = 0;
            bool intervalInf = false;
            bool intervalSup = false;
            Console.WriteLine("Choisissez l'intervalle souhaité (ex : 0 et 100)");
            while (!intervalInf)
            {
                Console.WriteLine("Saisissez la borne inférieure");
                String readInf = Console.ReadLine();
                if(!int.TryParse(readInf, out inf)) 
                {
                    Error();
                }
                else 
                {
                    int.TryParse(readInf, out inf);
                    intervalInf = true;
                }
            }
            while (!intervalSup)
            {
                Console.WriteLine("Saisissez la borne supérieure");
                String readSup = Console.ReadLine();
                if(!int.TryParse(readSup, out sup)) 
                {
                    Error();
                } 
                else 
                {
                    int.TryParse(readSup, out sup);
                    intervalSup = true;
                }
            }
            Console.WriteLine("La partie commence...");
            int guessValue = new Random().Next(inf, sup);
            bool found = false;
            int attempt = 0;

            while (!found)
            {
                Console.WriteLine("Saisissez un nombre compris entre " + inf + " et " + sup);
                String readInput = Console.ReadLine();
                int input;
                if(int.TryParse(readInput, out input) && input >= inf && input <= sup) {
                    if (input == guessValue)
                    {
                        found = true;
                    } 
                    else 
                    {
                        if (input > guessValue)
                        {
                            Console.WriteLine("Plus petit");
                        } 
                        else 
                        {
                            Console.WriteLine("Plus grand");
                        }
                    }
                    attempt++;
                }
                else 
                {
                    Error();
                }
            }
            if(attempt > 1) 
            {
                Console.WriteLine("Trouvé en " + attempt + " coups, le nombre était " + guessValue);
            }
            else 
            {
                Console.WriteLine("Trouvé en " + attempt + " coup, le nombre était " + guessValue);
            }
        }

        public static void Error() 
        {
            Console.WriteLine("Erreur de saisie veuillez réssayer");
        }
    }
}