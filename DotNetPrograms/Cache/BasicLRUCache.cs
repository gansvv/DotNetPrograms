using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetPrograms
{
    [TestClass]
    public class BasicLruCacheUnitTest
    {
        [TestMethod]
        public void LruCacheTest()
        {
            var cache = new BasicLruCache<int, string>(2);

            cache.Put(1, "One");
            cache.Put(2, "Two");
            Assert.AreEqual("One", cache.Get(1));
            cache.Put(3, "Three");
            Assert.IsNull(cache.Get(2));
            cache.Put(4, "Four");
            Assert.IsNull(cache.Get(1));
            Assert.AreEqual("Three", cache.Get(3));
            Assert.AreEqual("Four", cache.Get(4));
        }
    }

    public class BasicLruCache<TKey, TValue>
    {
        private int capacity;
        private Dictionary<TKey, TValue> valueCache;
        private Dictionary<TKey, LinkedListNode<TKey>> nodeCache;
        private LinkedList<TKey> orderList;

        public BasicLruCache(int capacity)
        {
            this.capacity = capacity;
            this.valueCache = new Dictionary<TKey, TValue>(capacity);
            this.nodeCache = new Dictionary<TKey, LinkedListNode<TKey>>(capacity);
            this.orderList = new LinkedList<TKey>();
        }

        public void Put(TKey key, TValue value)
        {
            if (this.valueCache.ContainsKey(key)) // Key already exists.
            {
                this.Promote(key);
                this.valueCache[key] = value;
                return;
            }

            if (this.valueCache.Count == capacity) // Cache full.
            {
                this.RemoveLast();
            }

            this.AddFirst(key, value);
        }

        public TValue Get(TKey key)
        {
            if (!this.valueCache.ContainsKey(key))
            {
                return default;
            }

            this.Promote(key);
            return this.valueCache[key];
        }

        private void AddFirst(TKey key, TValue value)
        {
            var node = new LinkedListNode<TKey>(key);
            this.valueCache[key] = value;
            this.nodeCache[key] = node;
            this.orderList.AddFirst(node);
        }

        private void Promote(TKey key)
        {
            LinkedListNode<TKey> node = this.nodeCache[key];
            this.orderList.Remove(node);
            this.orderList.AddFirst(node);
        }

        private void RemoveLast()
        {
            LinkedListNode<TKey> lastNode = this.orderList.Last;
            this.valueCache.Remove(lastNode.Value);
            this.nodeCache.Remove(lastNode.Value);
            this.orderList.RemoveLast();
        }
    }
}
