using Labb4;
using NUnit.Framework;

using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        private ITree t;
        [SetUp]
        public void Setup()
        {
            t = new Tree();

            KeyValuePair<string, int>[] l = new KeyValuePair<string, int>[]
            {
                new KeyValuePair<string, int>("a", 1),
                new KeyValuePair<string, int>("b", 1),
                new KeyValuePair<string, int>("c", 1),
                new KeyValuePair<string, int>("d", 1),
                new KeyValuePair<string, int>("e", 1),
                new KeyValuePair<string, int>("a", 1),
                new KeyValuePair<string, int>("a", 1),
                new KeyValuePair<string, int>("b", 1),
                new KeyValuePair<string, int>("c", 1),
                new KeyValuePair<string, int>("c", 1),
            };

            foreach (KeyValuePair<string, int> d in l)
            {
                if (t.Contains(d.Key))
                {
                    t.Set(d.Key, t.Get(d.Key) + 1);
                }
                else
                {
                    t.Add(d.Key, d.Value);
                }
            }
        }

        [Test]
        public void Test_Add()
        {
            Assert.AreEqual(5, t.Count);
            t.Add("f", 1);
            t.Add("k", 1);
            Assert.AreEqual(7, t.Count);
        }
        [Test]
        public void Test_Remove()
        {
            Assert.AreEqual(5, t.Count);
            t.Remove("a");
            Assert.AreEqual(4, t.Count);
            t.Remove("z");
            Assert.AreEqual(4, t.Count);
            t.Remove("b");
            Assert.AreEqual(3, t.Count);
        }
        
        [Test]
        public void Test_Contains()
        {
            Assert.IsTrue(t.Contains("a"));
            Assert.IsTrue(t.Contains("b"));
            Assert.IsTrue(t.Contains("c"));
            Assert.IsFalse(t.Contains("z"));
        }

        [Test]
        public void Test_Get()
        {
            Assert.AreEqual(3, t.Get("a"));
            Assert.AreEqual(2, t.Get("b"));
            Assert.AreEqual(1, t.Get("e"));
            Assert.Throws<KeyNotFoundException>( () => t.Get("z"));
        }

        [Test]
        public void Test_Set()
        {
            t.Set("a", 100);
            Assert.AreEqual(100, t.Get("a"));
            t.Set("b", 55);
            Assert.AreEqual(55, t.Get("b"));
            Assert.Throws<KeyNotFoundException>(() => t.Set("z", 1));
        }
        [Test]
        public void Test_Height()
        {
            ITree p = new Tree();
            Assert.AreEqual(-1, p.Height());
            Assert.AreEqual(4, t.Height());
        }

        [Test]
        public void Test_Traverse_InOrder()
        {
            var k = t.Traverse(SortOrder.In);
            Assert.AreEqual("a", k[0].Key);
            Assert.AreEqual(3, k[0].Value);
            Assert.AreEqual("d", k[3].Key);
            Assert.AreEqual(1, k[3].Value);
        }

        [Test]
        public void Test_Traverse_PreOrder()
        {
            var k = t.Traverse(SortOrder.Pre);
            Assert.AreEqual("a", k[0].Key);
            Assert.AreEqual(3, k[0].Value);
            Assert.AreEqual("c", k[2].Key);
            Assert.AreEqual(3, k[2].Value);
        }

        [Test]
        public void Test_Traverse_PostOrder()
        {
            var k = t.Traverse(SortOrder.Post);
            Assert.AreEqual("e", k[0].Key);
            Assert.AreEqual(1, k[0].Value);
            Assert.AreEqual("a", k[4].Key);
            Assert.AreEqual(2, k[3].Value);
        }
    }
}