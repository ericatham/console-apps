using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClass5EricaMenezes
{
    class Program
    {
        //Method to make sure the string typed has white space
        static string CheckName(string name)
        {
            int position;

            position = name.IndexOf(" ");
            while (position == -1)
            {
                Console.WriteLine("You should enter at least 2 names with white space in between. Enter again:");
                name = Console.ReadLine();
                position = name.IndexOf(" ");
            }
            return name;
        }

        //Method to check if the SIN number is valid
        static void CheckSIN(string serial)
        {

            int[] checkArray;
            int[] sinArray;
            int[] resultArray;
            int i;
            int result = 0;

            checkArray = new int[9] { 1, 2, 1, 2, 1, 2, 1, 2, 1 }; //creating an array used to help the check 
            sinArray = new int[9];
            resultArray = new int[9];
            //loop to create a new array with each digit of the SIN number
            for (i = 0; i < 9; i++)
            {
                sinArray[i] = (int)char.GetNumericValue(serial[i]); //converting each char of the string given into an intenger in the new array 
                resultArray[i] = sinArray[i] * checkArray[i];
                if(resultArray[i]>9) //in case the product have more than 2 digits
                {
                    string aux;
                    int aux2;

                    aux = resultArray[i].ToString();
                    aux2 = (int)char.GetNumericValue(aux[0]) + (int)char.GetNumericValue(aux[1]);
                    resultArray[i] = aux2;
                }
            }
            //loop to sum the digits of the array created by the product of the array of SIN number and the array used to check
            for (i = 0; i < 9; i++)
            {
                result = result + resultArray[i];
            }
            if(result % 10 == 0)
            {
                Console.WriteLine("SIN number is valid!");
                
            }else
            {
                Console.WriteLine("SIN number is not valid!");
            }
        }
        //Program to flip 1st name and family name + check the SIN number

        static void Main(string[] args)
        {
            bool condition = true;
            string option;

            //part of the code to store the name and flip it
            do
            {
                try
                {
                    string name;
                    string[] tokens;
                    int i;

                    Console.WriteLine("Enter your name (you should use space between the names):");
                    name = Console.ReadLine();
                    name = CheckName(name); //checking if the user entered more than 1 name by calling the method
                    tokens = name.Split(null);
                    i = (tokens.Length - 1); //using a variable to store the position of the last name of the array created
                    Console.WriteLine(tokens[i] + "," + tokens[0]);//printing the very last name given and the first name 
                }
                //using "catch" to manage possible exceptions entered by the user
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input received. You should enter alphabetic characters");
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input received");
                }
                //Part of the code that read the SIN number and check it
                string sinString;

                Console.WriteLine("Enter your SIN number (9 digits with no white space)");
                sinString = Console.ReadLine();
                try
                {
                    CheckSIN(sinString);  //call the method created to check     
                }
                //using "catch" to manage possible exceptions entered by the user
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input received. You should enter digits");
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input received");
                }
                Console.WriteLine("Do you want to continue? (y/n)");
                option = Console.ReadLine();
                if (option =="n" || option =="N")
                {
                    condition = false;
                }
                else
                {
                    condition = true;
                }
            } while (condition == true);
        }

    }
}
