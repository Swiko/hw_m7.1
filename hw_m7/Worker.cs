using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hw_m7
{
    public struct Worker
    {

        public int workerId;
        public DateTime recordCreationDate;
        public string workerFullName;
        public int workerAge;
        public int workerGrowth;
        public DateTime workerDateOfBirth;
        public string workePlaceOfBirth;

        // Конструктор Структуры
        public Worker(int id, DateTime dateOfCreation, string fullName, int age, int growth, DateTime dateOfBirth, string placeOfBirth)
        {
            this.workerId = 0;
            this.recordCreationDate = dateOfCreation;
            this.workerFullName = fullName;
            this.workerAge = age;
            this.workerGrowth = growth;
            this.workerDateOfBirth = dateOfBirth;
            this.workePlaceOfBirth = placeOfBirth;
        }

        //Функция записи в файл
        private string Print()
        {
            return $"{workerId}#{recordCreationDate}#{workerFullName}#{workerAge}#{workerGrowth}#{workerDateOfBirth}#{workePlaceOfBirth}\n";
        }

        //Генерация ID для нового сотрудника
        private int NewWorkerId (string path)
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

        //Добавление нового сотрудника
        public void CreateWorker(Worker worker, string path)
        {

            worker.workerId = NewWorkerId(path);
            worker.recordCreationDate = DateTime.Now;
            Console.Write("Full name: ");
            worker.workerFullName = Console.ReadLine();
            Console.Write("Age: ");
            worker.workerAge = int.Parse(Console.ReadLine());
            Console.Write("Growth: ");
            worker.workerGrowth = int.Parse(Console.ReadLine());
            Console.Write("Date of birth: ");
            worker.workerDateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Place of birth: ");
            worker.workePlaceOfBirth = Console.ReadLine();

            File.AppendAllText(path, worker.Print());
        }

    }
}
