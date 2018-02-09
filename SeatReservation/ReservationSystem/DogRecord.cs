using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4EricaTdeSMenezesP1
{
    //Class created to store the informations about the dog and the methods to manage these informations
    class DogRecord
    {
        //creation of attributes private
        private string Name;
        private string Breed;
        private string Colour;
        private string Gender;

        //default constructor to initialize the fields 
        public DogRecord()
        {
            Name = null;
            Breed = null;
            Colour = null;
            Gender = null;
        }

        //non-default constructor 
        public DogRecord(string name, string breed, string colour, string gender)
        {
            Name = name;
            Breed = breed;
            Colour = colour;
            Gender = gender;
        }
        public void DisplayDogInformation()
        {
            if (Name == null && Breed == null && Colour == null && Gender == null)//check if there is any record
            {
                Console.WriteLine("No dog record exists");
                Console.ReadLine();
            }
            else
            {
                //displaying the information, if there is any record
                Console.WriteLine("Name:" + Name);
                Console.WriteLine("Breed:" + Breed);
                Console.WriteLine("Colour:" + Colour);
                Console.WriteLine("Gender:" + Gender);
                Console.ReadLine();
            }
        }
        public void EditDogInformation()//method to edit the informations in the attributes
        {
            bool condition = true;

            if (Name == null && Breed == null && Colour == null && Gender == null)
            {
                Console.WriteLine("No dog record exists");//check if there is any record
                Console.ReadLine();
            }
            else
            {
                try
                {
                    
                    Console.WriteLine("The current values are:");
                    DisplayDogInformation();//Display the information that was in the record using the method
                    Console.WriteLine("Please, enter the new name:");//asks for the new information
                    Name = Console.ReadLine();
                    Console.WriteLine("Please, enter the new breed:");
                    Breed = Console.ReadLine();
                    Console.WriteLine("Please, enter the new colour:");
                    Colour = Console.ReadLine();
                    do //loop to keep asking the user to insert the appropriate data
                    {
                        Console.WriteLine("Please, enter the new gender:");
                        Gender = Console.ReadLine();
                        if (Gender == "male" || Gender == "MALE" || Gender == "Male" || Gender == "female" || Gender == "FEMALE" || Gender == "Female")
                        {
                            condition = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. You should enter 'male' or 'female'");
                        }
                    } while (condition);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input");
                    Console.ReadLine();
                }
            }
        }
            public void AddDog()//method to add information about a dog
        {
            try
            {
                bool condition = true;

                if (Name != null && Breed != null && Colour != null && Gender != null)//check if there is already a record and display it
                {
                    Console.WriteLine("Dog record already exists");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Enter the name of the dog:");
                    Name = Console.ReadLine();
                    Console.WriteLine("Enter the breed of the dog:");
                    Breed = Console.ReadLine();
                    Console.WriteLine("Enter the colour of the dog:");
                    Colour = Console.ReadLine();
                    do
                    {
                        Console.WriteLine("Enter the gender of the dog:");
                        Gender = Console.ReadLine();
                        if (Gender == "male" || Gender == "MALE" || Gender == "Male" || Gender == "female" || Gender == "FEMALE" || Gender == "Female")
                        {
                            condition = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. You should enter 'male' or 'female'");
                        }
                    } while (condition);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input");
                Console.ReadLine();
            }
            }
        }
    }
     

