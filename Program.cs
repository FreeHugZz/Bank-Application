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
            Coustomers[] customers = new Coustomers[]
            {
                new Coustomers
                {
                    Name = "Lolita",
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


            //for (int i = 0; i < customers.Length; i++)
            //{
            //    Console.WriteLine("************");
            //    for (var j = 0; j < customers[i].AccountNames.Length; j++)
            //    {
            //        if (customers[i].Balances[j] != 0)
            //        {
            //            Console.WriteLine("Accounts: " + customers[i].AccountNames[j] + ": " + customers[i].Balances[j]);
            //        }

            //    }
            //}

            //****************Inloggningen börjar här*****************
            Console.WriteLine("\nVälkommen till världens bästa bank.\n");
        logIn:
            bool statement = true;

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


                    foreach (var i in customers)
                    {
                        //inloggning lyckas eller inte
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
                Console.Write("Ange ditt val(Tryck 0 för Avsluta): ");

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
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("\nÖversikt över dina konton och saldon:\n");
                            Console.BackgroundColor = ConsoleColor.Black;

                            //Skriver ut kontoöversikt för just inloggad kund. 
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
                                //Förhindrar användaren att skriva i consolen förutom ENTER knappen.
                                Console.Write("\b \b");
                            }
                            Console.Clear();
                            break;


                        case 2:
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Clear();
                        loopAgain:
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("\n\nÖverföring mellan konton\n\n");
                            Console.BackgroundColor = ConsoleColor.Black;
                            //Lista av konton att välja mellan. 
                            if (currentAccountNames.Length == currentBalance.Length)
                            {

                                for (int i = 0; i < currentAccountNames.Length; i++)
                                {
                                    if (currentAccountNames[i] != null || currentBalance[i] != 0)
                                        Console.WriteLine($" {i}. {currentAccountNames[i]}: {Math.Round(currentBalance[i], 2)} kr");
                                }


                            }

                            //***********************************************************

                            int firstAccountInput;
                            int secoundAccountInput;
                            double amount = 0;


                            //if (currentAccountNames.Length == currentBalance.Length)
                            //{



                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("\nVälj ett konto Att överföra från(tryck 0-2)");
                            Console.BackgroundColor = ConsoleColor.Black;
                            firstAccountInput = Int32.Parse(Console.ReadLine());
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("\nVälj ett konto att överföra till (tryck 0-2)");
                            Console.BackgroundColor = ConsoleColor.Black;
                            secoundAccountInput = Int32.Parse(Console.ReadLine());
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("Hur mycket vill du överföra?");
                            Console.BackgroundColor = ConsoleColor.Black;
                            amount = double.Parse(Console.ReadLine());


                            for (int i = 0; i < currentBalance.Length; i++)
                            {
                                //Console.WriteLine("i ärrrr:" + currentBalance[i]);
                                //if (currentAccountNames[i] != null || currentBalance[i] != 0)

                                //    Console.WriteLine("Välj ett konto Att överföra från(tryck 0-2)");
                                //firstAccountInput = Int32.Parse(Console.ReadLine());
                                //Console.WriteLine("Välj ett konto Att överföra från(tryck 0-2)");
                                //secoundAccountInput = Int32.Parse(Console.ReadLine());
                                //Console.WriteLine("Hur mycket vill du överföra?");
                                //amount = double.Parse(Console.ReadLine());

                                if (firstAccountInput == 0 && currentBalance[0] > amount && currentBalance[firstAccountInput] != 0 && currentBalance[secoundAccountInput] != 0 && firstAccountInput != secoundAccountInput && amount > 0)
                                {
                                    //Console.WriteLine("inne 0" + currentBalance[i]);
                                    currentBalance[firstAccountInput] -= amount;
                                    currentBalance[secoundAccountInput] += amount;
                                    //Console.WriteLine("i 0 ärrrr: " + currentBalance[i] + "\n firstAccountInput: " + firstAccountInput + "\n amount:" + amount + "\n currentBalance[firstAccountInput] " + currentBalance[firstAccountInput] + "\n currentBalance[secoundAccountInput]: " + currentBalance[secoundAccountInput]);
                                    break;

                                }
                                else
                                if (firstAccountInput == 1 && currentBalance[1] > amount && currentBalance[firstAccountInput] != 0 && currentBalance[secoundAccountInput] != 0 && firstAccountInput != secoundAccountInput && amount > 0)
                                {
                                    //Console.WriteLine("inne 1");
                                    currentBalance[firstAccountInput] -= amount;
                                    currentBalance[secoundAccountInput] += amount;

                                    //Console.WriteLine("i 1 ärrrr:" + currentBalance[i]);
                                    //Console.WriteLine($"{i}. {currentAccountNames[firstAccountInput]}: {currentBalance[firstAccountInput]} kr");
                                    //Console.WriteLine($"{i}. {currentAccountNames[secoundAccountInput]}: {currentBalance[secoundAccountInput]} kr");
                                    break;

                                }
                                else
                                if (firstAccountInput == 2 && currentBalance[2] > amount && currentBalance[firstAccountInput] != 0 && currentBalance[secoundAccountInput] != 0 && firstAccountInput != secoundAccountInput && amount > 0)
                                {

                                    currentBalance[firstAccountInput] -= amount;
                                    currentBalance[secoundAccountInput] += amount;

                                    break;

                                }
                                else
                                {
                                    Console.Clear();
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nAntingen finns det ingen täckning på kontot, eller har du mattat in fel konto nummer.\n");
                                    Console.BackgroundColor = ConsoleColor.Black;

                                    Console.BackgroundColor = ConsoleColor.Black;
                                    goto loopAgain;
                                }


                            }

                            //Visar uppdaterad ista efter tranakstioner / överföringar
                            if (currentAccountNames.Length == currentBalance.Length)
                            {
                                Console.Clear();
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("\nÖverförningen genomfördes, här är de nya saldon:\n");
                                Console.BackgroundColor = ConsoleColor.Black;
                                for (int i = 0; i < currentAccountNames.Length; i++)
                                {
                                    if (currentAccountNames[i] != null)
                                    {
                                        //Console.WriteLine($"{currentBalance[firstAccountInput]}{currentBalance[secoundAccountInput]}");
                                        Console.WriteLine($" {currentAccountNames[firstAccountInput]}: {Math.Round(currentBalance[firstAccountInput], 2)} kr");
                                        //Console.WriteLine($" {currentAccountNames[firstAccountInput]}: {currentBalance[firstAccountInput]} kr");
                                        //Console.WriteLine($" {currentAccountNames[secoundAccountInput]}: {currentBalance[secoundAccountInput]} kr");
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
                            //}
                            ////Visar uppdaterad ista efter tranakstioner / överföringar
                            //if (currentAccountNames.Length == currentBalance.Length)
                            //{
                            //    Console.WriteLine("\nÖverförningen genomfördes, här en översikt över dina konton:\n");
                            //    for (int i = 0; i < currentAccountNames.Length; i++)
                            //    {
                            //        if (currentAccountNames[i] != null)
                            //        {
                            //            //Console.WriteLine($"{currentBalance[firstAccountInput]}{currentBalance[secoundAccountInput]}");
                            //            Console.WriteLine($"{i}. {currentAccountNames[i]}: {currentBalance[i]} kr");

                            //        }
                            //    }


                            //}


                            break;
                        case 3:
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("\nTa ut pengar\n");
                            Console.BackgroundColor = ConsoleColor.Black;
                            //Lista av konton att välja mellan. 
                            if (currentAccountNames.Length == currentBalance.Length)
                            {

                                for (int i = 0; i < currentAccountNames.Length; i++)
                                {
                                    if (currentAccountNames[i] != null || currentBalance[i] != 0)
                                        Console.WriteLine($" {i}. {currentAccountNames[i]}: {Math.Round(currentBalance[i], 2)} kr");
                                }


                            }


                            Console.WriteLine("\n\nVälj ett konto att ta ut pengar ifrån?");
                            int input = int.Parse(Console.ReadLine());


                            Console.WriteLine("\nVälj hur mycket du vill ta ut?");
                            double amountInput = double.Parse(Console.ReadLine());

                            Console.WriteLine("\nVäligen ange ditt lösenord för bekräftelse");
                            int passwordinput = int.Parse(Console.ReadLine());

                            if (currentAccountNames.Length == currentBalance.Length && passwordinput == currentPassword && currentBalance[input] >= amountInput && amountInput > 0)
                            {
                                currentBalance[input] -= amountInput;
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Bekräftad uttag");
                                Console.WriteLine("\nDitt nya saldo är: " + Math.Round(currentBalance[input], 2));
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

                            //for (int i = 0; i < currentBalance.Length; i++)
                            //{
                            //    Console.WriteLine("äärr" + currentBalance[input]);
                            //}

                            //public double[] currentAccount = currentBalance[accountChoice];

                            //amount = 0;
                            //Console.WriteLine("Välj hur mycket du vill ta ut?");
                            //string input2 = Console.ReadLine();
                            //amount = double.Parse(input2);
                            //Console.WriteLine("Väligen ange ditt lösenord för bekräftelse");
                            //string input3 = Console.ReadLine();
                            //int passwordinput = int.Parse(input3);

                            //if (currentAccountNames.Length == currentBalance.Length)
                            //{
                            //    //Console.Clear();
                            //    //Console.BackgroundColor = ConsoleColor.DarkGreen;
                            //    //Console.WriteLine("\nÖverförningen genomfördes, här är de nya saldon:\n");
                            //    //Console.BackgroundColor = ConsoleColor.Black;
                            //    for (int i = 0; i < currentAccountNames.Length; i++)
                            //    {
                            //        if (currentAccountNames[i] != null)
                            //        {
                            //            //Console.WriteLine($"{currentBalance[firstAccountInput]}{currentBalance[secoundAccountInput]}");
                            //            Console.WriteLine($" {currentAccountNames[(int)currentAccount]}: {currentBalance[(int)amount]} kr");
                            //            //Console.WriteLine($" {currentAccountNames[secoundAccountInput]}: {currentBalance[secoundAccountInput]} kr");
                            //            break;
                            //        }
                            //    }


                            //}

                            //********************************************************************

                            //if (/*string.IsNullOrEmpty(input) && */accountChoice < 3 && accountChoice >= 0 && passwordinput == currentPassword)
                            //{
                            //    Console.WriteLine("inne i if");
                            //    //var currentAccount = currentBalance[(int)accountChoice];
                            //    for (int i = 0; i < currentAccount; i++)
                            //    {

                            //    }

                            //    if (currentAccount >= amount)
                            //    {
                            //        currentAccount -= amount;
                            //        Console.BackgroundColor = ConsoleColor.DarkGreen;


                            //        Console.WriteLine("Ditt nya saldo: " + currentAccount);

                            //    }
                            //    else
                            //    {
                            //        Console.WriteLine("Du har ingen täckning på konto");
                            //    }

                            //}

                            //********************************************************************


                            //for (var i = 0; i < currentBalance.Length; i++)
                            //{
                            //    var B = currentBalance[(int)takeOutMoneyfromAccount];
                            //    Console.WriteLine(currentBalance[i]);
                            //}
                            //***********************************************************
                            break;
                        case 4:
                            Console.WriteLine("\nDu har nu loggats ut.");
                            goto logIn;
                            break;
                        default:
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

            Console.WriteLine("\nGoodbye!");

        }// Main avslut



        //****************Coustomers Class börjar här****************
        //public class Coustomers
        //{
        //public string Name { get; set; }
        //public string LastName { get; set; }
        //public int Password { get; set; }


        //public string[] AccountNames { get; set; }
        //public double[][] Balances = new double[3][];

        //// TODO: move accountname and balance to a separate class
        //// see monsters part 3 for how

        //// TODO: accountname andd balance are removed as fields here and
        //// in their place a new field called Account[] is introduced

        //public string AccountName { get; set; }
        //public double Balance { get; set; }
        //public int Transaction { get; set; }

        //public Coustomers()
        //{
        //    this.Name = Name;
        //    this.LastName = LastName;
        //    this.Password = Password;
        //    this.AccountName = AccountName;
        //    this.Balance = Balance;


        //    this.AccountNames = AccountNames;
        //    this.Balances = Balances;

        //}



        //// Constructer för Coustomer Class
        //public Coustomers(string name, string lastName, int password, string accountName, double[][] balances)
        //{
        //    this.Name = name;
        //    this.LastName = lastName;
        //    this.Password = password;
        //    this.AccountNames = AccountNames;
        //    this.Balances = balances;
        //}


        //// Efter du har byggt din account class flytta nedanstående metod ditt. 


        //public string SeeAccount()
        //{

        //    //return $"\nKontohavare: {Name} {LastName}\nKontotyp: {AccountNames[0]}: {Balances[0]} kr\n{AccountNames[1]}: {Balances[1]} kr\n{AccountNames[2]}: {Balances[2]} kr)";

        //}

        //public override string ToString()
        //{
        //    return Name + LastName + Password;
        //}

        //}
        //****************Coustomers Class Avslut****************




    }
}