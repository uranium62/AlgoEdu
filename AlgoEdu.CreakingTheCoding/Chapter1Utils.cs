using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using AlgoEdu.CreakingTheCoding.Lib;

namespace AlgoEdu.CreakingTheCoding
{
    public static class Chapter1Utils
    {
        /// <summary>
        /// Реализуйте алгоритм, определяющий, все ли символы в строке встречаются один раз.
        /// При выполнении этого задания нельзя использовать дополнительные структуры данных.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUniqueChars(string str)
        {
            if (str.Length > 256)
            {
                return false;
            }

            var checker = 0;

            for (var i = 0; i < str.Length; i++)
            {
                var val = str[i] - 'a';

                if ((checker & (1 << val)) > 0)
                {
                    return false;
                }
                checker |= (1 << val);
            }

            return true;
        }

        /// <summary>
        /// Реализуйте функцию Reverse
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static char[] Reverse(char[] str)
        {
            int i = 0;
            int j = str.Length - 1;

            while (i < j)
            {
                var tmp = str[i];
                str[i] = str[j];
                str[j] = tmp;

                i++;
                j--;
            }
            return str;
        }

        /// <summary>
        /// Для двух строк напишите метод, определяющий, является ли одна строка перестановкой другой
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static bool IsAnogram(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                return false;
            }

            var letters = new int[256];

            for (int i = 0; i < str1.Length; i++)
            {
                ++letters[str1[i]];
            }

            for (int i = 0; i < str2.Length; i++)
            {
                if (--letters[str2[i]] < 0)
                {
                    return false;
                }
            }

            return true;

        }

        /// <summary>
        /// Напишите метод заполняющий все пробелы %20.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static char[] ReplaceSpace(char[] str)
        {
            int i = 0;
            int count = 0;
            for (i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    count ++;
                }
            }

            char[] buf = new char[str.Length + count * 2];
            int j = buf.Length - 1;

            for (i = str.Length - 1; i >= 0; i--)
            {
                if (str[i] == ' ')
                {
                    buf[j--] = '0';
                    buf[j--] = '2';
                    buf[j--] = '%';
                }
                else
                {
                    buf[j] = str[i];
                    j--;
                }  
            }

            return buf;
        }

        /// <summary>
        /// Реализуйте метод, осуществляющий сжатие строки, на основе счетчика повторяющихся символов.
        /// Например, строка aabccccccaaa должна превратиться в a2b1c5a3. Если "сжатая" строка оказывается
        /// длинее исходной, метод должен вернуть исходную строку
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Compress(string str)
        {
            var buffer = new StringBuilder(1000);

            char last = str[0];
            int count = 1;

            for (int i = 1; i < str.Length; i++)
            {
                if (last == str[i])
                {
                    count++;
                }
                else
                {
                    buffer.Append(last);
                    buffer.Append(count);

                    last = str[i];
                    count = 1;
                }
            }

            buffer.Append(last);
            buffer.Append(count);

            if (str.Length < buffer.Length)
            {
                return str;
            }

            return buffer.ToString();

        }
        
        /// <summary>
        /// Перестановка элементов в массиве
        /// </summary>
        /// <param name="arr"></param>
        public static void Suffle(int[] arr)
        {
            var rand = new Random();

            for(int i=0; i <arr.Length; i++)
            {
                int j = rand.Next(i+1);

                var tmp = arr[i];
                arr[i]  = arr[j];
                arr[j]  = tmp;
            }
        }

        /// <summary>
        /// Дано: изображение в виде матрицы размером NxN, где каждый пиксель занимает 4 байта.
        /// Напишите метод, поворачивающий изображение на 90
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="n"></param>
        public static void Rotate(int[,] matrix, int n)
        {
            for (int i = 0; i < n/2; i++)
            {
                int first = i;
                int last  = n - i - 1;

                for (int j = first; j < last; j++)
                {
                    // left
                    int left = matrix[j, first];
                    int offset = last - j + first;

                    // top -> left
                    matrix[j, first] = matrix[first, offset];

                    // right -> top
                    matrix[first, last - j + first] = matrix[offset, last];

                    // buttom -> right
                    matrix[offset, last] = matrix[last, j];

                    // left -> buttom
                    matrix[last, j] = left;
                }
            }
        }

        /// <summary>
        /// Напишите алгоритм, реализующий следующее условие: если элементы матрицы в точке M x N, то весь столбец и вся строка обнуляются
        /// </summary>
        /// <param name="matrix"></param>
        public static void Zero(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            bool[] row = new bool[n];
            bool[] column = new bool[m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        row[i] = true;
                        column[j] = true;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (row[i] || column[j])
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

        }

        /// <summary>
        /// Для двух строк, str1 и str2, напишите код проверки, получена ли строка str2 циклическим сдвигом str1
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static bool IsRotation(string str1, string str2)
        {
            string str3 = str1 + str1;

            return str3.IndexOf(str2) != -1;

        }

        /// <summary>
        /// Напишите метод вычисляющий строковое выражение
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double Calc(string str)
        {

            Stack<Arg> stack = new Stack<Arg>();
            StringBuilder buf = new StringBuilder();

            int opers = 0;
            Arg last  = null;

            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] >= '0' && str[i] <= '9') || (str[i] == ','))
                {
                    buf.Append(str[i]);
                }
                else if (str[i] == '-' || str[i] == '+' || str[i] == '/' || str[i] == '*')
                {
                    if (buf.Length > 0)
                    {
                        stack.Push(new Arg(double.Parse(buf.ToString())));
                        buf.Clear();
                        opers++;
                    }

                    var current = new Arg(str[i]);

                    if (opers > 2 && last.IsGreterOrEqualPriorThan(current))
                    {
                        var arg2 = stack.Pop();
                        var oper = stack.Pop();
                        var arg1 = stack.Pop();

                        stack.Push(oper.Calc(arg1, arg2));
                        opers=1;
                    }

                    last = current;
                    stack.Push(current);
                    opers++;
                }
                else if (str[i] == '(')
                {
                    stack.Push(new Arg(str[i]));
                    opers = 0;
                }
                else if (str[i] == ')')
                {
                    if (buf.Length > 0)
                    {
                        stack.Push(new Arg(double.Parse(buf.ToString())));
                        buf.Clear();
                    }
                    while (stack.Peek().Type != ArgType.Noun)
                    {
                        var arg2 = stack.Pop();
                        var oper = stack.Pop();
                        var arg1 = stack.Pop();

                        stack.Push(oper.Calc(arg1, arg2));
                    }
                    stack.Pop();
                    opers = 0;
                }
            }

            if (buf.Length > 0)
            {
                stack.Push(new Arg(double.Parse(buf.ToString())));
                buf.Clear();
            }
            while (stack.Count != 1)
            {
                var arg2 = stack.Pop();
                var oper = stack.Pop();
                var arg1 = stack.Pop();

                stack.Push(oper.Calc(arg1, arg2));
            }

            return stack.Pop().Value;
        }


    }
}
