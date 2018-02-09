using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assign3
{
    class Program
    {
        //Method to write the updated version of the matrice of seats in the file

        static void WriteFile(string[,] reservations)
        {

            try
            {
                int i, j;
                StreamWriter writer;

                writer = new StreamWriter("seats.txt");

                for (i = 0; i < 4; i++)
                {
                    for (j = 0; j < 4; j++)
                    {

                        writer.WriteLine(reservations[i, j]);
                    }
                }
                writer.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Problems with the file");
            }
        }
        //Method to display the seats on the screen
        static void DisplaySeats(string[,] reservations)
        {

            Console.WriteLine("Seat 1-1:" + reservations[0, 0] + "| Seat 1-2:" + reservations[0, 1] + "| Seat 1-3:" + reservations[0, 2] + "| Seat 1-4:" + reservations[0, 3]);
            Console.WriteLine("Seat 2-1:" + reservations[1, 0] + "| Seat 2-2:" + reservations[1, 1] + "| Seat 2-3:" + reservations[1, 2] + "| Seat 2-4:" + reservations[1, 3]);
            Console.WriteLine("Seat 3-1:" + reservations[2, 0] + "| Seat 3-2:" + reservations[2, 1] + "| Seat 3-3:" + reservations[2, 2] + "| Seat 3-4:" + reservations[2, 3]);
            Console.WriteLine("Seat 4-1:" + reservations[3, 0] + "| Seat 4-2:" + reservations[3, 1] + "| Seat 4-3:" + reservations[3, 2] + "| Seat 4-4:" + reservations[3, 3]);
        }
        //Method to check if there is any seats available
        static bool CheckAvailability(string[,] reservations)
        {
            int i, j;
            bool condition = true;
            int k = 0;

            while (condition && k < 16)
            {
                for (i = 0; i < 4; i++)
                {
                    for (j = 0; j < 4; j++)
                    {
                        if (reservations[i, j] == "available")
                        {
                            condition = false;
                            return condition;
                        }
                        else
                        {
                            k++;
                        }
                    }

                }
            }
            return condition;
        }
        //Method to add a customer
        static void AddCustomer(string[,] reservations)
        {

            string name;
            string rowString;
            string colString;
            int row;
            int col;
            bool keepRunning1;
            bool keepRunning2;

            try
            {
                keepRunning1 = true;
                do
                {
                    Console.WriteLine("Enter customer's name:");
                    name = Console.ReadLine();
                    if (name.Length > 2)
                    {
                        keepRunning1 = false;
                    }
                    else
                    {
                        Console.WriteLine("The customer's name must have at least 2 characters!");
                    }
                } while (keepRunning1);

                keepRunning2 = true;
                do
                {
                    Console.WriteLine("Enter first the row of the seat:");
                    rowString = Console.ReadLine();
                    row = int.Parse(rowString);
                    row = row - 1;
                    Console.WriteLine("Enter, then, the column of the seat:");
                    colString = Console.ReadLine();
                    col = int.Parse(colString);
                    col = col - 1;
                    if (row > 3 || col > 3)
                    {
                        Console.WriteLine("The position entered does not exist. Try to enter again.");
                    }
                    else
                    {
                        if (reservations[row, col] == "available")
                        {
                            reservations[row, col] = name;
                            keepRunning2 = false;
                        }
                        else
                        {
                            Console.WriteLine("This seat is taken! Choose another seat.");
                        }
                    }
                } while (keepRunning2);


                Console.WriteLine("Check the chosen position:");
                DisplaySeats(reservations);
                Console.ReadLine();
                WriteFile(reservations);
            }
            catch (FormatException)
            {
                Console.WriteLine("Format error!");
                Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Exception error!");
                Console.ReadLine();
            }
        }

        //Method to remove a customer
        static void RemoveCustomer(string[,] reservations)
        {
            try
            {
                string choiceString;
                int choice;

                Console.WriteLine("Choose the option to browse and remove the customer:[1]By name; [2]By seat position;");
                choiceString = Console.ReadLine();
                choice = int.Parse(choiceString);

                switch (choice)
                {
                    case 1:
                        string name;
                        int i, j;
                        bool condition = true;
                        int k = 0;

                        do
                        {
                            Console.WriteLine("Insert the name of the customer that will be removed:");
                            name = Console.ReadLine();
                            for (i = 0; i < 4; i++)
                            {
                                for (j = 0; j < 4; j++)
                                {
                                    if (reservations[i, j] == name)
                                    {
                                        reservations[i, j] = "available";
                                        condition = false;
                                    }
                                    else
                                    {
                                        k++;
                                        if (k == 16)
                                        {
                                            Console.WriteLine("The given name was not found! Try to insert the name again.");
                                        }
                                    }

                                }
                            }
                        } while (condition);
                        Console.WriteLine("Check the updated version of the seats.");
                        DisplaySeats(reservations);
                        Console.ReadLine();
                        break;
                    case 2:
                        string rowString;
                        string colString;
                        int row;
                        int col;
                        bool keepRunning = true;

                        do
                        {
                            Console.WriteLine("Enter, first, the row of the seat that will be removed:");
                            rowString = Console.ReadLine();
                            row = int.Parse(rowString);
                            row = row - 1;
                            Console.WriteLine("Enter, then, the column of the seat that will be removed:");
                            colString = Console.ReadLine();
                            col = int.Parse(colString);
                            col = col - 1;
                            if (row > 3 || col > 3)
                            {
                                Console.WriteLine("The position entered does not exist. Try to enter again.");
                            }
                            else
                            {
                                reservations[row, col] = "available";
                                keepRunning = false;
                            }
                        } while (keepRunning);
                        Console.WriteLine("Check the updated version of the seats.");
                        DisplaySeats(reservations);
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("You've choosen an option different than [1] or [2]");
                        Console.ReadLine();
                        break;
                }
                WriteFile(reservations);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid format entered");
                Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid operation");
                Console.ReadLine();
            }

        }

        static void Main(string[] args)
        {
            int i, j;
            string decisionString;
            int decision;
            StreamReader reader;
            string[,] reservations;
            bool check;
            bool condition = true;


            do
            {
                try
                {

                    //Transfer the data on the file to a 2 dimension array
                    reader = new StreamReader("seats.txt");
                    reservations = new string[4, 4];
                    for (i = 0; i < 4; i++)
                    {
                        for (j = 0; j < 4; j++)
                        {
                            reservations[i, j] = reader.ReadLine();
                        }
                    }
                    reader.Close();

                    //Display a menu for the user to choose an operation
                    Console.WriteLine("Choose one of the options: [1]Add customer; [2]Remove customer;[3]Exit;");
                    decisionString = Console.ReadLine();
                    decision = int.Parse(decisionString);
                    switch (decision)
                    {
                        case 1:
                            check = CheckAvailability(reservations);
                            if (check == false)
                            {
                                Console.WriteLine("Check the seating chart to choose the seat:");
                                DisplaySeats(reservations);
                                AddCustomer(reservations);

                            }
                            else
                            {
                                Console.WriteLine("There are no seats available");
                            }
                            break;
                        case 2:
                            RemoveCustomer(reservations);
                            break;
                        case 3:
                            condition = false;
                            break;
                        default:
                            Console.WriteLine("You've choosen an option different than [1] , [2] or [3]");
                            Console.ReadLine();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid format entered by user");
                    Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Problems with reading the file");
                    Console.ReadLine();
                }


            } while (condition == true);
        }
    }
}
