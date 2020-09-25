using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalPractise
{
    class BasicTrieTree
    {
        // 字符串的公共前缀只保存一次
        // 208 实现前缀树
        public class Trie
        {
            public class TireNode
            {
                public char c;
                public Dictionary<char, TireNode> children=new Dictionary<char, TireNode>();
                public bool isWord = false;

                public TireNode()
                {
                }
                public TireNode(char c)
                {
                    this.c = c;
                }

            }
            /** Initialize your data structure here. */

            TireNode root;

            public Trie()
            {
                root = new TireNode();
            }

            /** Inserts a word into the trie. */
            public void Insert(string word)
            {
                Dictionary<char, TireNode> child = root.children;
                TireNode next = null;
                for (int i = 0; i < word.Length; i++)
                {
                    char c = word[i];
                    if (child.ContainsKey(c))
                    {
                        next = child[c];
                    }
                    else
                    {
                        next = new TireNode(c);
                        child.Add(c, next);
                    }

                    child = next.children;

                    if (i == word.Length-1)
                    {
                        next.isWord = true;
                    }
                }
            }

            public TireNode SearchNode(String str)
            {
                Dictionary<char, TireNode> child = root.children;
                TireNode next = null;
                for (int i = 0; i < str.Length; i++)
                {
                    char c = str[i];

                    if (child.ContainsKey(c))
                    {
                        next = child[c];
                    }
                    else
                    {
                        return null;
                    }

                    child = next.children;
                }

                return next;
            }

            /** Returns if the word is in the trie. */
            public bool Search(string word)
            {
                TireNode s = SearchNode(word);
                return s != null && s.isWord;
            }

            /** Returns if there is any word in the trie that starts with the given prefix. */
            public bool StartsWith(string prefix)
            {
                return SearchNode(prefix) != null;
            }
        }

        //212 单词搜索


    }
}
