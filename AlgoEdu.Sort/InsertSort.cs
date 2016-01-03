namespace AlgoEdu.Sort
{
    class InsertSort : ISortInteger
    {
        public void Sort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int j = i + 1;

                while (j > 0 && array[j - 1] > array[j])
                {
                    var temp = array[j - 1];
                    array[j - 1] = array[j];
                    array[j] = temp;
                    j--;
                }  
            }
        }
    }
}
