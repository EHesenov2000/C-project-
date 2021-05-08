using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    interface IHumanResourceManager
    {
        public abstract bool IsExistDepartament(string DepName);
        public abstract void AddDepartaments(string DepName, int workerLimit, double salaryLimit);
        public abstract void RemoveDepartament(string DepName);
        public abstract void GetDepartaments();
        public abstract bool IsExistWorker(string WorkerFullName,string departamentName);
        public abstract void AddWorker(string fullName,string position,double salary, string departamentName);
        public abstract bool RemoveWorker(string WorkerfullName, string departamentName);
        public abstract int GetAllWorkers();
        public abstract bool GetOneDepartamentWorkers(string DepName);
        public abstract void ChangeDepartament(string depName);
        public abstract void ChangeWorker(string depName,string worker);

    }
}
