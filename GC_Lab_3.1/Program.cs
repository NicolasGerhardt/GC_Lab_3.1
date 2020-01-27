using System;
using System.Collections.Generic;

namespace GC_Lab_3._1
{
    class Program
    {
       

        static void Main(string[] args)
        {
            Console.WriteLine("Lets get to know your fellow students!");
            do
            {
                string[] students;
                string[] favoriteFoods;
                string[] previousTitle;
                var foodOrTitle = new string[] { "Favorite Food", "Previous Title" };

                initalizeArrays(out students, out favoriteFoods, out previousTitle);

                Console.WriteLine("Here is our list of students:");
                createMenuwithArray(students);
                int selection = promptUserforMenuChoice(students.Length);

                Console.WriteLine("Do you want to know about their favorite food or previous title?");
                createMenuwithArray(foodOrTitle);
                int foodOrTitleSelection = promptUserforMenuChoice(foodOrTitle.Length);

                switch (foodOrTitleSelection)
                {
                    case 0:
                        Console.WriteLine($"{students[selection]} favorite food is {favoriteFoods[selection]}");
                        break;
                    case 1:
                        Console.WriteLine($"{students[selection]} previous title was {previousTitle[selection]}");
                        break;
                }
            } while (askAboutAnotherStudent());

            Console.WriteLine("Excellent, you have a great day!!");

        }

        private static bool askAboutAnotherStudent()
        {
            Console.WriteLine();
            while (true)
            {
                Console.Write("Woud you like to know about another student? (y/n): ");
                var keyPressed = Console.ReadKey().KeyChar.ToString().ToLower();
                Console.WriteLine();

                if (keyPressed == "y")
                {
                    Console.WriteLine("Sounds good! Lets Go!");
                    return true;
                }
                else if (keyPressed == "n")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("<Error: Invalid Choice>");
                }
            }
        }


        private static void initalizeArrays(out string[] students, out string[] favoriteFoods, out string[] previousTitle)
        {
            students = new string[] { 
                "Alex",
                "Brian",
                "Charlie",
                "David",
                "Elana"
            };
            favoriteFoods = new string[] {
                "Pizza",
                "Burgers",
                "Rice",
                "Money Brains",
                "Stuffed Cabbage"
            };
            previousTitle = new string[] {
                "Lawn Mower",
                "Dish Washer",
                "Cloths Cleaner",
                "Window Washer",
                "Dance Instructor"
            };

        }

        private static void createMenuwithArray(string[] menuItems)
        {

            for (int i = 0; i < menuItems.Length; i++)
            {
                string menuItemNumber = (i + 1).ToString().PadLeft(4);
                Console.WriteLine($"{menuItemNumber}:{menuItems[i]}");
            }

        }

        private static int promptUserforMenuChoice(int menuLength)
        {
            bool invalidInput = true;
            int selection = 0;
            while (invalidInput)
            {
                Console.Write($"From the above options, select a number from above, and press enter!\n > ");
                var rawUserInput = Console.ReadLine();

                invalidInput = !int.TryParse(rawUserInput, out selection);
                if (selection > menuLength || selection < 1)
                {
                    Console.WriteLine("<Error: Invalid Choice>");
                    invalidInput = true;
                }
            }

            return selection - 1;
        }

    }
}
