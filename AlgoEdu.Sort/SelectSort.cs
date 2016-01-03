using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoEdu.Sort
{
    class SelectSort : ISortInteger
    {
        public void Sort(int[] array)
        {
            for (int i = 0; i < array.Length-1; i++)
            {
                int min= i;

                for (int j=i+1; j < array.Length; j++)
                {
                    if (array[min] > array[j])
                    {
                        var temp = array[min];
                        array[min] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }
}
