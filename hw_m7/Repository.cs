using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace hw_m7
{
    public class Repository
    {

        public Worker[] workers;

        int index;

        private string path;

        /// <summary>
        /// Инициализация репозитория
        /// </summary>
        public Repository(string Path) {
            this.path = Path;
            this.index = 0;
            this.workers = new Worker[1];
            this.GetAllWorkers();
        }


        /// <summary>
        /// Загрузка данных из файла
        /// </summary>
        public Worker[] GetAllWorkers()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split(',');

                    Add(new Worker(int.Parse(args[0]),DateTime.Parse(args[1]), args[2], int.Parse(args[3]), int.Parse(args[4]), DateTime.Parse(args[5]), args[6]));
                }
            }
            return workers;
        }


        /// <summary>
        /// Добавление экземплра в структуру
        /// </summary>
        public void Add(Worker ConcreteWorker)
        {
            this.Resize(index >= this.workers.Length);
            this.workers[index] = ConcreteWorker;
            this.index++;
        }


        /// <summary>
        /// Вывод данных по id сотрудника
        /// </summary>
        public void GetWorkerByID()
        {

            Console.WriteLine("What`s ID you want to print?");
            int ReturnedId = int.Parse(Console.ReadLine());

            for (int i = 0; i < workers.Length - 1; i++)
            {
                if (this.workers[i].workerId == ReturnedId)
                {
                    Console.WriteLine(this.workers[i].Print());
                } else
                {
                    continue;
                }
            }
        }


        /// <summary>
        /// Вывод данных в опеределенном диапазоне дат
        /// </summary>
        public void GetWorkersBetweenTwoDates()
        {
            Console.WriteLine("Input first date:");
            DateTime GetWorkersFrom = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Input second date:");
            DateTime GetWorkersTo = DateTime.Parse(Console.ReadLine());

            for(int i = 0; i < workers.Length; i ++)
            {
                if (GetWorkersFrom < workers[i].recordCreationDate && GetWorkersTo > workers[i].recordCreationDate)
                {
                    Console.WriteLine(this.workers[i].Print());
                } else
                {
                    continue;
                }
            }
        }


        /// <summary>
        /// Вывод данных в консоль
        /// </summary>
        public void ShowAllWorkers()
        {
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(this.workers[i].Print());
            }
        }


        /// <summary>
        /// Создание экземпляра структуры
        /// </summary>
        public void AddNewWorker()
        {

            Worker newWorker = new Worker();


            newWorker.workerId = GetNewId(path);
            Console.WriteLine("Input worker full name");
            newWorker.workerFullName = Console.ReadLine();
            Console.WriteLine("Input worker age");
            newWorker.workerAge = int.Parse(Console.ReadLine());
            Console.WriteLine("Input worker growth");
            newWorker.workerGrowth = int.Parse(Console.ReadLine());
            Console.WriteLine("Input worker date of birth");
            newWorker.workerDateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Input worker place of birth");
            newWorker.workerPlaceOfBirth = Console.ReadLine();

            this.Add(new Worker(newWorker.workerId, 
                                newWorker.workerFullName, 
                                newWorker.workerAge,
                                newWorker.workerGrowth,
                                newWorker.workerDateOfBirth,
                                newWorker.workerPlaceOfBirth));
            this.Save(path);
        }


        public void DeleteWorker()
        {
            
            Console.WriteLine("Input remote worker ID:");
            int remoteId = int.Parse(Console.ReadLine());

            Array.Clear(this.workers, remoteId-1, 1);
            index--;
            this.Save(path);

        }


        /// <summary>
        /// Сохранение данных в файл
        /// </summary>
        public void Save(string Path)
        {

            for (int i = 0; i < this.index; i++)
            {
                string temp = String.Format("{0},{1},{2},{3},{4},{5},{6}",
                                        this.workers[i].workerId,
                                        this.workers[i].recordCreationDate,
                                        this.workers[i].workerFullName,
                                        this.workers[i].workerAge,
                                        this.workers[i].workerGrowth,
                                        this.workers[i].workerDateOfBirth,
                                        this.workers[i].workerPlaceOfBirth);

                File.AppendAllText(Path, $"{temp}\n");
            }
        }


        /// <summary>
        /// Генерация id сотрудника
        /// </summary>
        private int GetNewId(string path)
        {
            return File.ReadAllLines(path).Length + 1;
        }


        /// <summary>
        /// Редактировине размера структуры
        /// </summary>
        private void Resize(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref this.workers, this.workers.Length * 2);
            }
        }
    }

}
