using System;
using System.IO;

namespace hw_m7
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string path = @"D:\C# Learning\Directory.txt";
            Repository rep = new Repository(path);

            while (true)
            {

                Console.Write("Menu: \n Input 0 - for close programm: " +
                    "                \n Input 1 - for add new worker: " +
                    "                \n Input 2 - for print repository: " +
                    "                \n Input 3 - for get workers between two dates" +
                    "                \n Input 4 - for get worker by id" +
                    "                \n ");

                int choise = int.Parse(Console.ReadLine());


                switch (choise)
                {
                    case 0: break;

                    case 1:
                        rep.AddNewWorker();
                        break;

                    case 2:
                        rep.ShowAllWorkers();
                        break;

                    case 3:
                        rep.GetWorkersBetweenTwoDates();
                        break;

                    case 4:
                        rep.GetWorkerByID();
                        break;
                    case 5:
                        rep.DeleteWorker();
                        break;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }


            }
        }
    }
}
