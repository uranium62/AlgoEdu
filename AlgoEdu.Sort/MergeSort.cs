using System;

namespace AlgoEdu.Sort
{
    class MergeSort : ISortInteger
    {
        public void Sort(int[] array)
        {
            InnerSort(array);
        }

        private void InnerSort(int[] array)
        {
            if (array.Length < 2) return;

            var middle = array.Length / 2;
            var length = middle + array.Length % 2;

            int[] leftarr  = new int[length];
            int[] rightarr = new int[middle];

            Array.Copy(array, 0, leftarr, 0, length);
            Array.Copy(array, length, rightarr, 0, middle);

            InnerSort(leftarr);
            InnerSort(rightarr);

            int i = 0, j = 0, idx = 0;

            while (i < leftarr.Length && j < rightarr.Length)
            {
                if (leftarr[i] > rightarr[j])
                {
                    array[idx] = rightarr[j];
                    j++;
                }
                else
                {
                    array[idx] = leftarr[i];
                    i++;
                }

                idx++;
            }

            while (i < leftarr.Length)
            {
                array[idx] = leftarr[i];
                i++;
                idx++;
            }

            while (j < rightarr.Length)
            {
                array[idx] = rightarr[j];
                j++;
                idx++;
            }

        }
    }
}
