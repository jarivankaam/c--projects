namespace azaribank
{
    class Program
    {
        // Declare BankAccount instance at class level
        private static BankAccount account;

        static void Main(string[] args)
        {
            bool running = true;
            while (running == true)
            {
                Console.WriteLine("Welcome to the Azari banking system");
                Console.WriteLine("Make a choice:");
                Console.WriteLine("1. Create an account");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw money");
                Console.WriteLine("4. Check balance");
                Console.WriteLine("5. Exit");
                int operation = Convert.ToInt16(Console.ReadLine());

                // Define methods inside Main
                string CreateAccount(string name, int deposit)
                {
                    account = new BankAccount(name, deposit); // Assign to the class-level variable
                    return $"Bank account created successfully for: {account.AccountHolder} with an initial deposit of ${account.Balance},-";
                }

                string DepositMoney(decimal depositAmount)
                {
                    if (account != null)
                    {
                        account.Deposit(depositAmount);
                        return $"Deposited ${depositAmount} successfully. New balance: ${account.Balance}.";
                    }
                    return "No account found. Please create an account first.";
                }

                string WithdrawMoney(decimal withdrawAmount)
                {
                    if (account != null)
                    {
                        account.Withdraw(withdrawAmount);
                        return $"Withdrew ${withdrawAmount} succesfully. New balanca: ${account.Balance}";
                    }

                    return "No account found. Please create an account first";
                }

                switch (operation)
                {
                    case 1:
                        Console.WriteLine("Creating an account");
                        Console.WriteLine("What's your name?");
                        string name = Console.ReadLine();
                        Console.WriteLine("How much do you want to deposit?");
                        int deposit = Convert.ToInt16(Console.ReadLine());
                        string result = CreateAccount(name, deposit);
                        Console.WriteLine(result);
                        break;

                    case 2:
                        Console.WriteLine("How much would you like to deposit?");
                        decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                        string depositResult = DepositMoney(depositAmount);
                        Console.WriteLine(depositResult);
                        break;

                    case 3:
                        Console.WriteLine("How much would you like to withdraw?");
                        decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                        string withdrawResult = WithdrawMoney(withdrawAmount);
                        Console.WriteLine(withdrawResult);
                        break;

                    case 4:
                        if (account != null)
                        {
                            Console.WriteLine($"Current balance: ${account.Balance}");
                        }
                        else
                        {
                            Console.WriteLine("No account found. Please create an account first.");
                        }
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

            // Method to deposit money
            public void Deposit(decimal amount)
            {
                Balance += amount;
            }

            public void Withdraw(decimal amount)
            {
                Balance -= amount;
            }
        }
    }
}
