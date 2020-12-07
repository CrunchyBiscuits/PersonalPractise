using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalPractise
{
    class bilibili
    {
        // 20 有效括号
        public bool IsValid(string s)
        {
            if (s == null || s.Length < 1)
            {
                return true;
            }
            if (s.Length % 2 != 0)
            {
                return false;
            }
            Dictionary<char, char> helper = new Dictionary<char, char>();
            
            helper[')'] = '(';
            helper[']'] = '[';
            helper['}'] = '{';

            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (helper.ContainsKey(s[i]))
                {
                    if (stack.Count==0||stack.Peek()!=helper[s[i]])
                    {
                        return false;
                    }
                    stack.Pop();
                }
                else
                {
                    stack.Push(s[i]);
                }
            }
            return stack.Count==0;
        }
    }
}
