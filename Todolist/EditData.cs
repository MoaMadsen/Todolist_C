using System;
using System.Collections.Generic;
using System.Linq;

namespace Todolist
{
    internal class EditData
    {

        // Method for option 3 : Edit Task (update, mark as done, remove)
        public static void EditTask(List<ListofTask> allTasks)
        {
            bool run = true;
            do
            {
                Console.Clear();
                Console.WriteLine("*** Edit this list of Tasks ***");
                int i = 0;
                string statusText;
                foreach (ListofTask task in allTasks)
                {
                    if (task.Status)
                        statusText = "Done!";
                    else
                        statusText = " ";

                    Console.WriteLine(Convert.ToString(i) + ":  " + task.Project.PadRight(20) + task.Task.PadRight(20) + Convert.ToString(task.StartDate).PadRight(12) + statusText);
                    i++;
                }
                Console.WriteLine("---- Choose option -----------------------------------------");
                Console.WriteLine("(1) Edit task");
                Console.WriteLine("(2) Mark as done");
                Console.WriteLine("(3) Remove task");
                _ = int.TryParse(Console.ReadLine(), out int option);
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Which task do you want to edit? -----");
                        break;
                    case 2:
                        Console.WriteLine("Which task you want to mark as done?");
                        string searchWord = Console.ReadLine();
                        var searchName = allTasks.Where(task => task.Task == searchWord).ToList();


                        Console.WriteLine("Mask as done");
                        Console.WriteLine("-----------------------------");
                        break;
                    case 3:
                        Console.WriteLine("Which task number you want to remove? -----");
                        break;
                    case 0:
                        run = false;
                        break;
                    default:
                        Console.WriteLine("invalid input! type 1, 2 or enter for go back to main menu");
                        break;
                }
            } while (run);
        }
    }
}