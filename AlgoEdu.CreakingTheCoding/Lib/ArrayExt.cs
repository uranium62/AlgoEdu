using System;

namespace AlgoEdu.CreakingTheCoding.Lib
{
    public static class ArrayExt
    {
        public static bool IsEquals(this int[,] matrix1, int[,] matrix2)
        {
            if (matrix1 == null)
            {
                throw new ArgumentNullException(nameof(matrix1));
            }
            if (matrix2 == null)
            {
                throw new ArgumentNullException(nameof(matrix2));
            }

            int n1 = matrix1.GetLength(0);
            int m1 = matrix1.GetLength(1);
            int n2 = matrix2.GetLength(0);
            int m2 = matrix2.GetLength(1);

            if (n1 != n2 && m1 != m2)
            {
                throw new ArgumentException("dimension");
            }

            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < m1; j++)
                {
                    if (matrix1[i, j] != matrix2[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool IsEquals(this int[] array1, int[] array2)
        {
            if (array1 == null)
            {
                throw new ArgumentNullException(nameof(array1));
            }
            if (array2 == null)
            {
                throw new ArgumentNullException(nameof(array2));
            }
            if (array1.Length != array2.Length)
            {
                throw new ArgumentException("dimension");
            }

            for (int i=0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
