using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hw_m7
{
    internal class Program
    {
        static void Main(string[] args)
        {

			Repository rep = new Repository();
			

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

                    case 1: rep.AddNewWorker();
                        break;

                    case 2: rep.ShowAllWorkers();
                        break;

                    case 3: rep.GetWorkersBetweenTwoDates();
                        break;

                    case 4: rep.GetWorkerByID();
                        break;

                    default: Console.WriteLine("Unknown command");
                        break;
                }
                

            }
        }
    }
}
