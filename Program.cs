using System;
using System.Diagnostics;

namespace Lab3IB
{
    class Program
    {

        static void PrintLine(string line)
        {
            Console.WriteLine(line);
        }

        static void Print(string line)
        {
            Console.Write(line);
        }


        //Проверка числа 
        static double GetNormNum(string num)
        {
            double resultInt;
            //string resultStr = Console.ReadLine();
            //bool Okey = false;
            while (!(double.TryParse(num, out resultInt)))
            {

                Print("1Вы выбрали что-то другое. Попробуйте еще раз: ");
                num = Console.ReadLine();

            }
            return resultInt;

        }



        static void PlayGame()
        {
            PrintLine("Чтобы начать игру, введите знаяение переменных A и B.");
            PrintLine("Введите значение A:");
            double a = InputAorB();

            PrintLine("Введите значение B:");
            double b = InputAorB();

            double c = Function(a, b);
            double resF = ShitThePlay(c);
            PrintLine("Чтобы выйти в меню, нажмите любой символ.");
            Console.ReadKey();
           
        }

        static double ShitThePlay(double c)
        {

            PrintLine("Попробуйте угадать значение выражения. У вас 3 попытки :)");
            Print("Введите предположительный ответ: ");
            double answer = GetNormNum(Console.ReadLine());

            //double val = Function(a, b);
            int i = 2;
            
            while (i > 0)
            {

                if (answer != c)
                {
                    PrintLine($"Вы не угдали. У вас осталось {i} попытки");
                    Print("Введите еще раз: ");
                    i--;
                    answer = GetNormNum(Console.ReadLine());
                }
                else 
                {
                    PrintLine($"Вы выиграли! Результат вычислений равен {c}");
                    i = -10;
                }
                if (i == 0)   
                {
                    PrintLine($"Результат вычислений равен {c}");
                }                            
            }
            return 0;
        }
        

        static double Function(double a, double b)
        {
            try
            {
               const double PI = Math.PI;     
               double notDiv = (Math.Pow(Math.Sin(PI / 2 + a), 2));     
               double f = Math.Round(Math.Pow(Math.Cos(PI), 7) + Math.Sqrt(Math.Log(Math.Pow(b, 4))) / notDiv, 2);    
               return f;     

            }
            catch (DivideByZeroException)
            {
                PrintLine("Ошибка деления на ноль. Но я в восхищении, что вы так смогли подобрать числа.");
                
            }

            return 0;
        }

        static double InputAorB()
        {
            double a;
            while (!double.TryParse(Console.ReadLine(), out a )|| a == 0)
            {
                PrintLine("Введено неправильное занчение. Попробуйте заново: ");       
            }
            return a;
        }

        static void TheAuthor()
        {
            Console.Clear();
            PrintLine("");
            PrintLine(" Фадеева Виктория ");
            PrintLine("  6104-090301D    ");
            PrintLine("");
            PrintLine("Чтобы вернуться в меню, нажмите на любой символ.");
            Console.ReadKey();

        }




        //Массивы

        static void Array()
        {
            int n = InputArrayLength();
            int[] array = CreateRandomArray(n);
            int[] arrayBubble = CopyArray(array);
            int[] arrayShell = CopyArray(array);

            PrintLine("\nМассив:");
            PrintArray(array);


            Stopwatch timeBubble = new Stopwatch();
            timeBubble.Start();
            BubbleSort(arrayBubble);
            timeBubble.Stop();


            Stopwatch timeShell = new Stopwatch();
            timeShell.Start();
            ShellSort(arrayShell);
            timeShell.Stop();

            PrintLine("\nПосле сортировки пузырьками");
            PrintArray(arrayBubble);
            PrintLine("\nПосле сортировки методом Шелла");
            PrintArray(arrayShell);

            PrintLine($"\nСортировка пузырьком: {timeBubble.Elapsed.TotalMilliseconds} мс");
            PrintLine($"Сортировка методом Шелла: {timeShell.Elapsed.TotalMilliseconds} мс");

            if (timeBubble.Elapsed.TotalMilliseconds < timeShell.Elapsed.TotalMilliseconds)
                PrintLine("Пузырьком быстрее.");
            else if (timeBubble.Elapsed.TotalMilliseconds > timeShell.Elapsed.TotalMilliseconds)
                PrintLine("Методом Шелла быстрее.");
            else
                PrintLine("Одинаково по времени.");
            PrintLine("Чтобы выйти в меню, нажмите любой символ.");

            Console.ReadKey();
        }



        static int InputArrayLength()
        {
            int n;
            while (true)
            {
                Print("Длина массива 1-10: ");
                if (int.TryParse(Console.ReadLine(), out n) && n > 0 && n <= 10)
                    return n;

                PrintLine("Массив должен состоять из 1-10 элеметнтов.");

            }
        }


        static int[] CreateRandomArray(int n)
        {
            Random rnd = new Random();
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
                array[i] = rnd.Next(-100, 100);
            return array;
        }


        static int[] CopyArray(int[] source)
        {
            int[] result = new int[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                result[i] = source[i];
            }
            return result;
        }


        static void PrintArray(int[] array)
        {
            if (array.Length > 10)
            {
                PrintLine("Превысили длину массива.");
            }
            else
            {
                PrintLine(string.Join(", ", array));
            }
        }


        static bool Exit()
        {
            Console.Clear();
            PrintLine("Вы хотите выйти? (д/н)");
            string answer = Console.ReadLine()?.ToLower();
            return answer == "д";
        }


        static void BubbleSort(int[] array)
        {
            int temp;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        static void ShellSort(int[] array)
        {
            int n = array.Length;


            for (int gap = n / 2; gap > 0; gap /= 2)
            {

                for (int i = gap; i < n; i++)
                {
                    int temp = array[i];
                    int j;
                    for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                    {
                        array[j] = array[j - gap];
                    }
                    array[j] = temp;
                }
            }

        }

        static void Main(string[] args)
        {
            
            bool ExitProg = true;
            while (ExitProg)    
            {
                Console.Clear();
                PrintLine("==== ПОЛЬЗОВАТЕЛЬСКОЕ МЕНЮ ====");
                Print("");
                PrintLine("1. Игра.");
                PrintLine("2. Информация об авторе.");
                PrintLine("3. Создание массива. ");
                PrintLine("4. Выход из программы.");
                Print("Выберете число из меню: ");


                string val = Console.ReadLine();

                switch (val) 
                {
                    case "1":
                       // Console.Clear();
                        PlayGame();
                        break;
                    case "2":
                        Console.Clear();
                        TheAuthor();
                        break;

                    case "3":
                        Console.Clear();
                        Array();
                        break;
                    case "4":
                        Console.Clear();
                        ExitProg = Exit();
                        break;

                    default:
                        PrintLine("Ошибка: вы ввели значение не из меню.");
                        break;



                }


            }

        }
    }
}