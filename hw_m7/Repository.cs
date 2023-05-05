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

        private string path = @"C:\Users\respa\Desktop\Hobby\C# Learning\For File.Exist\Directory.txt";

        public void GetAllWorkers(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line = sr.ReadLine();

                while ((line = sr.ReadLine()) != null)
                {
                    string[] lineArray = line.Split('#');
                    for (int i = 0; i < File.ReadAllLines(path).Length; i ++)
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

        }

        public void ShowAllWorkers(Worker[] workers)
        {
            foreach (Worker worker in workers)
            {
                Console.Write(worker.workerId);
                Console.Write(worker.workerFullName);
                Console.Write(worker.workerAge);
                Console.Write(worker.workerGrowth);
                Console.Write(worker.workerDateOfBirth);
                Console.Write(worker.workerPlaceOfBirth);
                Console.WriteLine(worker.workerDateOfBirth);
            }
        }

        public void AddNewWorker()
    {
            if (File.Exists(path))
            {
                workers = new Worker[1];

                StreamWriter sw = new StreamWriter(path);

                workers[0].workerId = GetNewId(path);
                sw.WriteLine(workers[0].workerId + "#");
                workers[0].recordCreationDate = DateTime.Now;
                sw.WriteLine(workers[0].recordCreationDate + "#");
                workers[0].workerFullName = Console.ReadLine();
                sw.WriteLine(workers[0].workerFullName + "#");
                workers[0].workerAge = int.Parse(Console.ReadLine());
                sw.WriteLine(workers[0].workerAge + "#");
                workers[0].workerGrowth = int.Parse(Console.ReadLine());
                sw.WriteLine(workers[0].workerGrowth + "#");
                workers[0].workerDateOfBirth = DateTime.Parse(Console.ReadLine());
                sw.WriteLine(workers[0].workerDateOfBirth + "#");
                workers[0].workerPlaceOfBirth = Console.ReadLine();
                sw.WriteLine(workers[0].workerPlaceOfBirth + "#");

                sw.Close();
            }
            else 
            {
                File.Create(path);
                AddNewWorker();
            }

    }

        public int GetNewId(string path)
        {
            return File.ReadAllLines(path).Length + 1;
        }
    }
}
