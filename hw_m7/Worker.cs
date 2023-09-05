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


        public Worker(int workerId, string fullName, int age, int growth, DateTime dateOfBirth, string placeOfBirth) :
            this(workerId, DateTime.Now, fullName, age, growth, dateOfBirth, placeOfBirth)
        {

        }


        public string Print()
        {
            return $"{this.workerId, 15}, {this.recordCreationDate, 15}, {this.workerFullName, 15}, {this.workerAge, 15}, {this.workerGrowth, 15}, {this.workerDateOfBirth, 15}, {this.workerPlaceOfBirth, 10}\n";
        }

    }

}
