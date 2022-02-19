using System;

namespace Technical_task
{
    internal class Program
    {
        static char[] stringreverse(string str)
        {
            char[] reversestr = new char[str.Length]; // Создаем массив символов для перевернутой строки
            for (int i = 0, j = str.Length - 1; (i < str.Length && j >= 0); i++, j--) // Переворачиваем строку
            {
                reversestr[j] = str[i];
            }
            return reversestr;
        }
        static bool checkpalindrome(string str)
        {
            str = str.ToLower();// Убираем высокие регистры из строки
            bool flag = true;
            for (int i = 0, j = str.Length - 1; (i <= str.Length / 2 && j > Math.Ceiling(str.Length / 2.0)); i++, j--)// проверяем на равенство символов до середины
            {
                if (str[i] != str[j])
                {
                    flag = false; break;
                }
            }
            return flag;
        }
        static bool ChekSymbol(string str, char symbol)
        {
            foreach (char ch in str)
            {
                if (ch == symbol)
                    return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            Console.Write("1) Введите строку которую нужно перевернуть: ");
            string str = Console.ReadLine();
            Console.WriteLine(stringreverse(str));
            Console.Write("2) Введите строку которую нужно проверить на полиндром: ");
            string[] subs = Console.ReadLine().Split(' ', ',', '-', '_', '/', '?', '!', '.', ';', ':');
            string str1 = string.Empty;
            for (int i = 0; i < subs.Length; i++)// соединям сложные палиндромы состоящие из несколких слов в одну строку
            {
                str1 += subs[i];
            }
            if (checkpalindrome(str1)) Console.WriteLine("Да, это строка является полиндромом");
            else Console.WriteLine("Нет, это строка не является полиндромом");
            Console.Write("3) Введите строку в которой нужно посчитать вхождение каждого символа: ");
            string[] subs1 = Console.ReadLine().Split(' ', ',', '-', '_', '/', '?', '!', '.', ';', ':');
            string str2 = string.Empty;
            for (int i = 0; i < subs1.Length; i++)
            {
                str2 += subs1[i];
            }
            str2 = str2.ToLower();
            string unique_symbol = string.Empty; // создаем пустой массив символов для записи уникальных символов из введенной строки
            int[] count_unique = new int[str2.Length]; // создаем численный массив для подсчета сколько раз встречается каждый уникальный символ
            for (int i = 0; i < count_unique.Length; i++) // присваиваем каждому элементу массива для подсчета единичку, предпологая что каждый символ в строке встречается хотябы один раз
                count_unique[i] = 1;
            foreach (char i in str2)
            {
                if (!ChekSymbol(unique_symbol, i)) // проверяем на уникальность текущего символа, если нет то выполняться else, если да то записывается в массив для уникальных символов
                    unique_symbol += i.ToString();
                else
                    count_unique[unique_symbol.IndexOf(i)]++; //  добавляем 1 в счетчик символа, если текущий символ не уникальный
            }
            for (int i = 0; i < unique_symbol.Length; i++)
            {
                Console.Write(unique_symbol[i] + ":" + count_unique[i] + ", ");
            }
        }
    }
}
