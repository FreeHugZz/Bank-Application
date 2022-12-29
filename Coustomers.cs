namespace Bank
{
    internal class Coustomers : Program
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Password { get; set; }

        //public int firstAccountInput { get; set; }
        //public int secoundAccountInput { get; set; }


        public string[] AccountNames { get; set; }
        public double[] Balances { get; set; }

        // TODO: move accountname and balance to a separate class
        // see monsters part 3 for how

        // TODO: accountname andd balance are removed as fields here and
        // in their place a new field called Account[] is introduced

        //public string AccountNames { get; set; }
        //public double Balances { get; set; }

        public int Transaction { get; set; }

        public Coustomers()
        {
            this.Name = Name;
            this.LastName = LastName;
            this.Password = Password;
            this.AccountNames = AccountNames;
            this.AccountNames = AccountNames;
            this.Balances = Balances;

        }



        // Constructer för Coustomer Class
        public Coustomers(string name, string lastName, int password, string accountNames, double[] balances)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Password = password;
            this.AccountNames = AccountNames;
            this.Balances = balances;
        }


        // Efter du har byggt din account class flytta nedanstående metod ditt. 


        public string SeeAccount()
        {

            return $"\nKontohavare: {Name} {LastName}\nKontotyp: {AccountNames[0]}: {Balances[0]} kr\n{AccountNames[1]}: {Balances[1]} kr\n{AccountNames[2]}: {Balances[2]} kr)";

        }

        //public string seeAccountUpdate()
        //{
        //    return $"{currentAccountNames[firstAccountInput]}: {currentBalance[firstAccountInput]} kr\n{currentAccountNames[secoundAccountInput]}: {currentBalance[secoundAccountInput]}";
        //}

        //public int x;
        //public int y;
        //public int amount;
        //public double TransferAccounts()
        //{

        //    Console.WriteLine("Välj ett konto Attribute överföra från(tryck 1-3)");
        //    x = Int32.Parse(Console.ReadLine());

        //    for (int i = 0; i < AccountNames.Length; i++)
        //    {
        //        return i = x;
        //    }
        //    Console.WriteLine("x == " + x);
        //    Console.WriteLine("Välj ett konto Attribute överföra från(tryck 1-3)");
        //    Balances[y] = Int32.Parse(Console.ReadLine());
        //    Console.WriteLine("Hur mycket vill du överföra?");
        //    amount = Int32.Parse(Console.ReadLine());




        //    for (int i = 0; i < Balances.Length; i++)
        //    {
        //        return i = y;
        //    }

        //    return Balances[y] += amount;

        //}
        public override string ToString()
        {
            return Name + LastName + Password;
        }
    }
}
