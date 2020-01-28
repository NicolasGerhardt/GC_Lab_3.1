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
                string[] favoriteCandy;
                string[] previousTitle;
                var foodOrTitle = new string[] { "Favorite Food", "Previous Title" };

                initalizeArrays(out students, out favoriteCandy, out previousTitle);

                Console.WriteLine("Here is our list of students:");
                createMenuwithArray(students);
                int selection = promptUserforMenuChoice(students.Length);

                Console.WriteLine($"Do you want to know about {students[selection]}'s favorite food or previous title?");
                createMenuwithArray(foodOrTitle);
                int foodOrTitleSelection = promptUserforMenuChoice(foodOrTitle.Length);

                switch (foodOrTitleSelection)
                {
                    case 0:
                        Console.WriteLine($"{students[selection]}'s favorite food is {favoriteCandy[selection]}");
                        break;
                    case 1:
                        Console.WriteLine($"{students[selection]}'s previous title was {previousTitle[selection]}");
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


        private static void initalizeArrays(out string[] students, out string[] candy, out string[] previousTitle)
        {
            students = new string[] { 
                "Alex",
                "Brian",
                "Charlie",
                "David",
                "Elana",
                "Frank",
                "Greg",
                "Hanna",
                "Ilean",
                "Jerry"
            };
            candy = new string[] {
                "Almond Joy",
                "Banana",
                "Chocolate",
                "DumDums",
                "Elephan Ears",
                "Fudge",
                "Gray Stuff",
                "Harp Bar",
                "Ice Cream",
                "Jimmies"
            };
            previousTitle = new string[] {
                "Astrophysics",
                "Board Room Designer",
                "Carnaval Owner",
                "Duck",
                "Elephant Ear Maker",
                "Funk Dance Instructor",
                "Gilette Sales Rep",
                "Handicap Advocate",
                "Intellegance Officer",
                "International Pipe Layer"
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
                    writeRed("<Error: Invalid Choice>");
                    invalidInput = true;
                }
            }

            return selection - 1;
        }

        private static void writeRed(string s)
        {
            var defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ForegroundColor = defaultColor;
        }
    }
}
