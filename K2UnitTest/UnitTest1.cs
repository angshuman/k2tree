using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TripleStore.Graph;

namespace K2UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var k2 = new K2Tree(32);

            var random = new Random();
            var key1 = random.Next();
            var key2 = random.Next();
            k2.Set(key1, key2);

            var rsp = k2.Get(key1, key2);
            Assert.IsTrue(rsp);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var k2 = new K2Tree(32);

            var random = new Random();

            var check = new Dictionary<int, int>();
            for (int i = 0; i < 1000000; i++)
            {
                var key1 = random.Next();
                var key2 = random.Next();
                if (check.ContainsKey(key1))
                {
                    continue;
                }

                k2.Set(key1, key2);
                check[key1] = key2;

                var rsp = k2.Get(key1, key2);
                Assert.IsTrue(rsp);
            }

            foreach (var key in check.Keys)
            {
                var expected1 = check[key];

                var actual1 = k2.GetByX(key);
                var actual2 = k2.GetByY(expected1);

                Assert.IsTrue(actual1[0] == expected1);
                Assert.IsTrue(actual2.ToList().Contains(key));
            }
        }
    }
}
