using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3EricadeSousaMenezesP2
{
    class Program
    {
        static double GetFirstNum()
        {
            string numString;
            double num;

            Console.WriteLine("Enter the first number for the calculation:");
            numString = Console.ReadLine();
            num = double.Parse(numString);
            return num;
        }
        static double GetSecondNum()
        {
            string numString;
            double num;

            Console.WriteLine("Enter the second number for the calculation:");
            numString = Console.ReadLine();
            num = double.Parse(numString);
            return num;
        }
        static void Main(string[] args)
        {
            string opString;
            int op;
            double num1;
            double num2;
            double result;
            bool condition;
            string exit;

            condition = true;

            while(condition == true)
            {
                //Display menu and store the operation and inputs or exit the program 
                Console.WriteLine("Enter the operation you want execute [1]Addition [2]Subtraction [3]Multiplication [4]Division");

                //Making sure that the expections can be handled with "try" and "catch"
                try
                {
                    //try to convert the input into numbers to do the operation
                    opString = Console.ReadLine();
                    op = int.Parse(opString);
                    

                    //creat a "switch" to do the calculation depending on the operation choosen

                    switch (op)
                    {
                        case 1:
                            num1 = GetFirstNum();
                            num2 = GetSecondNum();
                            result = num1 + num2;
                            Console.WriteLine("The result is:" + result);
                            break;
                        case 2:
                            num1 = GetFirstNum();
                            num2 = GetSecondNum();
                            result = num1 - num2;
                            Console.WriteLine("The result is:" + result);
                            break;
                        case 3:
                            num1 = GetFirstNum();
                            num2 = GetSecondNum();
                            result = num1 * num2;
                            Console.WriteLine("The result is:" + result);
                            break;
                        case 4:
                            num1 = GetFirstNum();
                            num2 = GetSecondNum();
                            result = num1 / num2;
                            Console.WriteLine("The result is:" + result);
                            break;
                        default:
                            Console.WriteLine("The option you choose is not a valid one. Try it again");
                            condition = true;
                            break;
                    }
                    Console.WriteLine("Do you want to exit the calculator? y/n");
                    exit = Console.ReadLine();
                    if (exit == "y")
                    {
                        condition = false;
                    }
                }
                //handling 3 kind of exceptions (input in wrong format, long numbers and if zero is the second number typed) or any other exception possible
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input received. You should only enter a number");
                    Console.ReadLine();
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number resulted is too big. Can't be displayed");
                    Console.ReadLine();
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("The division by zero is not possible. Type another number as the second input next time");
                    Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input received");
                    Console.ReadLine();
                }
            } 
        }
    }
}
