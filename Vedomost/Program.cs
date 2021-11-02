using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Vedomost
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Name = new List<string> { }; 
            List<string> Surname = new List<string> { }; 
            List<string> Price = new List<string> { }; 
            List<string> Date = new List<string> { }; 
            string stroka = null;
            string SumSmbl = null; 
            int spases = 0; 
            int maxLongDate = 0; 
            int sum = 0;
            int maxSum = 0; 
            int index = 0;
            string zapis;
            string izm = null;
            Console.WriteLine("exit - выход");
            Console.WriteLine("add - записать");
            Console.WriteLine("list - вывести список");


            while (izm != "exit") { 
             izm = Console.ReadLine();
            switch (izm)
            {
                
                case "add":
                    
                    StreamWriter f = new StreamWriter("Vedomost.txt", true, System.Text.Encoding.Default);
                    Console.WriteLine("Введите Имя Фимилия Кол-во денежных средств Дату выдачи в формате ДД.ММ.ГГГГ");
                    zapis = Console.ReadLine();

                    Console.WriteLine("Внести изменения? y/n");
                     
                    f.WriteLine(zapis);
                    f.Close();
                    izm = Console.ReadLine();
                    break;

                    
                case "list":
                    try
                    {

                        using (StreamReader sr = new StreamReader("Vedomost.txt"))
                        {
                            do
                            {
                                stroka = sr.ReadLine();
                                spases = 0;
                                if (stroka == null) break;
                                foreach (var simvol in stroka)
                                {
                                    if (simvol == ' ')
                                    {
                                        switch (spases)
                                        {
                                            case 0:
                                                Name.Add(SumSmbl);
                                                break;
                                            case 1:
                                                Surname.Add(SumSmbl);
                                                break;
                                            case 2:
                                                Price.Add(SumSmbl);
                                                break;
                                        }
                                        spases++;
                                        SumSmbl = null;
                                        continue;
                                    }
                                    SumSmbl += simvol;
                                }
                                Date.Add(SumSmbl);
                                SumSmbl = null;
                            } while (stroka != null); //конец строки
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    int CountLines = Name.Count;
                    ////////////////////////////////////////////////////////////////////////////
                    for (int i = 0; i < CountLines; i++) //Вывод таблицы
                    {
                        Console.Write(Name[i] + " " + Surname[i]);
                        for (int j = Name[i].Length + Surname[i].Length + 1; j <= 20; j++) { Console.Write(" "); }

                        Console.Write(Price[i] + "$");

                        for (int j = Price[i].Length; j <= 15; j++) { Console.Write(" "); }
                        Console.WriteLine(Date[i]);
                    }
                    Console.WriteLine();
                    ////////////////////////////////////////////////////////////////////////////    
                    for (int i = 0; i < CountLines; i++) //Расчет максимальной и общей суммы
                    {
                        sum += Convert.ToInt32(Price[i]);//макс
                        if (maxLongDate < Date[i].Length) maxLongDate = Date[i].Length;

                        if (Convert.ToInt32(Price[i]) > maxSum) //общ
                        {
                            maxSum = Convert.ToInt32(Price[i]);
                            index = i;
                        }
                    }
                    ////////////////////////////////////////////////////////////////////////////
                    Console.WriteLine("Всего выплаченно: " + sum + "$");
                    Console.WriteLine("Максимальная выплаченная сумма: " + Name[index] + " " + Surname[index] + " = " + maxSum + "$");
                    break;
                default:
                    Console.WriteLine("Вы ввели неизвестную команду");
                    break;
                }
            }
        }

    }
           



           
    }

        



