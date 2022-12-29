namespace Bank
{
    public class Accounts
    {
        public string AllAccount { get; set; }
        public double Balances { get; set; }



        public string[] AllAccount1 { get; set; }


        public override string ToString()
        {
            return AllAccount + Balances;
        }



    }
}
