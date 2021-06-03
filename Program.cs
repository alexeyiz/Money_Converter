using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp3
{
    struct ExchangeSum
    {
        public double sum;
        public string indetic;
    }
    struct ExchangeRate
    {
        public string begin;
        public string end;
        public double coef;
    }
    public class Exchanger
    {
        private string prov;
        public string Creation()
        {
            ExchangeSum a;
            ExchangeRate b;
            ExchangeRate c;
            Console.WriteLine("Введите валюту");
            a.indetic = Convert.ToString(Console.ReadLine());
            if (String.IsNullOrEmpty(a.indetic) || (a.indetic != "RUB" && a.indetic != "USD" && a.indetic != "EUR"))
            {
                prov = "Ошибка ввода. Проверьте входные данные и повторите запрос";
                return prov.ToString();
            }
            Console.WriteLine("Введите размер валют");
            prov = Console.ReadLine();
            foreach (int element in prov)
            {
                if (element < '0' || element > '9' || element == '-' || String.IsNullOrEmpty(prov))
                {
                    prov = "Ошибка ввода. Проверьте входные данные и повторите запрос";
                    return prov.ToString();
                }
            }
            a.sum = Convert.ToDouble(prov);
            Console.WriteLine("Введите путь до папки с данными");
            string path = Convert.ToString(Console.ReadLine());
            if (String.IsNullOrEmpty(path) || Directory.Exists(path) == false || File.Exists(path + "\\RUB.txt") == false)
            {
                prov = "Ошибка ввода. Проверьте входные данные и повторите запрос";
                return prov.ToString();
            }
             string[] work;
            double res;
            double res1;
                if (a.indetic == "RUB")
                work = File.ReadAllLines(path + "\\RUB.txt");
               else if (a.indetic == "EUR")
                work = File.ReadAllLines(path + "\\EUR.txt");
            else if (a.indetic == "USD")
                work = File.ReadAllLines(path + "\\USD.txt");
            else
            {
                prov = "Ошибка ввода";
                return prov.ToString();
            }
            string[] math = work[0].Split(':');
            b.begin = a.indetic;
            b.end = math[0];
            b.coef = Convert.ToDouble(math[1]);
            string[] math1 = work[1].Split(':');
            c.begin = a.indetic;
            c.end = math1[0];
            c.coef = Convert.ToDouble(math1[1]);
            res = a.sum * b.coef;
            res1 = a.sum * c.coef;
            prov = a.indetic + " " + a.sum + " " + b.end + " " + c.end + " " + res + " " + res1;
            return prov.ToString();
        }

            public override string ToString()
        {
            return prov.ToString();
        }

    
    }
        class Program
        {
            static void Main(string[] args)
            {
                var a = new Exchanger();
                a.Creation();
            string res = Convert.ToString(a);
            if (res == "Ошибка ввода. Проверьте входные данные и повторите запрос")
                Console.WriteLine(res);
            else
            {
                
                string[] mass = res.Split(' ');
                //Console.WriteLine("{0} {1} {2} {3} {4} {5}",mass[0], mass[1], mass[2], mass[3], mass[4], mass[5]);
                double one = Convert.ToDouble(mass[1]);
                double two = Convert.ToDouble(mass[4]);
                double three = Convert.ToDouble(mass[5]);
                Console.WriteLine("Сумма в исходной валюте: {0:N2} {1}\nСумма в {2}: {3:N2} {2}\nСумма в {4}: {5:N2} {4}\n", one, mass[0], mass[2], two, mass[3], three);
            }
                Console.ReadKey();
            }
        }
}
