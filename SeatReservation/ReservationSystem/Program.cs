using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4EricaTdeSMenezesP1
{
    class Program
    {
        //Program to add, edit and display informations of a dog
        static void Main(string[] args)
        {
            try
            {
                bool condition;
                string choice;
                DogRecord dog; //using the class "DogRecord" created

                //Creating of the class
                dog = new DogRecord();
                condition = true;

                //looping to keep displaying the menu, unless asked exit is required
                do
                {
                    Console.WriteLine("Select one of the options: [a]Display dog information; [b]Add a dog; [c]Edit an existing dog; [d]Exit the program;");
                    choice = Console.ReadLine();
                    switch (choice)
                    {

                        case "a":
                            dog.DisplayDogInformation(); //calls the method of the class created to display the attributes
                            break;
                        case "b":
                            dog.AddDog(); //calls the method of the class created to add values to attributes
                            break;
                        case "c":
                            dog.EditDogInformation(); //calls the method of the class used to edit the attributes
                            break;
                        case "d":
                            condition = false; //ends the looping assigning a false value to variable "condition"
                            break;
                        default:
                            Console.WriteLine("You did not insert any of the options required. Try again!");
                            Console.ReadLine();
                            break;
                    }
                } while (condition);
            }
            catch (FormatException)
            {
                Console.WriteLine("You inserted an invalid type of data!");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid data");
            }
        }
    }
}
