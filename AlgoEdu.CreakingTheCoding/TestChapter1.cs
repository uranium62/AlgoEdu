using System;
using AlgoEdu.CreakingTheCoding.Lib;
using NUnit.Framework;

namespace AlgoEdu.CreakingTheCoding
{
    [TestFixture]
    public class TestChapter1
    {
        [Test]
        public void IsUniqueChars()
        {
            var str1 = "abcdefghijklmnopqrstuvwxyz";
            var str2 = "abc";
            var str3 = "";
            var str4 = "abcaxyz";
            var str5 = "abcabcabc";

            Assert.IsTrue(Chapter1Utils.IsUniqueChars(str1));
            Assert.IsTrue(Chapter1Utils.IsUniqueChars(str2));
            Assert.IsTrue(Chapter1Utils.IsUniqueChars(str3));
            Assert.IsFalse(Chapter1Utils.IsUniqueChars(str4));
            Assert.IsFalse(Chapter1Utils.IsUniqueChars(str5));
        }

        [Test]
        public void Reverse()
        {
            char[] cstr1 = new char[] {};
            char[] cstr2 = new char[] {'a', 'b', 'c', 'd'};
            char[] cstr3 = new char[] {'a', 'b', 'c', 'd', 'e'};

            string str1 = new string(Chapter1Utils.Reverse(cstr1));
            string str2 = new string(Chapter1Utils.Reverse(cstr2));
            string str3 = new string(Chapter1Utils.Reverse(cstr3));

            Assert.That(str1 == "");
            Assert.That(str2 == "dcba");
            Assert.That(str3 == "edcba");
        }

        [Test]
        public void IsAnograms()
        {
            Assert.IsTrue(Chapter1Utils.IsAnogram("dog", "god"));
            Assert.IsTrue(Chapter1Utils.IsAnogram("a", "a"));
            Assert.IsFalse(Chapter1Utils.IsAnogram("abc", "abd"));
            Assert.IsFalse(Chapter1Utils.IsAnogram("abc", "abcd"));
        }

        [Test]
        public void ReplaceSpace()
        {
            var str1  = "Hi, my name is Alex";
            var cstr1 = str1.ToCharArray();

            var cstr2 = Chapter1Utils.ReplaceSpace(cstr1);
            var str2 = new string(cstr2);

            Assert.That(str2 == "Hi,%20my%20name%20is%20Alex");
        }

        [Test]
        public void Compress()
        {
            var str = "aabcccaaa";

            var res = Chapter1Utils.Compress(str);

            Assert.That(res == "a2b1c3a3");
        }

        [Test]
        public void Rotate()
        {
            var mat1 = new int[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            };
            var mat2 = new int[,]
            {
                { 1, 2, 3, 4, 5 },
                { 6, 7, 8, 9, 10 },
                { 11, 12, 13, 14, 15 },
                { 16, 17, 18, 19, 20 },
                { 21, 22, 23, 24, 25 }
            };

            Chapter1Utils.Rotate(mat1, 4);
            Chapter1Utils.Rotate(mat2, 5);

            Assert.That(mat1.IsEquals(new int[,]
            {
                { 4, 8, 12, 16 },
                { 3, 7, 11, 15 },
                { 2, 6, 10, 14 },
                { 1, 5, 9,  13 }
            }));

            Assert.That(mat2.IsEquals(new int[,]
            {
                { 5, 10, 15, 20, 25},
                { 4, 9, 14, 19, 24 },
                { 3, 8, 13, 18, 23 },
                { 2, 7, 12, 17, 22 },
                { 1, 6, 11, 16, 21 }
            }));

        }

        [Test]
        public void Suffle()
        {
            var arr = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            Chapter1Utils.Suffle(arr);

            Assert.False(arr.IsEquals(new [] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}));
        }

        [Test]
        public void Zero()
        {
            int[,] mat1 = new int[,]
            {
                { 1, 2, 3 },
                { 4, 0, 6 },
                { 7, 8, 9 }
            };
            int[,] mat2 = new int[,]
            {
                {0, 2, 3, 4, 5},
                {6, 0, 8, 9, 10},
                {11, 12, 0, 14, 15},
                {16, 17, 18, 0, 20},
                {21, 22, 23, 24, 0}
            };

            Chapter1Utils.Zero(mat1);
            Chapter1Utils.Zero(mat2);

            Assert.That(mat1.IsEquals(new int[,]
            {
                { 1, 0, 3 },
                { 0, 0, 0 },
                { 7, 0, 9 }
            }));
            Assert.That(mat2.IsEquals(new int[,]
            {
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 }
            }));
        }

        [Test]
        public void IsRotate()
        {
            string str1 = "waterbottle";
            string str2 = "erbottlewat";

            string str3 = "abcdefg";
            string str4 = "efXabcd";

            Assert.True(Chapter1Utils.IsRotation(str1, str2));
            Assert.False(Chapter1Utils.IsRotation(str3, str4));

        }

        [Ignore("need fix")]
        public void Calc()
        {
            var eps = 0.00000001; 
            var str1 = "23 + 37 + 22 + 40";
            var str2 = "20 + 34 * 2 / 4 + 100";
            var str3 = "20 + 34 * 2 / 4 + 100 / 2";
            var str4 = "3,5 + 7,50 * 2";
            var str5 = "(20 + 8) * 3 * (40 + 20 * 2 * 2 + 10 * (3 * (2-1)))";

            var res1 = Chapter1Utils.Calc(str1);
            var res2 = Chapter1Utils.Calc(str2);
            var res3 = Chapter1Utils.Calc(str3);
            var res4 = Chapter1Utils.Calc(str4);
            var res5 = Chapter1Utils.Calc(str5);

            Assert.That(Math.Abs(res1 - 122) < eps);
            Assert.That(Math.Abs(res2 - 137) < eps);
            Assert.That(Math.Abs(res3 - 87) < eps);
            Assert.That(Math.Abs(res4 - 18.5) < eps);
            Assert.That(Math.Abs(res5 - 18.5) < eps);

        }

        [Ignore("need fix")]
        public void ReadBlack()
        {
            var tree = new RedBlackTree<int>();

            tree.Add(10);
            tree.Add(85);
            tree.Add(15);
            tree.Add(70);
            tree.Add(20);
            tree.Add(60);
            tree.Add(30);
            tree.Add(50);
            tree.Add(65);
            tree.Add(80);
            tree.Add(90);
            tree.Add(40);
            tree.Add(5);
            tree.Add(55);

            Assert.That(true);
        }
    }
}
