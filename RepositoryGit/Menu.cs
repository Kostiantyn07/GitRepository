using System;
using System.Collections.Generic;

namespace HW6_Gradebook
{
    public static class Menu
    {
        public static Student ChooseStudent(List<Student> students)
        {
            Console.WriteLine("Please, choose student:");

            bool check;
            int chosenNum;

            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1} - for {students[i].Name}");
            }

            do
            {
                Console.WriteLine();
                Console.WriteLine("Enter option:");
                check = int.TryParse(Console.ReadLine(), out chosenNum);
            } while (!check || chosenNum < 1 || chosenNum > students.Count);

            Student chosen = students[chosenNum - 1];

            return chosen;
        }

        public static void GradebookOptions(Gradebook gradebook)
        {
            bool check;
            int chosenNum;
            Subject currentSubj;

            Console.WriteLine("Choose what you want to see:");
            Console.WriteLine("1 - All gradebook");
            Console.WriteLine("2 - Gradebook statistics");
            Console.WriteLine("3 - Subject statistics");
            Console.WriteLine("4 - Add grade to subject");


            do
            {
                Console.WriteLine();
                Console.WriteLine("Enter option:");
                check = int.TryParse(Console.ReadLine(), out chosenNum);
            } while (!check || chosenNum < 1 || chosenNum > 4);

            switch (chosenNum)
            {
                case 1:
                    gradebook.DisplayGradebook();
                    break;
                case 2:
                    gradebook.AverageGrade();
                    gradebook.MinAndMaxGrade();
                    break;
                case 3:
                    currentSubj = ChooseSubject(gradebook.Subjects);
                    currentSubj.AverageGrade();
                    currentSubj.MinAndMaxGrade();
                    break;
                case 4:
                    currentSubj = ChooseSubject(gradebook.Subjects);
                    currentSubj.AddGrade();
                    break;
                default:
                    Console.WriteLine("Smth went wrong. Sorry.");
                    break;
            }
        }

        public static Subject ChooseSubject(List<Subject> subjects)
        {
            Console.WriteLine("Please, choose subject:");

            bool check;
            int chosenNum;
            int i = 1;
            foreach (Subject sbj in subjects)
            {
                Console.WriteLine($"{i} - for {sbj.Name}");
                i++;
            }

            do
            {
                Console.WriteLine();
                Console.WriteLine("Enter option:");
                check = int.TryParse(Console.ReadLine(), out chosenNum);
            } while (!check || chosenNum < 1 || chosenNum > subjects.Count - 1);

            Subject chosen = subjects[chosenNum - 1];

            return chosen;
        }


    }
}
