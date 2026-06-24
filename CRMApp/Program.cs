namespace CRMApp
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            //SumTwoNumbers();
            //ProcessLinearEquation();
            //CheckStudentScore();
            //Looping();
        }

        static void SumTwoNumbers()
        {
            Console.Write("Please type number1: ");

            int num1 = int.Parse(Console.ReadLine());


            Console.Write("Please type number2: ");
            int num2 = int.Parse(Console.ReadLine());

            int result;
            result = num1 + num2;

            Console.WriteLine(result);
        }

        static void ProcessLinearEquation()
        {
            Console.Write("Please type value of x: ");
            int x=int.Parse(Console.ReadLine());
            int y;
            y = (3 * x) + 2;
            Console.WriteLine($"value of y is: {y}");
        }

        static void CheckStudentScore()
        {
            int x = 30;
            // >  greater than
            // <   less than
            // >=   greater than or equal
            //<=  less than or equal
            // ==   equal 
            // !=  not equal
            if (x != 40)
            {
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("");
            }
        }

        static void Looping()
        {
            int num = 1;
            Console.WriteLine(num);

            while (num < 10)
            {
                num = num + 1;
                Console.WriteLine(num);
            }
         

        }
    }
}
