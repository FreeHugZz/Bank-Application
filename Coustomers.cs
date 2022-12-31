namespace Bank
{
    internal class Coustomers
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Password { get; set; }
        public string[] AccountNames { get; set; }
        public double[] Balances { get; set; }


        public int Transaction { get; set; }

        public Coustomers()
        {
            this.Name = Name;
            this.LastName = LastName;
            this.Password = Password;
            this.AccountNames = AccountNames;
            //this.AccountNames = AccountNames;
            this.Balances = Balances;

        }



        // Constructor för att skapa konto
        public Coustomers(string name, string lastName, int password, string accountNames, double[] balances)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Password = password;
            this.AccountNames = AccountNames;
            this.Balances = balances;
        }


        // Metod för att se konto
        public string SeeAccount()
        {

            return $"\nKontohavare: {Name} {LastName}\nKontotyp: {AccountNames[0]}: {Balances[0]} kr\n{AccountNames[1]}: {Balances[1]} kr\n{AccountNames[2]}: {Balances[2]} kr)";

        }

        // Returnerar Balance för vald konto
        public double GetBalance(int accountNumber)
        {
            return Balances[accountNumber];
        }

        // Sätter in pengar på vald konto
        public void AddMoney(int accountNumber, double amount)
        {
            Balances[accountNumber] += amount;
        }

        public override string ToString()
        {
            return Name + LastName + Password;
        }
    }
}
