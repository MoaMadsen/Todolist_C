using System;
using System.Collections.Generic;
using System.Linq;

namespace Todolist2
{
    internal class EditData
    {
        // private static IEnumerable<ListofTask> allTasks;

        // Method for option 3 : Edit Task (update, mark as done, remove)
        public static (int todo, int done) EditTask(List<ListofTask> allTasks, int Todo, int Done)
        {
            bool run = true;
            int todo = Todo;
            int done = Done;
            do
            {
                Console.Clear();
                Console.WriteLine($"You have {todo} tasks todo and {done} tasks are done!");

                Console.WriteLine("*** Edit this list of Tasks ***");
                Console.WriteLine("---- Choose option -----------------------------------------");
                Console.WriteLine("(1) Edit task");
                Console.WriteLine("(2) Mark as done");
                Console.WriteLine("(3) Remove task");
                run = int.TryParse(Console.ReadLine().Trim(), out int option);
                switch (option)
                {
                    case 1:
                        WriteAllinTheList(allTasks);
                        Console.WriteLine("Which task do you want to edit? -----");
                        Console.WriteLine("This part is not finished yet.......");
                        Console.ReadLine();
                        break;
                    case 2:
                        WriteAllinTheList(allTasks);
                        Console.WriteLine("Which task you want to mark as done?");
                        if (int.TryParse(Console.ReadLine().Trim(), out int markIndex))
                        {

                            //                        int markIndex = Convert.ToInt16(Console.ReadLine().Trim());
                            if (markIndex > allTasks.Count || allTasks[markIndex - 1].Status == true)
                            {
                                Console.WriteLine($"Task number {markIndex} cannot be marked as done.");
                                Console.ReadLine();
                            }
                            else
                            {
                                allTasks[markIndex - 1].Status = true;
                                todo--;
                                done++;
                                Console.WriteLine($"Task # {markIndex} : {allTasks[markIndex - 1].Task} of project {allTasks[markIndex - 1].Project} is marked as Done!");
                                Console.WriteLine("Press enter to continue ....");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("you selecet nothing, press enter to go back ....");
                            Console.ReadLine();
                        }
                        break;
                    case 3:
                        WriteAllinTheList(allTasks);
                        Console.WriteLine("Which task number you want to remove? -----");
                        if (int.TryParse(Console.ReadLine().Trim(), out int removeIndex))
                        {
                            if (removeIndex > allTasks.Count)
                            {
                                Console.WriteLine($"Task number {removeIndex} cannot be removed.");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine(allTasks[removeIndex - 1].Task + "is removed!");
                                if (allTasks[removeIndex - 1].Status == true)
                                    done--;
                                else
                                    todo--;
                                allTasks.RemoveAt(removeIndex - 1);
                            }
                        }
                        else 
                        {
                            Console.WriteLine("you selecet nothing, press enter to go back ....");
                            Console.ReadLine();
                        }
                        break;
                    default:
                        run = false;
                        Console.WriteLine("invalid input! type 1, 2 or enter for go back to main menu");
                        Console.ReadLine();
                        break;
                }
            } while (run);
            return (todo, done);
        }

        private static void WriteAllinTheList(List<ListofTask> allTasks)
        {
            int i = 0;
            string statusText;
            foreach (ListofTask task in allTasks)
            {
                if (task.Status)
                    statusText = "Done!";
                else
                    statusText = " ";

                Console.WriteLine(Convert.ToString(i + 1) + ":  " + task.Project.PadRight(20) + task.Task.PadRight(20) + Convert.ToString(task.StartDate).PadRight(12) + statusText);
                i++;
            }
        }
    }
}