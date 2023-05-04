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

			//string path = @"C:\Users\respa\Desktop\Hobby\C# Learning\For File.Exist\Directory.txt";
			Repository rep = new Repository();
			

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
					rep.AddNewWorker();
				}
				else if (choise == 2)
				{
					
                }
            }
        }
    }
}
