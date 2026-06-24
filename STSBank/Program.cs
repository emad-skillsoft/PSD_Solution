using System.Reflection;

namespace STSBank
{
    internal class Program
    {
        static List<int> id = new List<int>();
        static List<string> fullName = new List<string>();
        static List<char> accountType = new List<char>();
        static List<decimal> balance = new List<decimal>();

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
                            Console.Write("Please type ID: ");
                            id.Add(int.Parse(Console.ReadLine()));



                            Console.Write("Please type your full name: ");
                            fullName.Add(Console.ReadLine());

                            Console.Write("Please type your Account Type (B,P): ");
                            accountType.Add(Console.ReadKey().KeyChar);
                            Console.WriteLine();


                            Console.Write("Please type your Balance: ");
                            balance.Add(decimal.Parse(Console.ReadLine()));

                            break;
                        case 2:
                            Console.WriteLine("=================");
                            Console.WriteLine("Bank Account List");
                            Console.WriteLine("=================");


                            for (int index = 0; index < fullName.Count; index++)
                            {
                                Console.WriteLine($"ID: {id[index]}");
                                Console.WriteLine($"Name: {fullName[index]}");
                                Console.WriteLine($"Account Type: {accountType[index]}");
                                Console.WriteLine($"Balance: {balance[index]}");
                                Console.WriteLine("=================");
                            }

                            break;
                        case 3:
                            

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
