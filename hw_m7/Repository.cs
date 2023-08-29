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

        private string path = @"D:\C# Learning\Directory.txt";

        public Worker[] GetAllWorkers()
        {

            using (StreamReader sr = new StreamReader(path))
            {
                string line = sr.ReadLine();

                while ((line = sr.ReadLine()) != null)
                {
                    string[] lineArray = line.Split('#');
                    for (int i = 0; i < File.ReadAllLines(path).Length; i++)
                    {
                        workers[i].workerId = int.Parse(lineArray[0]);
                        workers[i].recordCreationDate = DateTime.Parse(lineArray[1]);
                        workers[i].workerFullName = lineArray[2];
                        workers[i].workerAge = int.Parse(lineArray[3]);
                        workers[i].workerGrowth = int.Parse(lineArray[4]);
                        workers[i].workerDateOfBirth = DateTime.Parse(lineArray[5]);
                        workers[i].workerPlaceOfBirth = lineArray[6];
                    }
                }
            }
            return workers;
        }

        public void GetWorkerByID()
        {
            Console.WriteLine("What`s ID you want to print?");
            int ReturnedId = int.Parse(Console.ReadLine());

            GetAllWorkers();
            

            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].workerId == ReturnedId)
                {
                    Console.WriteLine(workers.Print());
                }
            }
        }

        public void GetWorkersBetweenTwoDates()
        {
            Console.WriteLine("Input first date:");
            DateTime GetWorkersFrom = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Input second date:");
            DateTime GetWorkersTo = DateTime.Parse(Console.ReadLine());

            GetAllWorkers();

            for(int i = 0; i < workers.Length; i ++)
            {
                if (GetWorkersFrom > workers[i].recordCreationDate && GetWorkersTo < workers[i].recordCreationDate)
                {
                    
                }
            }
        }

        public void ShowAllWorkers()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] lineArray = line.Split('#');
                    foreach (string words in lineArray)
                    {
                        Console.WriteLine(words);
                        
                    }
                }
            }
        }

        public void AddNewWorker()
        {
            if(!File.Exists(path)) { File.Create(path); } 
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

            File.AppendAllText(path, newWorker.Print());
        }

        private int GetNewId(string path)
        {
            return File.ReadAllLines(path).Length + 1;
        }


    }
}
