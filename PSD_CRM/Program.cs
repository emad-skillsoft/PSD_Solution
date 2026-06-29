using System.Collections;

namespace PSD_CRM
{
    internal class Program
    {
        static List<string> fullName=new List<string>();
        static List<int> age = new List<int>();
        static List<char> gender = new List<char>();
        static List<string> mobile =new List<string>();
        static List<bool> isMarried = new List<bool>();
        static List<decimal> salary = new List<decimal>();
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
                            // Get customer name --> string
                            // Get customer age  --> int
                            // Get customer gender --> char
                            // Get customer mobile_number --> string
                            // Get customer is Married --> bool
                            // Get customer salary --> decimal
                            Console.Write("Please type your full name: ");

                            fullName.Add(Console.ReadLine());

                            Console.Write("Please type your age: ");
                            age.Add(int.Parse(Console.ReadLine()));

                            Console.Write("Please type your gender (M,F): ");
                            gender.Add(Console.ReadKey().KeyChar);
                            Console.WriteLine();

                            Console.Write("Please type your Mobile (10 Numbers): ");
                            mobile.Add(Console.ReadLine());


                            Console.Write("Are you Married (Y, N) ");
                            char key = Console.ReadKey().KeyChar;
                            if (key == 'Y')
                            {
                                isMarried.Add(true);
                            }
                            else
                            {
                                isMarried.Add(false);
                            }
                            Console.WriteLine();

                            Console.Write("Please type your Salary: ");
                            salary.Add(decimal.Parse(Console.ReadLine()));

                            break;
                        case 2:
                            Console.WriteLine("=================");
                            Console.WriteLine("Customer List");
                            Console.WriteLine("=================");


                            for (int index = 0; index < fullName.Count; index++)
                            {
                                Console.WriteLine($"Name: {fullName[index]}");
                                Console.WriteLine($"Age: {age[index]}");
                                Console.WriteLine($"Gender: {gender[index]}");
                                Console.WriteLine($"Mobile: {mobile[index]}");
                                Console.WriteLine($"Is Married?: {isMarried[index]}");
                                Console.WriteLine($"Salary: {salary[index]}");
                                Console.WriteLine("=================");
                            }




                            break;
                        case 3:
                            //1)Search for customer name
                            //2) if found: get the array location number, then delete this location from all arrays
                            //3) if nout found: print "customer not found"

                            Console.Write("Please type customer Name: ");
                            string searchValue = Console.ReadLine();

                            bool isFound = false;
                            for (int index = 0; index < fullName.Count; index++)
                            {
                                if (fullName[index] == searchValue)
                                {
                                    isFound = true;

                                    //delete found customer
                                    fullName.RemoveAt(index);
                                    age.RemoveAt(index);
                                    gender.RemoveAt(index);
                                    mobile.RemoveAt(index);
                                    isMarried.RemoveAt(index);
                                    salary.RemoveAt(index);

                                    Console.WriteLine("Done Deleting the customer!");
                                    break;
                                }

                            }
                            if (isFound == false)
                            {
                                Console.WriteLine("Sorry customer not found, try again!");
                            }

                            break;
                        case 4:
                            Console.Write("Please type customer Name: ");
                            searchValue = Console.ReadLine();

                            isFound = false;
                            for (int index = 0; index < fullName.Count; index++)
                            {
                                if (fullName[index] == searchValue)
                                {
                                    isFound = true;

                                    //update customer

                                    Console.Write("Please type your age: ");
                                    age[index] = int.Parse(Console.ReadLine());

                                    Console.Write("Please type your gender (M,F): ");
                                    gender[index] = Console.ReadKey().KeyChar;
                                    Console.WriteLine();

                                    Console.Write("Please type your Mobile (10 Numbers): ");
                                    mobile[index] = Console.ReadLine();


                                    Console.Write("Are you Married (Y, N) ");
                                    key = Console.ReadKey().KeyChar;
                                    if (key == 'Y')
                                    {
                                        isMarried[index] = true;
                                    }
                                    else
                                    {
                                        isMarried[index] = false;
                                    }
                                    Console.WriteLine();

                                    Console.Write("Please type your Salary: ");
                                    salary[index] = decimal.Parse(Console.ReadLine());


                                    Console.WriteLine("Done update the customer!");
                                    break;
                                }

                            }
                            if (isFound == false)
                            {
                                Console.WriteLine("Sorry customer not found, try again!");
                            }
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
