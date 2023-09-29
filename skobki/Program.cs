using System;
class Program
{
    static void Main()
    {
        while (true)
        {
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine();
            if (N % 2 == 0 && N != 0)
            {
                char[] mas = new char[N];
                mas[0] = '(';
                Generation(mas, 1, N, 1, 0);
                mas[0] = '[';
                Generation(mas, 1, N, 0, 1);
            }
            else
            {
                Console.WriteLine("\nN должно быть четным.");
            }
            Console.WriteLine();
        }

    }

    static void Generation(char[] mas, int j, int N, int counter1, int counter2)
    {
        if (j == N)
        {
            foreach (char i in mas)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }
        else
        {
            int opencount = 0, closecount = 0;
            bool fl = true;
            for (int i = j - 1; fl && i >= 0; i--)
            {
                if (mas[i] == '(') opencount--;
                if (mas[i] == '[') closecount--;
                if (mas[i] == ')') opencount++;
                if (mas[i] == ']') closecount++;
                if (opencount < 0 || closecount < 0) fl = false;
            }
            if (fl)
            {
                mas[j] = '(';
                Generation(mas, j + 1, N, counter1 + 1, counter2);
                mas[j] = '[';
                Generation(mas, j + 1, N, counter1, counter2 + 1);
            }

            else
            {
                if (opencount < 0)
                {
                    mas[j] = ')';
                    Generation(mas, j + 1, N, counter1, counter2);
                    if (counter1 + counter2 < N / 2)
                    {
                        mas[j] = '(';
                        Generation(mas, j + 1, N, counter1 + 1, counter2);
                        mas[j] = '[';
                        Generation(mas, j + 1, N, counter1, counter2 + 1);
                    }
                }
                if (closecount < 0)
                {
                    mas[j] = ']';
                    Generation(mas, j + 1, N, counter1, counter2);
                    if (counter1 + counter2 < N / 2)
                    {
                        mas[j] = '(';
                        Generation(mas, j + 1, N, counter1 + 1, counter2);
                        mas[j] = '[';
                        Generation(mas, j + 1, N, counter1, counter2 + 1);
                    }
                }
            }
        }
    }
}