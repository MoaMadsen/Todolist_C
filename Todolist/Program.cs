using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace Todolist
{
    internal class Program : EditData
    {
        static void Main(string[] args)
        {
            // get previous information from a text file move to a list of all tasks.
            string fileName = @"C:\test\Todolist.txt";
            (List<ListofTask> allTasks, int Todo, int Done) = CheckFile(fileName);

            // main menu start here
            bool run = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to ToDoList");
                Console.WriteLine($"You have {Todo} tasks todo and {Done} tasks are done!");
                Console.WriteLine("Pick an option : ");
                Console.WriteLine(" (1) Show Task List (by date or project)");
                Console.WriteLine(" (2) Add New Task");
                Console.WriteLine(" (3) Edit Task (update, mark as done, remove)");
                Console.WriteLine(" (4) Save and Quit program");

                // Accept option and check what to do
                _ = int.TryParse(Console.ReadLine(), out int option);
                switch (option)
                {
                    case 1:
                        Console.WriteLine("option number 1");
                        ShowTaskList(allTasks);
                        break;
                    case 2:
                        Console.WriteLine("option number 2");
                        AddNewTask(allTasks);
                        Todo++;
                        break;
                    case 3:
                        Console.WriteLine("option number 3");
                        EditTask(allTasks);
                        break;
                    case 4:
                        Console.WriteLine("option number 4");
                        run = false;
                        SaveAndQuit(allTasks,fileName);
                        break;
                    default:
                        Console.WriteLine("invalid input! type 1-4");
                        break;
                }
            }
            while (run);
        }


        // Method for option 1 : Show all data in TodoList file
        private static void ShowTaskList(List<ListofTask> allTasks)
        {
            bool run = true;
            do
            {
                Console.WriteLine("*** Show Task List ***");
                Console.WriteLine("(1) Sort by Date");
                Console.WriteLine("(2) Sort by Project");
                _ = int.TryParse(Console.ReadLine(), out int option);
                switch (option)
                {
                    case 1:
                        string statusText = null;
                        Console.WriteLine("------ TodoList by Date -----");
                        var sortedDate = allTasks.OrderBy(task => task.StartDate);
                        Console.WriteLine("sort by date");
                        Console.WriteLine("-----------------------------");
                        foreach (ListofTask task in sortedDate)
                        {
                            if (task.Status)
                                statusText = "Done!";
                            else
                                statusText = " ";
                            Console.WriteLine(Convert.ToString(task.StartDate).PadRight(12) + task.Project.PadRight(20) + task.Task.PadRight(20)+statusText);
                        }
                        Console.WriteLine("");
                        break;
                    case 2:
                        Console.WriteLine("------ TodoList by project -----");
                        var sortedProject = allTasks.OrderBy(task => task.Project);
                        Console.WriteLine("sort by project");
                        Console.WriteLine("-----------------------------");
                        foreach (ListofTask task in sortedProject)
                        {
                            if (task.Status)
                                statusText = "Done!";
                            else
                                statusText = " ";
                            Console.WriteLine(task.Project.PadRight(20) + task.Task.PadRight(20) + Convert.ToString(task.StartDate).PadRight(12) + statusText);
                        }
                        Console.WriteLine("");
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

        // Method for option 2 : Add new Task
        private static void AddNewTask(List<ListofTask> allTasks)
        {
            Console.WriteLine("**** Add New Task *****");
            Console.WriteLine("Enter project name : ");
            bool defStatus = false;
            string project = Console.ReadLine();
            Console.WriteLine("Enter new task :");
            string newTask = Console.ReadLine();
            Console.WriteLine("Enter start date yyyyMMdd :");
            string startdate = Console.ReadLine();
            Console.WriteLine("Enter end date yyyyMMdd :");
            string enddate = Console.ReadLine();
            allTasks.Add(new ListofTask(defStatus, newTask, project, DateTime.Today.ToString("yyyyMMdd"), startdate, enddate));
            Console.WriteLine("Add one new task ready press any key to continue.....");
            Console.ReadLine();
        }



        // This method is the first step for checking task file and getting previos information
        public static (List<ListofTask> mytasks, int todo, int done) CheckFile(string filename)
        {
            int todo = 0;
            int done = 0;
            List<ListofTask> mytasks = new();

            try
            {
                // Check that the file doesn't already exist. If it doesn't exist, create one
                if (!File.Exists(filename))
                {
                    using StreamWriter sw = File.CreateText(filename);
                    Console.WriteLine("New file => " + filename + " created!");
                }
                else
                {
                    // Read and display the data from your file.
                    //Console.WriteLine("File \"{0}\" already exists.", filename);
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader(filename);
                    //Read the first line of text
                    string readLine = sr.ReadLine();
                    //Continue to read until you reach end of file
                    while (readLine != null)
                    {
                        string[] linePart = readLine.Split(",");
                        //update the readLine to ListofTasks
                        mytasks.Add(new ListofTask(Convert.ToBoolean(linePart[0]),linePart[1],linePart[2],linePart[3], linePart[4],linePart[5]));
                        if (Convert.ToBoolean(linePart[0]))
                            done++;
                        else
                            todo++;

                        //Read the next line
                        readLine = sr.ReadLine();
                    }
                    //close the file
                    sr.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return (mytasks, todo, done);
        }


        // Method for option 4: Save and quit the program
        private static void SaveAndQuit(List<ListofTask> allTasks, string filename)
        {
            Console.WriteLine("Are you sure that you want to save data? (y/n)");
            if (Console.ReadLine().Trim().ToLower() == "y")
            {
                try
                {
                    //              using StreamWriter sw = File.CreateText(filename);
                    using StreamWriter sw = new StreamWriter(filename);
                    foreach (ListofTask task in allTasks)
                    {
                        sw.WriteLine(task.Status + "," + task.Project + "," + task.Task + "," + DateTime.Now.ToString("yyyyMMdd") + "," + task.StartDate + "," + task.EndDate);
                    }
                    Console.WriteLine("Data saving is completed and Good bye!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("You quite program without saving any change!!! ");
                Console.WriteLine("\t\t Good Bye!!!");
                Console.ReadLine();
            }  
        }
    }
}
