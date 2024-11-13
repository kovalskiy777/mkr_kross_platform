using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        // Читаємо значення N з файлу INPUT.TXT
         int N = int.Parse(File.ReadAllText("INPUT.txt"));

        // Створюємо чергу для зберігання гладких чисел
        Queue<long> smoothNumbers = new Queue<long>();

        // Заповнюємо початковими однозначними числами (від 1 до 9)
        for (int i = 1; i <= 9; i++)
        {
            smoothNumbers.Enqueue(i);
        }

        long result = 0;

        // Перебираємо елементи поки не отримаємо N-е гладке число
        for (int count = 1; count <= N; count++)
        {
            // Виймаємо перше число в черзі
            result = smoothNumbers.Dequeue();

            // Остання цифра поточного гладкого числа
            int lastDigit = (int)(result % 10);

            // Додаємо нові гладкі числа, які починаються з поточного
            if (lastDigit > 0)
            {
                smoothNumbers.Enqueue(result * 10 + (lastDigit - 1));
            }
            if (lastDigit < 9)
            {
                smoothNumbers.Enqueue(result * 10 + (lastDigit + 1));
            }
        }

        // Записуємо результат в файл OUTPUT.TXT
        File.WriteAllText("OUTPUT.txt", result.ToString());
    }
}