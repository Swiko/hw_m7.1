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
        public string workerPlaceOfBirth;

        // Конструктор Структуры
        public Worker(int id, DateTime dateOfCreation, string fullName, int age, int growth, DateTime dateOfBirth, string placeOfBirth)
        {
            this.workerId = id;
            this.recordCreationDate = dateOfCreation;
            this.workerFullName = fullName;
            this.workerAge = age;
            this.workerGrowth = growth;
            this.workerDateOfBirth = dateOfBirth;
            this.workerPlaceOfBirth = placeOfBirth;
        }

        //Функция записи в файл
        private string Print()
        {
            return $"{workerId}#{recordCreationDate}#{workerFullName}#{workerAge}#{workerGrowth}#{workerDateOfBirth}#{workerPlaceOfBirth}\n";
            }

    }
}
