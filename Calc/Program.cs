using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            //ввод строки
            Console.WriteLine("Введите выражение: ");
            string viraj = Console.ReadLine();

            //Знаки разделения элементов строки
            char[] separate = new char[] { '*', '/', '+', '-' };

            //Собираем элементы строки в список
            string[] vir = viraj.Split(separate, StringSplitOptions.RemoveEmptyEntries);

            //Преобразование элементов строки в числовой формат
            List<double> vir2 = new List<double>();
            for (int i = 0; i < vir.Length; i++)
            {
                try
                {
                    double.TryParse(vir[i], out double res);
                    vir2.Add(res);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse '{vir}' ");
                }
            }

            //Поиск символа в строке
            do
            {
                foreach (char a in viraj)
                {
                    double n;
                    int v = viraj.IndexOf('/');
                    int u = viraj.IndexOf('*');
                    int p = viraj.IndexOf('+');
                    int m = viraj.IndexOf('-');

                    switch (a)
                    {
                        case '/':
                            n = vir2[0] / vir2[1];
                            vir2[0] = n;
                            vir2.RemoveAt(1);
                            viraj = viraj.Remove(viraj.IndexOf("/"), 1);
                            break;
                        case '*':
                            n = vir2[0] * vir2[1];
                            vir2[0] = n;
                            vir2.RemoveAt(1);
                            viraj = viraj.Remove(viraj.IndexOf("*"), 1);
                            break;
                        case '+' when p > v && p > u:
                            n = vir2[0] + vir2[1];
                            vir2[0] = n;
                            vir2.RemoveAt(1);
                            viraj = viraj.Remove(viraj.IndexOf("+"), 1);
                            break;
                        case '-' when m > v && m > u:
                            n = vir2[0] - vir2[1];
                            vir2[0] = n;
                            vir2.RemoveAt(1);
                            viraj = viraj.Remove(viraj.IndexOf("-"), 1);
                            break;
                        case '+':
                            vir2.Add(vir2[0]);
                            vir2.RemoveAt(0);
                            break;
                        case '-':
                            vir2.Add(vir2[0]);
                            vir2.RemoveAt(0);
                            break;
                    }
                }
            } while (vir2.Count != 1);
            Console.WriteLine(vir2[0]);
            Console.ReadLine();
        }
    }
}
