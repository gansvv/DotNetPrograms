using System;

namespace DotNetPrograms
{
    // Implementation of search and insert operations on Trie
    class Trie
    {
        /*Insert and search costs O(key_length), however the memory requirements of Trie is O(ALPHABET_SIZE* key_length * N) where N is number of keys in Trie.There are efficient representation of trie nodes(e.g.compressed trie, ternary search tree, etc.) to minimize memory requirements of trie.
         */

        // Alphabet size (# of symbols)
        static readonly int ALPHABET_SIZE = 26;

        // trie node
        class TrieNode
        {
            public TrieNode[] children = new TrieNode[ALPHABET_SIZE];

            // isEndOfWord is true if the node represents
            // end of a word
            public bool isEndOfWord;

            public TrieNode()
            {
                isEndOfWord = false;
                for (int i = 0; i < ALPHABET_SIZE; i++)
                    children[i] = null;
            }
        };

        static TrieNode root;

        // If not present, inserts key into trie
        // If the key is prefix of trie node,
        // just marks leaf node
        static void Insert(String key)
        {
            int level;
            int length = key.Length;
            int index;

            TrieNode trieNode = root;

            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';
                if (trieNode.children[index] == null)
                    trieNode.children[index] = new TrieNode();

                trieNode = trieNode.children[index];
            }

            // mark last node as leaf
            trieNode.isEndOfWord = true;
        }

        // Returns true if key
        // presents in trie, else false
        static bool Search(String key)
        {
            int level;
            int length = key.Length;
            int index;
            TrieNode trieNode = root;

            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';

                if (trieNode.children[index] == null)
                    return false;

                trieNode = trieNode.children[index];
            }

            return (trieNode.isEndOfWord);
        }

        // Driver
        public static void Run()
        {
            // Input keys (use only 'a'
            // through 'z' and lower case)
            String[] keys = {"the", "a", "there", "answer", "any", "by", "bye", "their"};

            String[] output = { "Not present in trie", "Present in trie" };


            root = new TrieNode();

            // Construct trie
            int i;
            for (i = 0; i < keys.Length; i++)
                Insert(keys[i]);

            // Search for different keys
            if (Search("the") == true)
                Console.WriteLine("the --- " + output[1]);
            else Console.WriteLine("the --- " + output[0]);

            if (Search("these") == true)
                Console.WriteLine("these --- " + output[1]);
            else Console.WriteLine("these --- " + output[0]);

            if (Search("their") == true)
                Console.WriteLine("their --- " + output[1]);
            else Console.WriteLine("their --- " + output[0]);

            if (Search("thaw") == true)
                Console.WriteLine("thaw --- " + output[1]);
            else Console.WriteLine("thaw --- " + output[0]);

        }
    }
}
