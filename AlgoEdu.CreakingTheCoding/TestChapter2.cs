using AlgoEdu.CreakingTheCoding.Lib;
using NUnit.Framework;

namespace AlgoEdu.CreakingTheCoding
{
    [TestFixture]
    public class TestChapter2
    {
        [Test]
        public void DeleteDub1()
        {
            var lst1 = new ListNodeBuilder<int>()
                .Add(1)
                .Build();

            var lst2 = new ListNodeBuilder<int>()
                .Add(1)
                .Add(1)
                .Build();

            var lst3 = new ListNodeBuilder<int>()
                .Add(new[] { 1, 1, 2, 3, 2, 4 })
                .Build();

            Chapter2Utils.DeleteDub1(lst1);
            Chapter2Utils.DeleteDub1(lst2);
            Chapter2Utils.DeleteDub1(lst3);

            Assert.That(lst1.Value == 1);
            Assert.That(lst1.Next == null);

            Assert.That(lst2.Value == 1);
            Assert.That(lst2.Next == null);

            Assert.That(lst3.Value == 1);
            Assert.That(lst3.Next.Value == 2);
            Assert.That(lst3.Next.Next.Value == 3);
            Assert.That(lst3.Next.Next.Next.Value == 4);
            Assert.That(lst3.Next.Next.Next.Next == null);
        }

        [Test]
        public void DeleteDub2()
        {
            var lst1 = new ListNodeBuilder<int>()
                .Add(1)
                .Build();

            var lst2 = new ListNodeBuilder<int>()
                .Add(1)
                .Add(1)
                .Build();

            var lst3 = new ListNodeBuilder<int>()
                .Add(new []{1, 1, 2, 3, 2, 4})
                .Build();

            Chapter2Utils.DeleteDub2(lst1);
            Chapter2Utils.DeleteDub2(lst2);
            Chapter2Utils.DeleteDub2(lst3);

            Assert.That(lst1.Value == 1);
            Assert.That(lst1.Next == null);

            Assert.That(lst2.Value == 1);
            Assert.That(lst2.Next == null);

            Assert.That(lst3.Value == 1);
            Assert.That(lst3.Next.Value == 2);
            Assert.That(lst3.Next.Next.Value == 3);
            Assert.That(lst3.Next.Next.Next.Value == 4);
            Assert.That(lst3.Next.Next.Next.Next == null);
        }

        [Test]
        public void Find()
        {
            var list = new ListNodeBuilder<int>()
                .Add(new [] {1, 2, 3, 4, 5, 6, 7, 8})
                .Build();

            var node1 = Chapter2Utils.Find(list, 1);
            var node2 = Chapter2Utils.Find(list, 3);
            var node3 = Chapter2Utils.Find(list, 4);

            Assert.That(node1.Value == 8);
            Assert.That(node2.Value == 6);
            Assert.That(node3.Value == 5);
        }

        [Test]
        public void Delete()
        {
            var list1 = new ListNodeBuilder<int>()
                .Add(1)
                .Build();

            var list2 = new ListNodeBuilder<int>()
                .Add(new [] {1, 2})
                .Build();

            Assert.False(Chapter2Utils.DeleteFirst(list1));
            Assert.True(Chapter2Utils.DeleteFirst(list2));

        }

        [Test]
        public void Position()
        {
            var list = new ListNodeBuilder<int>()
                .Add(new [] {9, 8, 7, 4, 3, 1})
                .Build();

            var res = Chapter2Utils.Position(list, 4);

            Assert.That(res.Value <= 4 );
            Assert.That(res.Next.Value <= 4);
            Assert.That(res.Next.Next.Value <= 4);
            Assert.That(res.Next.Next.Next.Value > 4);
        }
    }
}
