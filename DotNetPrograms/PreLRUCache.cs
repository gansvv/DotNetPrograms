using System.Collections.Generic;
using System.Linq;

namespace DotNetPrograms
{
    public class PreLRUCache
    {
        private LinkedList<KeyValuePair<int, int>> list;
        private Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> map;
        private int capacity;
        public PreLRUCache(int capacity)
        {
            this.capacity = capacity;
            list = new LinkedList<KeyValuePair<int, int>>();
            map = new Dictionary<int, LinkedListNode<KeyValuePair<int, int>>>();
        }

        public int Get(int key)
        {
            if (!map.ContainsKey(key)) return -1;
            var node = map[key];
            list.Remove(node);
            map[key] = list.AddFirst(node.Value);
            return node.Value.Value;
        }

        public void Put(int key, int value)
        {
            if (map.ContainsKey(key))
            {
                var node = map[key];
                list.Remove(node);
                map[key] = list.AddFirst(new KeyValuePair<int, int>(key, value));
            }
            else
            {
                if (list.Count >= this.capacity)
                {
                    map.Remove(list.Last().Key);
                    list.RemoveLast();
                }
                map[key] = list.AddFirst(new KeyValuePair<int, int>(key, value));
            }
        }
    }
}
