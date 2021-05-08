using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Manager : IHumanResourceManager
    {
            List<Departament> Departaments;
        public Manager()
        {
            Departaments = new List<Departament>();
        }
        public bool IsExistDepartament(string DepName)
        {
            foreach (var item in Departaments)
            {
                if (item.Name == DepName)
                {
                    return true;
                }
            }
            return false;
        }
        public void AddDepartaments(string DepName, int workerLimit, double salaryLimit)
        {
            Departament departament1 = new Departament();
            departament1.Name = DepName;
            departament1.WorkerLimit = workerLimit;
            departament1.SalaryLimit = salaryLimit;
            Departaments.Add(departament1);

        }
        public void GetDepartaments()
        {
            if (Departaments.ToArray().Length > 0)
            {

                foreach (var item in Departaments)
                {
                    Console.WriteLine("\n==========================================================================");
                    Console.WriteLine($"Departamentin adi: {item.Name}\nDepartamentin isci limiti: {item.WorkerLimit}\nDepartamentin emek haqqi limiti: {item.SalaryLimit}\n");
                    Console.WriteLine("==========================================================================\n");
                }
            }
            else
            { 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nHeleki departament elave edilmeyib!\n");
                Console.ResetColor();
            }
        }
        public void RemoveDepartament(string DepName)
        {
            foreach (var item in Departaments)
            {
                if (item.Name == DepName)
                {
                    Departaments.Remove(item);
                    return;
                }
            }
        }
        public bool IsExistWorker(string WorkerFullName, string departamentName)
        {
            foreach (var item in Departaments)
            {
                if (item.Name == departamentName) {
                    foreach (var items in item.employees)
                    {
                        if (items.FullName == WorkerFullName)
                        {
                            return true;
                        }
                    }
                }

            }
            return false;
        }
        public void AddWorker(string fullName, string position, double salary, string departamentName)
        {
            if (position.Length>=2 || salary>=250)
            {
                foreach (var item in Departaments)
                {
                    if (item.Name == departamentName)
                    {
                        if (item.SalaryLimit > salary)
                        {
                            double commonSlary = 0;
                            foreach (var itemz in item.employees)
                            {
                                commonSlary += itemz.Salary;
                            }
                            if (item.SalaryLimit > commonSlary + salary)
                            {
                                if (item.employees.Count + 1 <= item.WorkerLimit)
                                {
                                    var nowTime=DateTime.Now;
                                    Employee employee1 = new Employee();
                                    employee1.FullName = fullName;
                                    employee1.Position = position;
                                    employee1.Salary = salary;
                                    employee1.StartDate = nowTime;
                                    item.employees.Add(employee1);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nIsci ugurla elave edildi!\n");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nIsci elave edilmedi,cem isci sayi maksimum isci sayini kecir!\n");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nIsci elave edilmedi,cem emek haqqi maksimum emek haqqini kecir!\n");
                                Console.ResetColor();
                            }

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nIsci elave edilmedi, iscinin emek haqqisi departamentin ayirdigi cem emek haqqidan az olmalidir\n");
                            Console.ResetColor();
                        }

                    }
                }
            }
            
        }
        public bool RemoveWorker(string WorkerfullName, string departamentName)
        {
            foreach (var item in Departaments)
            {
                if (item.Name == departamentName)
                {
                    foreach (var items in item.employees)
                    {
                        if (items.FullName == WorkerfullName)
                        {
                            item.employees.Remove(items);
                            return true;
                        }
                    }
                }
            }
            return false;

        }
        public int GetAllWorkers()
        {
            var counter = 0;
            foreach (var item in Departaments)
            {
                if (item.employees.ToArray().Length > 0)
                {
                        counter++;
                    foreach (var employee in item.employees)
                    {
                        Console.WriteLine("\n==========================================================================");
                        Console.WriteLine($"Iscinin adi: {employee.FullName}\nIscinin vezifesi: {employee.Position}\nIscinin emek haqqi: {employee.Salary}\nIscinin siyahiya elave olunma tarixi: {employee.StartDate}");
                        Console.WriteLine("==========================================================================\n");
                    }

                }
            }
            if (counter==0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nHazirda isci yoxdur!\n");
                Console.ResetColor();
            }
            return counter;
        }
        public bool GetOneDepartamentWorkers(string DepName)
        {
            foreach (var item in Departaments)
            {
                if (item.Name == DepName)
                {
                    if (item.employees.ToArray().Length>0)
                    {
                        foreach (var employeeDep in item.employees)
                        {
                            Console.WriteLine("\n==========================================================================");
                            Console.WriteLine($"Iscinin adi: {employeeDep.FullName}\nIscinin vezifesi: {employeeDep.Position}\nIscinin emek haqqi: {employeeDep.Salary}");
                            Console.WriteLine("==========================================================================\n");
                            if (item.employees.IndexOf(employeeDep)==item.employees.Count-1)
                            {
                                return true;
                            }
                        }
                    }

                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nHazirda bu departamende isci yoxdur!\n");
            Console.ResetColor();
            return false;
        }
        public void ChangeDepartament(string depName)
        {
            foreach (var item in Departaments)
            {
                if (item.Name==depName)
                {
                    ad:
                    Console.Write("Departamentin yeni adini daxil edin: ");
                    string ad = Console.ReadLine();
                    if (ad.Length<2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nDepartamentin yeni adini duzgun daxil edin, departament adi 2 herfden kicik ola bilmez\n");
                        Console.ResetColor();
                        goto ad;
                    }
                    item.Name = ad;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nDepartamentin adi yeni ada deyisildi!\n");
                    Console.ResetColor();
                maxIsci:
                    Console.Write("Departamentin yeni maksimum isci sayini daxil edin: ");
                    string max = Console.ReadLine();
                    if (int.TryParse(max, out int maxIsci))
                    {
                        item.WorkerLimit = maxIsci;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nDepartamentin maksimum isci sayi deyisildi!\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        goto maxIsci;
                    }
                    maxSalary:
                    Console.Write("Departamentin yeni maksimum ayira bileceyi emek haqqini daxil edin: ");
                    string maxx = Console.ReadLine();
                    if (int.TryParse(maxx, out int maxMaas))
                    {
                        item.SalaryLimit = maxMaas;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nDepartamentin maksimum ayira bileceyi emek haqqi deyisildi!\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        goto maxSalary;
                    }
                }
            }
        }

        public void ChangeWorker(string depName, string worker)
        {
            foreach (var item in Departaments)
            {
                if (item.Name==depName)
                {
                    foreach (var employee in item.employees)
                    {
                        Console.Write("Iscinin yeni tam adini daxil edin: ");
                        string yeniad = Console.ReadLine();
                        employee.FullName = yeniad;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nIscinin adi deyisildi!\n");
                        Console.ResetColor();
                        vezife:
                        Console.Write("Iscinin yeni vezifesini daxil edin: ");
                        string yeniVezife = Console.ReadLine();
                        if (yeniVezife.Length<2)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nIscinin yeni vezifesini duzgun daxil edin, vezife minimum 2 herfden ibaret olmalidir!\n");
                            Console.ResetColor();
                            goto vezife;
                        }
                        employee.Position = yeniVezife;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nIscinin vezifesi deyisildi!\n");
                        Console.ResetColor();
                        maas:
                        Console.Write("Iscinin yeni emek haqqisini daxil edin: ");
                        string maas = Console.ReadLine();
                        if (double.TryParse(maas, out double maxMaas))
                        {
                            if (maxMaas<250)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nYeni emek haqqini duzgun daxil edin,emek haqqi 250-den asagi ola bilmez!\n");
                                Console.ResetColor();
                                goto maas;
                            }
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nIscinin emek haqqisi deyisildi!\n");
                            Console.ResetColor();
                            employee.Salary = maxMaas;

                            return;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nYeni emek haqqini duzugn daxil edin!\n");
                            Console.ResetColor();
                            goto maas;
                        }
                    }
                }
            }
        }
    }
}
