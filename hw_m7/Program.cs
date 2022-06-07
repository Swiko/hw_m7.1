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
            int choise = 0;

            Directory newEmp = new Directory();
            Directory[] AllEmployee = new Directory[10];

            while (true)
            {
                Console.WriteLine("1: for create new employee.\n" +
                                  "2: for print employees.\n" +
                                  "0: for close program.\n");

                choise = int.Parse(Console.ReadLine());

                if (choise == 0)
                {
                    break;
                }
                else if (choise == 1)
                {
                    newEmp.NewEmployee(newEmp, path);
                }
                else if (choise == 2)
                {
                    newEmp.OutputInfo(AllEmployee, path);
                }
            }            

        }
    }
}
