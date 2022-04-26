using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetPrograms
{
    [TestClass]
    public class LRUCacheTest
    {
        /*
         * Design and implement the LRU cache with TTL.
            get(Key, timestamp) - Get value of key at time, return -1 if not exists.
            put(key, value, expireTimestamp) - Set or update value for a key.
            When cache reaches capacity, evict LRU item. Also, after record expires, 
            record will still be in cache but inquiries will get -1.
            All input ts will be in unix time, postive int in seconds.

           // Ref: https://aonecode.com/LRU-Cache-II-TTL
           // Ref: https://github.com/tejacques/LRUCache/blob/master/src/LRUCache/LRUCache.cs
        */

        [TestMethod]
        public void LRUCacheTestBasic()
        {
            var ttlcache = new LRUCache<int, int>(2);
            ttlcache.Add(1, 10);
            ttlcache.Add(2, 20);
            Assert.AreEqual(10, ttlcache.Get(1)); // 10
            Assert.AreEqual(20, ttlcache.Get(2)); // 20
            Assert.AreEqual(-1, ttlcache.Get(3)); // -1
            ttlcache.Add(3, 30);
            ttlcache.Add(1, 10);
            ttlcache.Add(4, 40);
            Assert.AreEqual(40, ttlcache.Get(4)); // -1
            Assert.AreEqual(-1, ttlcache.Get(3)); // -1
            ttlcache.Add(5, 50);
            Assert.AreEqual(-1, ttlcache.Get(1)); // -1
        }
    }

    public class LRUCache<K, V>
    {
        private int capacity;
        private Dictionary<K, LinkedListNode<LRUCacheItem<K, V>>> cacheMap = new();
        private LinkedList<LRUCacheItem<K, V>> lruList = new();

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public V Get(K key)
        {
            LinkedListNode<LRUCacheItem<K, V>> node;
            if (cacheMap.TryGetValue(key, out node))
            {
                V value = node.Value.value;
                lruList.Remove(node);
                lruList.AddLast(node);
                return value;
            }

            if (typeof(V) == typeof(int))
            {
                return (V)(object)-1;
            }
            else
            {
                return default(V);
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Add(K key, V val)
        {
            if (cacheMap.TryGetValue(key, out var existingNode))
            {
                lruList.Remove(existingNode);
            }
            else if (cacheMap.Count >= capacity)
            {
                RemoveFirst();
            }

            LRUCacheItem<K, V> cacheItem = new LRUCacheItem<K, V>(key, val);
            LinkedListNode<LRUCacheItem<K, V>> node = new LinkedListNode<LRUCacheItem<K, V>>(cacheItem);
            lruList.AddLast(node);
            // cacheMap.Add(key, node); - here's bug if try to add already existing value
            cacheMap[key] = node;
        }

        private void RemoveFirst()
        {
            // Remove from LRUPriority
            LinkedListNode<LRUCacheItem<K, V>> node = lruList.First;
            lruList.RemoveFirst();

            // Remove from cache
            cacheMap.Remove(node.Value.key);
        }
    }

    class LRUCacheItem<K, V>
    {
        public LRUCacheItem(K k, V v)
        {
            key = k;
            value = v;
        }
        public K key;
        public V value;
    }
}
