using CRM_OOP.Model;
using System.Reflection;

namespace CRM_OOP
{
    internal class Program
    {
        static List<Customer> customers = new List<Customer>(); 
        static List<Complaint> complaints= new List<Complaint>();
        //Comment
        static void Main(string[] args)
        {

            //List<Shape> shapes = new List<Shape>();
            //shapes.Add(new Circle());
            //shapes.Add(new Rectangle());
            //shapes.Add(new Circle());

            //foreach(Shape shape in shapes)
            //{
            //    shape.Draw();
            //}


            do
            {

                try
                {
                    Console.Clear();
                    Console.WriteLine("Welcome To PSD Customer Service V1");
                    Console.WriteLine("==================================");
                    Console.WriteLine("1) Add Customer");
                    Console.WriteLine("2) Display Customers");
                    Console.WriteLine("3) Update Customer");
                    Console.WriteLine("4) Delete Customer");
                    Console.WriteLine("5) Add Compliant");
                    Console.WriteLine("6) Change Complaint Status");
                    Console.WriteLine("7) Settings");
                    Console.WriteLine("8) Exit");
                    Console.WriteLine("===============================");
                    Console.Write("Select an Option (1-8): ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:

                            /* (Block Comment)
                            Customer obj = new Customer();
                            obj.Id = customers.Count + 1;
                            Console.Write("Please type your name: ");
                            obj.Name = Console.ReadLine();
                            Console.Write("Please type your Age: ");
                            obj.Age = int.Parse(Console.ReadLine());
                            Console.Write("Please type your Mobile Number: ");
                            obj.Mobile= Console.ReadLine();
                            customers.Add(obj);
                            */


                            Console.Write("Please type your name: ");
                            string name = Console.ReadLine();
                            Customer obj = new Customer(customers.Count + 1,name);

                            Console.Write("Please type your Age: ");
                            obj.Age = int.Parse(Console.ReadLine());
                            Console.Write("Please type your Mobile Number: ");
                            obj.Mobile = Console.ReadLine();
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

                                // Get Complaints related the customer id
                                Console.Write("Do you like to display Compliants (Y|N): ");
                                char yesnoresult = Console.ReadKey().KeyChar;
                                Console.WriteLine();

                                if (yesnoresult == 'y')
                                {

                                    foreach (Complaint comp in complaints)
                                    {
                                        if (comp.CustomerID== custObj.Id)
                                        {

                                            Console.WriteLine($"Complaint ID: {comp.Id}");
                                            Console.WriteLine($"Complaint Status: {comp.Status}");
                                            Console.WriteLine($"Complaint Description: {comp.Description}");

                                            Console.WriteLine($"Complaint Create Date: {comp.CreationDate}");
                                            //elapsed Days (TimeSpan)  =  current date - creation date
                                            TimeSpan elapsedDaysSinceCreation = DateTime.Now - comp.CreationDate;
                                            int reaminingDays = Complaint.MaxDaysToClose - elapsedDaysSinceCreation.Days;
                                            Console.WriteLine($"Number Of Days To Close Complaint: {reaminingDays}");


                                            if (comp is LandlineComplaint)
                                            {
                                                LandlineComplaint landComp = (LandlineComplaint)comp; //casting
                                                Console.WriteLine($"Landline Number: {landComp.LandlineNumer}");
                                                Console.WriteLine($"Complaint Description: {landComp.Address}");
                                            }



                                            Console.WriteLine($"********************************");
                                        }
                                    }
                                }






                                Console.WriteLine("-----------------------------------");

                            }
                            break;
                        case 3:
                            Console.Write("Please type Customer ID: ");
                            int customerID = int.Parse(Console.ReadLine());

                            bool isFound = false;
                            foreach (Customer custObj in customers)
                            {
                                if (custObj.Id==customerID)
                                {
                                    isFound = true;
                                    /*
                                    Console.Write("Please type your name: ");
                                    custObj.Name = Console.ReadLine();
                                    */

                                    Console.Write("Please type your Age: ");
                                    custObj.Age = int.Parse(Console.ReadLine());


                                    Console.Write("Please type your Mobile Number: ");
                                    custObj.Mobile = Console.ReadLine();
                                }
                            }
                            if (isFound==false)
                            {
                                Console.Write("Sorry, Customer Nout Found, Please Try Again ...");
                            }


                            break;
                        case 4:
                            Console.Write("Please type Customer ID: ");
                            int customerIDToDelete = int.Parse(Console.ReadLine());

                            bool isFoundToDelete = false;
                            foreach (Customer custObj in customers)
                            {
                                if (custObj.Id == customerIDToDelete)
                                {
                                    isFoundToDelete = true;
                                    Console.Write($"Are You sure you want to delete customer ID: {custObj.Id} (Y|N): ");
                                    char yesnoresult= Console.ReadKey().KeyChar;
                                    Console.WriteLine();

                                    if (yesnoresult=='y')
                                    {
                                        customers.Remove(custObj);
                                        Console.WriteLine("Customer Deleted!");
                                        break;
                                    }

                                }
                            }
                            if (isFoundToDelete == false)
                            {
                                Console.Write("Sorry, Customer Nout Found, Please Try Again ...");
                            }
                            break;

                        case 5:

                            //Complaint compObj = new Complaint(complaints.Count + 1, CustomerID);
                            LandlineComplaint compObj = new LandlineComplaint();

                            compObj.Id = complaints.Count + 1;

                             Console.Write("Please type Customer ID: ");
                            compObj.CustomerID= int.Parse(Console.ReadLine());

                            Console.Write("Please type Complain Description: ");
                            compObj.Description= Console.ReadLine();


                            Console.Write("Please type Landline Number: ");
                            compObj.LandlineNumer = Console.ReadLine();


                            Console.Write("Please type Landline Address: ");
                            compObj.Address = Console.ReadLine(); 
                            
                            complaints.Add(compObj);


                            Console.WriteLine("Done Adding The Complaint...");

                            break;

                        case 6:
                            Console.Write("Please type Complaint ID: ");
                            int complaintID = int.Parse(Console.ReadLine());

                            bool isComplaintFound = false;
                            foreach (Complaint comp in complaints)
                            {
                                if (comp.Id == complaintID)
                                {
                                    isComplaintFound = true;
                                    Console.Write($"Please Specify Complaints Status [I] InProcess [R] Resolved: ");
                                    char status = Console.ReadKey().KeyChar;
                                    Console.WriteLine();

                                    switch (char.ToUpper(status))
                                    {
                                        case 'I':
                                            comp.ChangeStatus(ComplaintStatus.InProcess);
                                            break;
                                        case 'R':
                                            comp.ChangeStatus(ComplaintStatus.Resolved);
                                            break;
                                    }
                                    Console.WriteLine("Done Updating Complaint status");
                                    break; //stop the loop

                                }
                            }
                            if (isComplaintFound == false)
                            {
                                Console.Write("Sorry, Complaint Not Found, Please Try Again ...");
                            }

                            break;
                        case 7:
                            Console.WriteLine("Please type Maximum Days to Close a Complain: ");
                            Complaint.MaxDaysToClose= int.Parse(Console.ReadLine());
                            Console.Write("Done Update Maximum Days Configuration ...");
                            break;
                        case 8:
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
