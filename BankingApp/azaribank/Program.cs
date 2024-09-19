namespace azaribank;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        while (running == true)
        {
            Console.WriteLine("Welcome to the Azari banking system");
            Console.WriteLine("Make a choice:");
            Console.WriteLine("1. Create a account");
            Console.WriteLine("2, Deposit Money");
            Console.WriteLine("3. Withdraw money");
            Console.WriteLine("4. Check balance");
            Console.WriteLine("5. Exit");
            int operation = Convert.ToInt16(Console.ReadLine());
            
            string CreateAccount(string name, int deposit)
            {
                BankAccount account = new BankAccount(name, deposit);
                 
                return $"Bank account created succesfully for: {account.AccountHolder} with a initial deposit of ${account.Balance},-";
            }
             
            switch (operation)
            {
                case 1:
                    Console.WriteLine("Creating a account");
                    Console.WriteLine("What's your name?");
                    string name = Console.ReadLine();
                    Console.WriteLine("how much do you want to deposit?");
                    int deposit = Convert.ToInt16(Console.ReadLine());
                    string result = CreateAccount(name, deposit);
                    Console.WriteLine(result);
                    break;
                case 2:
                    //call deposit method
                    break;
                case 3:
                    //call withdraw method
                    break;
                case 4:
                    //call check method
                    break;
                case 5:
                    Console.WriteLine("Goodbye");
                    running = false;
                    break;
            }
        }
    }
    class BankAccount
    {
        // Properties
        public string AccountHolder { get; set; }
        public decimal Balance { get; private set; }

        // Constructor
        public BankAccount(string accountHolder, int initialDeposit)
        {
            AccountHolder = accountHolder;
            Balance = initialDeposit;
        }
    }
}
