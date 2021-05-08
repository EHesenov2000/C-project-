using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager1 = new Manager();
            bool menuCheck;
            do
            {
                Console.CursorLeft = 5;
                Console.WriteLine("=============================================================");
                Console.CursorLeft = 5;
                Console.WriteLine("| 1.1 - Sistemdeki butun departamentleri gostermek          |");
                Console.CursorLeft = 5;
                Console.WriteLine("| 1.2 - Departamenet yaratmaq                               |");
                Console.CursorLeft = 5;
                Console.WriteLine("| 1.3 - Departmanetde deyisiklik etmek                      |");
                Console.CursorLeft = 5;
                Console.WriteLine("| 1.4 - Departamentin silinmesi                             |");
                Console.CursorLeft = 5;
                Console.WriteLine("| 2.1 - Butun iscilerin siyahisini gostermek                |");
                Console.CursorLeft = 5;
                Console.WriteLine("| 2.2 - Departamentdeki iscilerin siyahisini gostermek      |");
                Console.CursorLeft = 5;
                Console.WriteLine("| 2.3 - Isci elave etmek                                    |");
                Console.CursorLeft = 5;
                Console.WriteLine("| 2.4 - Isci uzerinde deyisiklik etmek                      |");
                Console.CursorLeft = 5;
                Console.WriteLine("| 2.5 - Departamentden isci silinmesi                       |");
                Console.CursorLeft = 5;
                Console.WriteLine("|  3  - Prosesi bitirmek                                    |");
                Console.CursorLeft = 5;
                Console.WriteLine("=============================================================\n\n");
                Console.CursorLeft = 0;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("Seciminizi edin: ");
                string secim = Console.ReadLine();
                Console.ResetColor();
                if (secim == "1.1")
                {
                    manager1.GetDepartaments();
                }
                else if (secim == "1.2")
                {
                    depadi:
                    Console.Write("\nDepartamentin adini daxil edin: ");
                    string dep = Console.ReadLine();
                    if (dep.Length< 2) 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nDepartamentin adi 2 herfden az ola bilmez!\n");
                        Console.ResetColor();
                        goto depadi;
                    }
                    if (manager1.IsExistDepartament(dep))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nBu adda departament artiq movcuddur!\n");
                        Console.ResetColor();
                        goto depadi;
                    }
                    maksIsci:
                    Console.Write("Departamentde ola bilecek maksimum isci sayi necedir? - ");
                    string iscisayi = Console.ReadLine();
                    if (!int.TryParse(iscisayi,out int iscisay) || iscisay<=0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nDuzgun daxil edin burada musbet tam eded olmalidir!\n");
                        Console.ResetColor();
                        goto maksIsci;
                    }
                    maksMaas:
                    Console.Write("Departamente ayrilacaq maksimum emek haqqi? - ");
                    string emekHaqqi = Console.ReadLine();
                    if (!double.TryParse(emekHaqqi, out double emekHaqq ))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nDuzgun daxil edin maasi!\n");
                        Console.ResetColor();
                        goto maksMaas;
                    }
                    if (emekHaqq<=iscisay)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nEmek haqqi iscinin sayindan az ola bilmez!\n");
                        Console.ResetColor();
                        goto maksIsci;
                    }
                    Console.WriteLine();
                    manager1.AddDepartaments(dep, iscisay, emekHaqq);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Departament ugurla elave edildi!\n");
                    Console.ResetColor();

                }
                else if (secim == "1.3")
                {
                    deyisik:
                    Console.Write("Deyisiklik etmek istediyiniz departamentin adini daxil edin: ");
                    string depadi = Console.ReadLine();
                    if (manager1.IsExistDepartament(depadi))
                    {
                        manager1.ChangeDepartament(depadi);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nHazirda bu adli departament movcud deyil!\n");
                        Console.ResetColor();
                        goto deyisik;
                    }
                }
                else if (secim == "1.4")
                {
                    Console.Write("Hansi departamenti silmek isteyirsiz? - ");
                    string depnami = Console.ReadLine();
                    if (manager1.IsExistDepartament(depnami))
                    {
                        manager1.RemoveDepartament(depnami);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nDepartament ugurla silindi!\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nBu adda departament movcud deyil!\n");
                        Console.ResetColor();
                    }
                }
                else if (secim == "2.1")
                {
                        manager1.GetAllWorkers();
                }
                else if (secim == "2.2")
                {
                    dep:
                    Console.Write("\nHansi departamentdeki iscileri gormek isteyirsiz? -");
                    string birdepIscileri = Console.ReadLine();
                    if (!manager1.IsExistDepartament(birdepIscileri))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nHazirda bu adli departament movcud deyil!\n");
                        Console.ResetColor();
                        goto dep;
                    }
                    else
                    {
                        manager1.GetOneDepartamentWorkers(birdepIscileri);
                    }
                }
                else if (secim == "2.3")
                {
                    adworker:
                    Console.Write("Hansi departamente elave etmek isteyirsiz? - ");
                    string adDepWorker=Console.ReadLine();
                    if (!manager1.IsExistDepartament(adDepWorker))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nHazirda bu adli departament movcud deyil!\n");
                        Console.ResetColor();
                        goto adworker;
                    }
                    Console.Write("Iscinin tam adini daxil edin: ");
                    string isciAd = Console.ReadLine();
                    if (manager1.IsExistWorker(isciAd,adDepWorker))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nBu isci {adDepWorker} departamentinde artiq movcuddur!\n");
                        Console.ResetColor();
                        goto adworker;
                    }
                    isciVezife:
                    Console.Write("Iscinin vezifesini daxil edin: ");
                    string isciVezife = Console.ReadLine();
                    if (isciVezife.Length<2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nIsci vezifesi minimum 2 herfden ibaret olmalidir!\n");
                        Console.ResetColor();
                        goto isciVezife;
                    }
                    maasi:
                    Console.Write("Iscinin maasini daxil edin: ");
                    string isciMaas = Console.ReadLine();
                    if (double.TryParse(isciMaas,out double maas ) && maas>=250)
                    {
                        manager1.AddWorker(isciAd, isciVezife, maas,adDepWorker);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nIscinin maasini duzgun daxil edin!\n");
                        Console.ResetColor();
                        goto maasi;
                    }
                }
                else if (secim == "2.4")
                {
                    depAdi:
                    Console.Write("Hansi departamentdeki iscini daxil edin: ");
                    string depAdi = Console.ReadLine();
                    if (!manager1.IsExistDepartament(depAdi))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nDepartamenin yeni adini duzgun daxil edin, bu adda departament movcud deyil!\n");
                        Console.ResetColor();
                        goto depAdi;
                    }
                    isciAdi:
                    Console.Write("Iscinin adini daxil edin: ");
                    string isciAdi = Console.ReadLine();
                    if (!manager1.IsExistWorker(isciAdi,depAdi))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nIscinin yeni adini duzugn daxil edin, bu adda isci movcud deyil\n");
                        Console.ResetColor();
                        goto isciAdi;
                    }
                    manager1.ChangeWorker(depAdi, isciAdi);
                }
                else if (secim == "2.5")
                {
                    silmek:
                    Console.Write("Hansi departamentden silmek isterdiz? - ");
                    string depad = Console.ReadLine();
                    if (!manager1.IsExistDepartament(depad))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nHazirda bu adli departament movcud deyil!\n");
                        Console.ResetColor();
                        goto silmek;
                    }
                    Console.Write("Silmek istediyiniz iscinin adini daxil edin: ");
                    string nam = Console.ReadLine();
                    if (manager1.RemoveWorker(nam, depad))
                    {
                        manager1.RemoveWorker(nam, depad);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nIsci ugurla silindi!\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\n{depad} departamentinde {nam} adli isci movcud deyil!\n");
                        Console.ResetColor();
                    }
                }
                else if (secim == "3")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nProses sonlandirildi\n");
                    Console.ResetColor();
                    return;
                }
                else
                {
                    Console.WriteLine("\n------------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sehv deyer daxil edildi,seciminizi yeniden edin!");
                    Console.ResetColor();
                    Console.WriteLine("------------------------------------------------------------\n");
                }
                menuCheck = (secim != "1.1" || secim != "1.2" || secim != "1.3" || secim != "2.1" || secim != "2.2" || secim != "2.3" || secim != "2.4" || secim != "2.5");

            } while (menuCheck == true);
        }
    }
}
