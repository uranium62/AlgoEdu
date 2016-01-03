namespace AlgoEdu.Sort
{
    class QuickSort : ISortInteger
    {
        public void Sort(int[] array)
        {
            InnerSort(array, 0, array.Length-1);
        }

        public void InnerSort(int[] array, int left, int right)
        {
            var p = array[right-left / 2];

            int i = left, j = right;

            while (i <= j)
            {
                while (array[i] < p) i++;
                while (array[j] > p) j--;

                if (i <= j)
                {
                    var temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }

            }

            if (i < right)
                InnerSort(array, i, right);
            if (j > left)
                InnerSort(array, left, j);
        }
    }
}
