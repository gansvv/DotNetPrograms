using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetPrograms.LruCacheWithTtl
{
    [TestClass]
    public class LRUCacheWithTTLTest
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
        public void LRUCacheWithTTLTestBasic()
        {
            var ttlcache = new LRUCacheWithTTL<int, int>(2);
            /*
            ttlc ache.Put(1, 3, 10);
            ttlcache.Put(2, 4, 5);
            Assert.AreEqual(3, ttlcache.Get(1, 1)); // 3
            ttlcache.Get(1, 11); // -1
            ttlcache.Get(2, 5); // 4
            ttlcache.Get(2, 6); // -1
            ttlcache.Put(3, 100, 10); // evict 2
            ttlcache.Get(2, 1); // -1
            ttlcache.Put(4, 4, 10); // evict 1
            ttlcache.Get(1, 1); // -1
            ttlcache.Get(3, 1); // 100
            ttlcache.Get(4, 1); // 4*/
        }
    }

    class LRUCacheWithTTL<K, V>
    {
        private int capacity;
        private Dictionary<K, LinkedListNode<LRUCacheItem<K, V>>> cacheMap = new();
        private LinkedList<LRUCacheItem<K, V>> lruList = new();
        private TimeSpan _ttl;
        private Timer _timer;
        private int count;
        private LRUCacheItem<K,V> _head;
        private LRUCacheItem<K,V> _tail;

        public LRUCacheWithTTL(int capacity, int seconds = 0)
        {
            this.capacity = capacity;
            this._ttl = new TimeSpan(seconds);
            if (this._ttl > TimeSpan.Zero)
            {
                this._timer = new Timer(
                    Purge,
                    null,
                    (int)this._ttl.TotalMilliseconds,
                    5000); // 5 seconds
            }
        }
        private void Purge(object state)
        {
            if (this._ttl <= TimeSpan.Zero || this.count == 0)
            {
                return;
            }

            lock (this)
            {
                var current = this._tail;
                var now = DateTime.UtcNow;

                while (null != current
                    && (now - current.lastAccessed) > this._ttl)
                {
                    /*Remove(current);
                    // Going backwards
                    current = current.Prev;*/
                }
            }
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

            LRUCacheItem<K, V> cacheItem = new (key, val);
            LinkedListNode<LRUCacheItem<K, V>> node = new (cacheItem);
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
            lastAccessed = DateTime.Now;
        }

        public K key;
        public V value;
        public DateTime lastAccessed { get; set; }
    }
}
