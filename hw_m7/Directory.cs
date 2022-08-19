﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hw_m7
{
    public struct Directory
    {

        public int id;
        public DateTime dateOfCreation;
        public string fullName;
        public int age;
        public int growth;
        public DateTime dateOfBirth;
        public string placeOfBirth;

        // Конструктор Структуры
        public Directory(int id, DateTime dateOfCreation, string fullName, int age, int growth, DateTime dateOfBirth, string placeOfBirth)
        {
            this.id = 0;
            this.dateOfCreation = dateOfCreation;
            this.fullName = fullName;
            this.age = age;
            this.growth = growth;
            this.dateOfBirth = dateOfBirth;
            this.placeOfBirth = placeOfBirth;
        }

        //Функция записи в файл
        private string Print()
        {
            return $"{id}#{dateOfCreation}#{fullName}#{age}#{growth}#{dateOfBirth}#{placeOfBirth}\n";
        }

        //Генерация ID для нового сотрудника
        private int NewId (string path)
        {
            
            if (File.Exists(path))
            {
                return (File.ReadAllLines(path).Length) + 1;
            }
            else
            {
                return 1;
            }
        }

        // Замена сотрудника*
        public void NewEmployee(string path)
        {

            this.id = NewId(path);
            this.dateOfCreation = DateTime.Now;
            Console.Write("Full name: ");
            this.fullName = Console.ReadLine();
            Console.Write("Age: ");
            this.age = int.Parse(Console.ReadLine());
            Console.Write("Growth: ");
            this.growth = int.Parse(Console.ReadLine());
            Console.Write("Date of birth: ");
            this.dateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Place of birth: ");
            this.placeOfBirth = Console.ReadLine();

            File.AppendAllText(path, Print());
        }

        //Добавление нового сотрудника
        public void NewEmployee(Directory newEmp, string path)
        {

            newEmp.id = NewId(path);
            newEmp.dateOfCreation = DateTime.Now;
            Console.Write("Full name: ");
            newEmp.fullName = Console.ReadLine();
            Console.Write("Age: ");
            newEmp.age = int.Parse(Console.ReadLine());
            Console.Write("Growth: ");
            newEmp.growth = int.Parse(Console.ReadLine());
            Console.Write("Date of birth: ");
            newEmp.dateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Place of birth: ");
            newEmp.placeOfBirth = Console.ReadLine();

            File.AppendAllText(path, newEmp.Print());
        }

        //Заполнение массива струтур из файла
        public void FillingEmployees(Directory[] AllEmployee,string path)
        {

            using (StreamReader employees = new StreamReader(path))
            {
                string line;
                int i = 0;
                
                while ((line = employees.ReadLine()) != null)
                {
                    string[] lineArray = line.Split('#');
                    
                        for (int j = 0; j < lineArray.Length; j++)
                        {
                            switch(j)
                            {
                                case 0: AllEmployee[i].id = int.Parse(lineArray[j]);
                                    break;
                                case 1: AllEmployee[i].dateOfCreation = Convert.ToDateTime(lineArray[j]);
                                    break;
                                case 2: AllEmployee[i].fullName = lineArray[j];
                                    break;
                                case 3: AllEmployee[i].age = int.Parse(lineArray[j]);
                                    break;
                                case 4: AllEmployee[i].growth = int.Parse(lineArray[j]);
                                    break;
                                case 5: AllEmployee[i].dateOfBirth = Convert.ToDateTime(lineArray[j]);
                                    break;
                                case 6: AllEmployee[i].placeOfBirth = lineArray[j];
                                    break;
                                    
                            }
                        }
                    i++;
                }
            }
        }

        //Вывод всего файла в виде массива структур
        public void OutputInfo(Directory[] AllEmployee,string path)
        {
            
            FillingEmployees(AllEmployee, path);
            for (int i = 0; i < AllEmployee.Length; i++)
            {
                Console.Write(AllEmployee[i].id + " ");
                Console.Write(AllEmployee[i].dateOfCreation + " ");
                Console.Write(AllEmployee[i].fullName + " ");
                Console.Write(AllEmployee[i].age + " ");
                Console.Write(AllEmployee[i].growth + " ");
                Console.Write(AllEmployee[i].dateOfBirth + " ");
                Console.WriteLine(AllEmployee[i].placeOfBirth + " ");
            }

        }

        //Вывод сотрудника по id
        public void OutputInfo(Directory[] AllEmployee, string path, int id)
        {
            FillingEmployees(AllEmployee, path);
            for (int i = 0; i < AllEmployee.Length; i++)
            {
                if (AllEmployee[i].id == id)
                {
                    Console.Write(AllEmployee[i].id + " ");
                    Console.Write(AllEmployee[i].dateOfCreation + " ");
                    Console.Write(AllEmployee[i].fullName + " ");
                    Console.Write(AllEmployee[i].age + " ");
                    Console.Write(AllEmployee[i].growth + " ");
                    Console.Write(AllEmployee[i].dateOfBirth + " ");
                    Console.WriteLine(AllEmployee[i].placeOfBirth + " ");
                }
            }
            
        }

        // Удаление строки по индексу
        public void DeleteEmployee(string path, int id) 
        {
            string[] array = File.ReadAllLines(path);
            Array.Clear(array, --id, 1);
            Array.Resize(ref array, array.Length - 1);
            File.Delete(path);
            File.AppendAllLines(path, array);
        }

        // Редактирование строки по индексу
        public void EditEmployee(string path, int id)
        {
            DeleteEmployee(path, id);
            NewEmployee(path);
        }

        // Сотрировка (loading...)
        public void DateSortEmployee(Directory[] AllEmployee, string path)
        {
            FillingEmployees(AllEmployee, path);

        }
    }
}
