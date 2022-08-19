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
            int id = 0;
            
            int forArray = File.ReadAllLines(path).Length;
            Directory[] AllEmployee = new Directory[forArray];
            Directory newEmp = new Directory();

            while (true)
            {
                Console.WriteLine("\n1: for create new employee.\n" +
                                    "2: for print all employees.\n" +
                                    "3: for print employee by id.\n" +
                                    "0: for close program.\n");

                choise = int.Parse(Console.ReadLine());

                if (choise == 0) // Закрытие программы
                {
                    break;
                }
                // Создание записи
                else if (choise == 1)
                {
                    newEmp.NewEmployee(newEmp, path);
                }
                // Вывод всех сотрудников
                else if (choise == 2)
                {
                    newEmp.OutputInfo(AllEmployee, path);
                }
                // Вывод сотрудника по id и работа с ним
                else if (choise == 3)
                {
                    Console.Write("Input searched id: ");
                    id = int.Parse(Console.ReadLine());

                    newEmp.OutputInfo(AllEmployee, path, id);
                    Console.WriteLine("\n0: for delete this employee.\n" +
                                      "1: for edit this employee.\n");
                    choise = int.Parse(Console.ReadLine());
                    switch (choise)
                    {
                        case 0:
                            newEmp.DeleteEmployee(path, id);
                            Console.WriteLine("\nEmployee Deleted");
                            break;
                        case 1:
                            newEmp.EditEmployee(path, id);
                            break;
                    }

                    newEmp.OutputInfo(AllEmployee, path, id);
                }
                // Сотрировка сотрудников по дате заведения
                else if (choise == 4)
                {
                    
                }
            }            
        }
    }
}
