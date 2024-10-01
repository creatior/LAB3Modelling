using System.Transactions;
using System.Xml.Schema;

namespace PseudoRandomNumbers
{
    internal class Program
    {
        static List<double> NeumannMethod()
        {
            int N = 6;
            double R0 = 0.583;
            List<double> random_list = new List<double>();
            random_list.Add(R0);

            double current = R0;
            for (int i = 1; i < N; i++)
            {
                double temp = Math.Pow(current, 2); // 0.33988900
                temp = (Math.Floor(temp * 1e6) % (int)1e4) / 1e4;
                random_list.Add(temp);
                current = temp;
            }
            return random_list;
        }

        static List<double> ModifiedNeumannMethod()
        {
            int N = 6;
            double R0 = 0.5836, R1 = 0.2176;
            List<double> random_list = new List<double>();
            random_list.Add(R0);
            random_list.Add(R1);

            double current = R1, prev = R0;
            for (int i = 2; i < N; i++)
            {
                double temp = current * prev;
                temp = (Math.Floor(temp * 1e6) % (int)1e4) / 1e4;
                random_list.Add(temp);
                prev = current;
                current = temp;
            }
            return random_list;
        }

        static List<double> LemerMethod()
        {
            int N = 5;
            double R0 = 0.585;
            double g = 927;

            List<double> random_list = new List<double>();
            random_list.Add(R0);

            double current = R0;
            for(int i = 0; i < N; i++)
            {
                double temp = LemerFunction(g, current);
                random_list.Add(temp);
                current = temp;
            }

            return random_list;
        }

        static double LemerFunction(double x, double g)
        {
            return Math.Round(g * x - Math.Floor(g * x), 6);
        }

        static List<double> LinearCongruentMethod()
        { 
            int N = 6;
            int a = 265, m = 129, X0 = 122;
            List<double> random_list = new List<double>();

            double current = X0;
            for (int i = 1; i < N; i++)
            {
                double temp = (a * current) % m;
                random_list.Add(Math.Round(temp / (double)m, 4));
                current = temp;
            }
            return random_list;
        }

        static void Main(string[] args)
        {

            //List<double> list2 = ModifiedNeumannMethod();
            //Console.Write("Сгенерированная последовательность: ");
            //foreach (double x in list2)
            //{
            //    Console.Write($"{x} ");
            //}
            //List<double> list3 = LemerMethod();
            //Console.Write("Сгенерированная последовательность: ");
            //foreach (double x in list3)
            //{
            //    Console.Write($"{x} ");
            //}
            //List<double> list4 = LinearCongruentMethod();
            //Console.Write("Сгенерированная последовательность: ");
            //foreach (double x in list4)
            //{
            //    Console.Write($"{x} ");
            //}
            int c = 1;
            while (c != 0)
            {
                Console.Write("1. Метод Неймана.\n2. Модифицированный метод Неймана.\n" +
                                  "3. Метод Лемера.\n4. Линейный конгруэнтный метод.\n" +
                                  "Выберите номер (0 для выхода): ");
                c = Int32.Parse(Console.ReadLine());
                Console.Clear();
                switch (c)
                {
                    case 0:
                        {
                            Console.Write("Работа завершена.");
                            break;
                        }
                    case 1:
                        {
                            List<double> list = NeumannMethod();
                            Console.Write("Сгенерированная последовательность: ");
                            foreach (double x in list)
                            {
                                Console.Write($"{x} ");
                            }
                            break;
                        }
                    case 2:
                        {
                            List<double> list = ModifiedNeumannMethod();
                            Console.Write("Сгенерированная последовательность: ");
                            foreach (double x in list)
                            {
                                Console.Write($"{x} ");
                            }
                            break;
                        }
                    case 3:
                        {
                            List<double> list = LemerMethod();
                            Console.Write("Сгенерированная последовательность: ");
                            foreach (double x in list)
                            {
                                Console.Write($"{x} ");
                            }
                            break;
                        }
                    case 4:
                        {
                            List<double> list = LinearCongruentMethod();
                            Console.Write("Сгенерированная последовательность: ");
                            foreach (double x in list)
                            {
                                Console.Write($"{x} ");
                            }
                            break;
                        }
                    default: break;
                }
                Console.WriteLine("\n---------------------------------------------------------------------------");
            }
        }
    }
}