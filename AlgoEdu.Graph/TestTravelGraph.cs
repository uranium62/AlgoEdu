using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace AlgoEdu.Graph
{
    [TestFixture]
    class TestTravelGraph
    {
        [Test]
        public void FindRoot()
        {
            IRootFinder finder = new RootFinder();

            byte[,] graph1 = {
                { 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1}
            };

            byte[,] graph2 =
            {
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0}
            };

            byte[,] graph3 =
           {
                {0, 0, 0, 0, 0},
                {1, 0, 0, 0, 0},
                {0, 1, 0, 0, 1},
                {0, 0, 0, 0, 1},
                {1, 0, 0, 0, 0}
            };

            int root;
            Assert.Throws<ArgumentException>(() =>
            {
                finder.Root(graph1);
            });

            root = finder.Root(graph2);
            Assert.That(root, Is.EqualTo(0));

            root = finder.Root(graph3);
            Assert.That(root, Is.EqualTo(2));
        }

    }
}
