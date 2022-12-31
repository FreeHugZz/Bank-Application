namespace Bank
{
    internal class Program
    {
        public static string currentUser;
        public static string[] currentAccountNames;
        public static double[] currentBalance;
        public static int currentPassword;


        static void Main(string[] args)
        {

            // För att logga in skriv "Name" som förnamn och "Password".
            // Note: Gick över till Nested Arrays istälet för List, vilket gjorde det hela lite mer färgfullt och klurigt.

            Coustomers[] customers = new Coustomers[]
            {
                new Coustomers
                {
                    Name = "Sara",
                    LastName = "Andersson",
                    Password = 123,
                    AccountNames = new []{"Lönekonto", null, "Pesionskonto"},
                    Balances  = new Double [] { 1000.46, 0 , 2000.00},

                },
                new Coustomers
                {
                    Name = "Rudi",
                    LastName = "Pedersen",
                    Password = 456,
                    AccountNames = new []{"Lönekonto", "Sparkonto", "Pensionskonto"},
                    Balances = new double[] { 74.893729 , 15000 , 220.98},

                },
                  new Coustomers
                {
                    Name = "Hussain",
                    LastName = "Jacob",
                    Password = 789,
                    AccountNames = new []{null, "Sparkonto", "Pesionskonto"},
                    Balances  = new Double [] { 0, 100 , 2000.00},

                },
                    new Coustomers
                {
                    Name = "Sara",
                    LastName = "Svensson",
                    Password = 103,
                    AccountNames = new []{"Lönekonto", null, "Pesionskonto"},
                    Balances  = new Double [] { 1000.46, 0 , 2000.13},

                },
                      new Coustomers
                {
                    Name = "Ingrid",
                    LastName = "Olsson",
                    Password = 5252,
                    AccountNames = new []{"Lönekonto", "Sparkonto", "Pesionskonto"},
                    Balances  = new Double [] { 1000.46, 50 , 1000.00},

                }

            };

            //****************Inloggningen börjar här*****************

            Console.WriteLine("\nVälkommen till din bank.\n");

        logIn:
            bool statement = true;

            // Loopar tills användaren skriver in rätt namn och lösenord.
            while (statement == true)
            {
                //Kollar om användaren anger rätt uppgifter med rätt format
                try
                {
                    Console.WriteLine("\nVänligen ange dina användaruppgifter för att logga in på in bank!\n");
                    Console.WriteLine("Ditt förnamn: ");
                    string nameInput = Console.ReadLine();

                    Console.WriteLine("Ditt lösenord: ");
                    int passInput = int.Parse(Console.ReadLine());

                    // Kollar om användaren finns i arrayen
                    foreach (var i in customers)
                    {

                        // kollar om inloggningen är korrekt
                        if (i.Name.Equals(nameInput, StringComparison.CurrentCultureIgnoreCase) && i.Password == passInput)
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("\nInloggningen lyckades och du är nu inloggad.\n\n");
                            Console.BackgroundColor = ConsoleColor.Black;
                            currentUser = i.Name;
                            currentBalance = i.Balances;
                            currentAccountNames = i.AccountNames;
                            currentPassword = i.Password;
                            statement = false;
                            break;
                        }
                        else
                        {
                            // Om inloggningen misslyckas

                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInloggning misslyckades, försök igen!");
                            Console.BackgroundColor = ConsoleColor.Black;

                            statement = true;
                        }
                    }
                }
                catch (FormatException e)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nInloggningen misslyckades på grund av format fel matades in.");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n\n" + e.Message + "n");
                }

            }

            //****************Inloggningen avslutas här*****************


            //*****************Huvudmenyn börjar här********************

            bool done = false;
            do
            {
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Välj följande alternativ(Tryck 0 - 4):\n");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("1. Se dina konton och saldo");
                Console.WriteLine("2. Överföring mellan konton");
                Console.WriteLine("3. Ta ut pengar");
                Console.WriteLine("4. Logga ut");
                Console.WriteLine("Ange ditt val(Tryck 0 för Avsluta):");

                string strSelection = Console.ReadLine();
                int nrSelect;
                try
                {
                    nrSelect = int.Parse(strSelection);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n\nVänligen ange rätt nummer och format. Försök igen.\n\n");
                    continue;
                }
                Console.Clear();

                //*****************************************************************************

                try
                {

                    //Menu val för kund
                    switch (nrSelect)
                    {

                        case 0:
                            done = true;
                            break;
                        case 1:
                            // Visar konton och saldo

                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("\nÖversikt över dina konton och saldon:\n");
                            Console.BackgroundColor = ConsoleColor.Black;

                            // Skriver ut konto översikt för inloggad kund.
                            // Jämnför två arrays för att skriva ut rätt konto namn och saldo.
                            if (currentAccountNames.Length == currentBalance.Length)
                            {

                                for (int i = 0; i < currentAccountNames.Length; i++)
                                {
                                    if (currentAccountNames[i] != null || currentBalance[i] != 0)
                                        Console.WriteLine($"{i}. {currentAccountNames[i]}: {Math.Round(currentBalance[i], 2)} kr");
                                }
                            }

                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"\nTryck ENTER för att komma till huvudmenyn igen.");
                            Console.BackgroundColor = ConsoleColor.Black;
                            while (Console.ReadKey().Key != ConsoleKey.Enter)
                            {
                                // Förhindrar användaren att skriva i consolen förutom ENTER knappen.
                                Console.Write("\b \b");
                            }
                            Console.Clear();
                            break;


                        case 2:

                            // Överföring mellan konton

                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Clear();

                        // GoTo "HashTag" för att börjar om vid felaktig inmatning
                        loopAgain:

                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("\nÖverföring mellan konton\n");
                            Console.BackgroundColor = ConsoleColor.Black;

                            // Visuellt lista av konton att välja mellan.
                            // Åter igen jämnför två arrays för att skriva ut rätt konto namn och saldo.
                            if (currentAccountNames.Length == currentBalance.Length)
                            {

                                for (int i = 0; i < currentAccountNames.Length; i++)
                                {
                                    if (currentAccountNames[i] != null || currentBalance[i] != 0)
                                        Console.WriteLine($" {i}. {currentAccountNames[i]}: {Math.Round(currentBalance[i], 2)} kr");
                                }

                            }

                            // ***********************************************************

                            int firstAccountInput;
                            int secoundAccountInput;
                            double amount = 0;

                            // Frågar användaren vilket konto hen vill överföra ifrån

                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("\nVälj ett konto Att överföra från(tryck 0-2)");
                            Console.BackgroundColor = ConsoleColor.Black;
                            firstAccountInput = Int32.Parse(Console.ReadLine());
                            Console.BackgroundColor = ConsoleColor.DarkBlue;

                            // Frågar användaren vilket konto hen vill överföra till

                            Console.WriteLine("\nVälj ett konto att överföra till (tryck 0-2)");
                            Console.BackgroundColor = ConsoleColor.Black;
                            secoundAccountInput = Int32.Parse(Console.ReadLine());
                            Console.BackgroundColor = ConsoleColor.DarkBlue;

                            // Frågar användaren hur mycket hen vill överföra

                            Console.WriteLine("\nHur mycket vill du överföra?");
                            Console.BackgroundColor = ConsoleColor.Black;
                            amount = double.Parse(Console.ReadLine());


                            for (int i = 0; i < currentBalance.Length; i++)
                            {

                                // Kontrollerar om användaren har tillräckligt med pengar och annat på kontot
                                if (firstAccountInput == 0 && currentBalance[0] > amount && currentBalance[firstAccountInput] != 0 && currentBalance[secoundAccountInput] != 0 && firstAccountInput != secoundAccountInput && amount > 0)
                                {
                                    //Tar bort pengar från kontot
                                    currentBalance[firstAccountInput] -= amount;
                                    //Lägger till pengar på kontot
                                    currentBalance[secoundAccountInput] += amount;

                                    break;

                                }
                                else
                                if (firstAccountInput == 1 && currentBalance[1] > amount && currentBalance[firstAccountInput] != 0 && currentBalance[secoundAccountInput] != 0 && firstAccountInput != secoundAccountInput && amount > 0)
                                {
                                    //Tar bort pengar från kontot
                                    currentBalance[firstAccountInput] -= amount;
                                    //Lägger till pengar på kontot
                                    currentBalance[secoundAccountInput] += amount;

                                    break;

                                }
                                else
                                if (firstAccountInput == 2 && currentBalance[2] > amount && currentBalance[firstAccountInput] != 0 && currentBalance[secoundAccountInput] != 0 && firstAccountInput != secoundAccountInput && amount > 0)
                                {
                                    //Tar bort pengar från kontot
                                    currentBalance[firstAccountInput] -= amount;
                                    //Lägger till pengar på kontot
                                    currentBalance[secoundAccountInput] += amount;

                                    break;

                                }
                                else
                                {
                                    //Om användaren inte har tillräckligt med pengar eller felaktig inmatning
                                    Console.Clear();
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nAntingen finns det ingen täckning på kontot, eller har du mattat in fel konto nummer.\n");
                                    Console.BackgroundColor = ConsoleColor.Black;

                                    Console.BackgroundColor = ConsoleColor.Black;

                                    //Går tillbaka till början av denna metod/"HashTag" för att börja om.
                                    goto loopAgain;
                                }


                            }

                            //Visar uppdaterad lista efter tranakstioner / överföringar

                            if (currentAccountNames.Length == currentBalance.Length)
                            {
                                Console.Clear();
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("\nÖverförningen genomfördes, här är de nya saldon:\n");
                                Console.BackgroundColor = ConsoleColor.Black;
                                for (int i = 0; i < currentAccountNames.Length; i++)
                                {
                                    // Skriver ut kontonamn och saldo
                                    if (currentAccountNames[i] != null)
                                    {

                                        Console.WriteLine($" {currentAccountNames[firstAccountInput]}: {Math.Round(currentBalance[firstAccountInput], 2)} kr");

                                        Console.WriteLine($" {currentAccountNames[secoundAccountInput]}: {Math.Round(currentBalance[secoundAccountInput], 2)} kr");
                                        break;
                                    }
                                }


                            }
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"\nTryck ENTER för att komma till huvudmenyn igen.");
                            Console.BackgroundColor = ConsoleColor.Black;
                            while (Console.ReadKey().Key != ConsoleKey.Enter)
                            {
                                //Förhindrar användaren att skriva i consolen förutom ENTER knappen.
                                Console.Write("\b \b");
                            }
                            Console.Clear();

                            break;
                        case 3:
                            //Ta ut pengar

                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("\nTa ut pengar\n");
                            Console.BackgroundColor = ConsoleColor.Black;

                            //Visar användaren vilka konton hen har

                            if (currentAccountNames.Length == currentBalance.Length)
                            {

                                for (int i = 0; i < currentAccountNames.Length; i++)
                                {
                                    if (currentAccountNames[i] != null || currentBalance[i] != 0)
                                        Console.WriteLine($" {i}. {currentAccountNames[i]}: {Math.Round(currentBalance[i], 2)} kr");
                                }


                            }
                            // Frågar användaren vilket konto hen vill ta ut pengar ifrån
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("\n\nVälj ett konto att ta ut pengar ifrån?");
                            Console.BackgroundColor = ConsoleColor.Black;
                            int input = int.Parse(Console.ReadLine());

                            // Frågar användaren hur mycket hen vill ta ut
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("\nVälj hur mycket du vill ta ut?");
                            Console.BackgroundColor = ConsoleColor.Black;
                            double amountInput = double.Parse(Console.ReadLine());

                            // Bekräftar transaktionen med lösenord
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("\nAnge ditt lösenord för bekräftelse");
                            Console.BackgroundColor = ConsoleColor.Black;
                            int passwordinput = int.Parse(Console.ReadLine());

                            // Kontrollerar om användaren har tillräckligt med pengar och annat på kontot
                            if (currentAccountNames.Length == currentBalance.Length && passwordinput == currentPassword && currentBalance[input] >= amountInput && amountInput > 0)
                            {
                                // Tar bort pengar från kontot
                                currentBalance[input] -= amountInput;
                                Console.BackgroundColor = ConsoleColor.DarkGreen;

                                // Visar användaren hur mycket pengar hen har kvar på kontot
                                Console.WriteLine("\nBekräftad uttag");
                                Console.WriteLine("\nDitt nya saldo på det kontot är: " + Math.Round(currentBalance[input], 2));
                                Console.BackgroundColor = ConsoleColor.Black;

                            }


                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"\nTryck ENTER för att komma till huvudmenyn igen.");
                            Console.BackgroundColor = ConsoleColor.Black;
                            while (Console.ReadKey().Key != ConsoleKey.Enter)
                            {
                                //Förhindrar användaren att skriva i consolen förutom ENTER knappen.
                                Console.Write("\b \b");
                            }


                            break;
                        case 4:

                            // Användaren loggar ut
                            Console.WriteLine("\nDu har nu loggats ut.");

                            // Går tillbaka till huvudmenyn
                            goto logIn;
                            break;

                        default:

                            // Om användaren matar in ett felaktigt värde
                            Console.WriteLine("You selected an invalid number: {0}\r\n", nrSelect);
                            continue;

                    }

                    Console.WriteLine();

                }
                catch (Exception e)
                {
                    Console.WriteLine("\n\n" + e.Message + "\n\n");
                }

                //*********************************Try catch for switch END**************

            } while (!done);

            Console.WriteLine("\nVälkommen åter!");

        }// Main avslut

    }
}