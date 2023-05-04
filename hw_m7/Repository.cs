using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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



    }
}
