using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Departament
    {
        public List<Employee> employees;
        private string name;
        public string Name {
            get 
            {
                return this.name;
            }
            set
            {
                if (value.Length>=2)
                {
                    this.name = value;
                }
            }
        }
        public int WorkerLimit;
        public double SalaryLimit;
        public Departament()
        {
            employees = new List<Employee>();
        }
    }
}
