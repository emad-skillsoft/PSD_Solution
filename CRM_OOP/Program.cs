using System.Reflection;

namespace CRM_OOP
{
    internal class Program
    {
        static List<Customer> customers = new List<Customer>(); 
        static void Main(string[] args)
        {
            do
            {

                try
                {
                    Console.Clear();
                    Console.WriteLine("Welcome To PSD Customer Service V1");
                    Console.WriteLine("==================================");
                    Console.WriteLine("1) Add Customer");
                    Console.WriteLine("2) Display Customers");
                    Console.WriteLine("3) Delete Customer");
                    Console.WriteLine("4) Update Customer");
                    Console.WriteLine("5) Exit");
                    Console.WriteLine("===============================");
                    Console.Write("Select an Option (1-5): ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Customer obj = new Customer();
                            obj.Id = customers.Count + 1;

                            Console.Write("Please type your name: ");
                            obj.Name = Console.ReadLine();

                            Console.Write("Please type your Age: ");
                            obj.Age = int.Parse(Console.ReadLine());


                            Console.Write("Please type your Mobile Number: ");
                            obj.Mobile= Console.ReadLine();

                            customers.Add(obj);


                            Console.WriteLine("Done Adding New Customer ...");
                            break;
                        case 2:
                            Console.WriteLine("Customers List");
                            Console.WriteLine("===============");
                            foreach (Customer custObj in customers)
                            {
                                Console.WriteLine($"ID: {custObj.Id}");
                                Console.WriteLine($"Name: {custObj.Name}");
                                Console.WriteLine($"Age: {custObj.Age}");
                                Console.WriteLine($"Mobile Number: {custObj.Mobile}");
                                Console.WriteLine("-----------------------------------");

                            }
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
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
