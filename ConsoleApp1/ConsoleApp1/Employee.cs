using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Employee
    {
        public string FullName;
        public string BirthDate;    //bunu deqiq bilmedim sonda baxaram
        private string position;
        private double salary;
        public DateTime StartDate;//iscini elave edende get time edib onu da buna beraber etmek olar
        public string Position {
            get
            {
                return this.position;
            }
            set
            {
                if (value.Length >= 2)
                {
                    this.position = value;
                }
            }
                }
        public double Salary {
            get{
                return this.salary;
            }
            set
            {
                if (value >= 250)
                {
                    this.salary = value;
                }
            }
                }
    }
}
