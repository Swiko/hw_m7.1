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

            string path = @"E:\directory";
            Worker worker = new Worker();

            while (true)
            {

                Console.Write("Menu: \n Input 0 - for close programm: " +
                    "                \n Input 1 - for add new worker: " +
                    "                \n Input 2 - for print repository: " +
                    "                \n ");

                int choise = int.Parse(Console.ReadLine());
                

                if (choise == 0)
                {
                    break;
                } 
                else if (choise == 1)
                {
                    worker.CreateWorker(worker, path);
                }
            }
        }
    }
}
