using BankAccount_OOP.Models;

namespace BankAccount_OOP
{
    internal class Program
    {
        public static List<BankAccount> bankaccounts=new List<BankAccount>();

        static void Main(string[] args)
        {
            do
            {

                try
                {
                    Console.Clear();
                    Console.WriteLine("===============================");
                    Console.WriteLine("Welcome To STC Bank");
                    Console.WriteLine("===============================");
                    Console.WriteLine("1) Add Bank Account");
                    Console.WriteLine("2) Display Bank Accounts");
                    Console.WriteLine("3) Change Balance");
                    Console.WriteLine("4) Exit");
                    Console.WriteLine("===============================");
                    Console.Write("Select an Option (1-4): ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:

                            BankAccount acc = new BankAccount(0);
                            Console.WriteLine($"New Account Created with id: {acc.AccountID}");

                            Console.Write("Please type your customer full name: ");
                            acc.CustomerName=Console.ReadLine();

                            Console.Write("Please type your Account Type (C,S): ");
                            switch (Char.ToUpper(Console.ReadKey().KeyChar))
                            {
                                case 'C':
                                    acc.AccountType = AccountType.Current;
                                    break;
                                case 'S':
                                    acc.AccountType = AccountType.Saving;
                                    break;
                            }
                            
                            bankaccounts.Add( acc );
                            Console.WriteLine("Done Creating New Account");
                            break;
                        case 2:
                            Console.WriteLine("=================");
                            Console.WriteLine("Bank Account List");
                            Console.WriteLine("=================");


                            foreach(BankAccount account in bankaccounts)
                            {
                                Console.WriteLine($"AccountID: {account.AccountID}");
                                Console.WriteLine($"Name: {account.CustomerName}");
                                Console.WriteLine($"Account Type: {account.AccountType}");
                                Console.WriteLine($"Balance: {account.Balance}");
                                Console.WriteLine("=================");
                            }

                            break;
                        case 3:
                            Console.Write("Please type Account ID: ");
                            int idSearchValue = int.Parse(Console.ReadLine());

                            bool isFound = false;
                            foreach (BankAccount account in bankaccounts)
                            {
                                if (account.AccountID== idSearchValue)
                                {
                                    isFound = true;
                                    Console.WriteLine($"Current Balance: {account.Balance}");

                                    Console.Write("Press (W)Withdraw (D)Deposit: ");
                                    char operation = Console.ReadKey().KeyChar;
                                    Console.WriteLine("");


                                    Console.Write("Amount: ");
                                    decimal amount = decimal.Parse(Console.ReadLine());
                                    
                                    switch (Char.ToUpper(operation))
                                    {
                                        case 'W':
                                            account.Withdraw(amount);
                                            break;
                                        case 'D':
                                            account.Deposit(amount);
                                            break;
                                    }

                                    Console.WriteLine("Done Modifying Balance");
                                }
                            }
                            if (isFound==false)
                            {
                                Console.WriteLine("Sorry, Account Id Not Found .. Please Try again");
                            }

                            break;
                        case 4:
                            Console.WriteLine("Good Bye!");
                            System.Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Sorry, select (1-5)");
                            break;
                    }


                }
                catch (Exception ex)
                {

                    Console.WriteLine($"{ex.Message}");
                    Console.WriteLine("Please Call the administrator!");

                }
                finally
                {
                    Console.WriteLine("Press Any Key To Continue ...");
                    Console.ReadLine();
                }




            } while (true);
        }
    }
}
