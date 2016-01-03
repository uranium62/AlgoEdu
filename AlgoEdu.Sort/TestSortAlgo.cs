using System;
using NUnit.Framework;

namespace AlgoEdu.Sort
{
    [TestFixture]
    class TestSortAlgo
    {
        [Test]
        public void SelectSort()
        {
            ISortInteger algo = new SelectSort();

            var array1 = new[] {1, 1, 1, 1, 1};
            var array2 = new[] {1, 2, 3, 4, 5};
            var array3 = new[] {5, 4, 3, 2, 1};
            var array4 = RandomArray(5);

            algo.Sort(array1);
            Assert.That(IsSort(array1));

            algo.Sort(array2);
            Assert.That(IsSort(array2));

            algo.Sort(array3);
            Assert.That(IsSort(array3));

            algo.Sort(array4);
            Assert.That(IsSort(array4));
        }

        [Test]
        public void InsertSort()
        {
            ISortInteger algo = new InsertSort();

            var array1 = new[] { 1, 1, 1, 1, 1 };
            var array2 = new[] { 1, 2, 3, 4, 5 };
            var array3 = new[] { 5, 4, 3, 2, 1 };
            var array4 = RandomArray(5);

            algo.Sort(array1);
            Assert.That(IsSort(array1));

            algo.Sort(array2);
            Assert.That(IsSort(array2));

            algo.Sort(array3);
            Assert.That(IsSort(array3));

            algo.Sort(array4);
            Assert.That(IsSort(array4));
        }

        [Test]
        public void BubbleSort()
        {
            ISortInteger algo = new BubbleSort();

            var array1 = new[] { 1, 1, 1, 1, 1 };
            var array2 = new[] { 1, 2, 3, 4, 5 };
            var array3 = new[] { 5, 4, 3, 2, 1 };
            var array4 = RandomArray(5);

            algo.Sort(array1);
            Assert.That(IsSort(array1));

            algo.Sort(array2);
            Assert.That(IsSort(array2));

            algo.Sort(array3);
            Assert.That(IsSort(array3));

            algo.Sort(array4);
            Assert.That(IsSort(array4));
        }

        [Test]
        public void MergeSort()
        {
            ISortInteger algo = new MergeSort();

            var array1 = new[] { 1, 1, 1, 1, 1 };
            var array2 = new[] { 1, 2, 3, 4, 5 };
            var array3 = new[] { 5, 4, 3, 2, 1 };
            var array4 = RandomArray(5);

            algo.Sort(array1);
            Assert.That(IsSort(array1));

            algo.Sort(array2);
            Assert.That(IsSort(array2));

            algo.Sort(array3);
            Assert.That(IsSort(array3));

            algo.Sort(array4);
            Assert.That(IsSort(array4));
        }

        [Test]
        public void QuickSort()
        {
            ISortInteger algo = new QuickSort();

            var array1 = new[] { 1, 1, 1, 1, 1 };
            var array2 = new[] { 1, 2, 3, 4, 5 };
            var array3 = new[] { 5, 4, 3, 2, 1 };
            var array4 = RandomArray(5);

            algo.Sort(array1);
            Assert.That(IsSort(array1));

            algo.Sort(array2);
            Assert.That(IsSort(array2));

            algo.Sort(array3);
            Assert.That(IsSort(array3));

            algo.Sort(array4);
            Assert.That(IsSort(array4));
        }

        private int[] RandomArray(int length)
        {
            var array = new int[length];

            var randGen = new Random();

            for (int i = 0; i < length; i++)
            {
                array[i] = randGen.Next(0, length);
            }

            return array;
        }

        private bool IsSort(int[] array)
        {
            int i;

            for (i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i+1]) break;
            }

            return i == array.Length - 1;
        }
    }
}
