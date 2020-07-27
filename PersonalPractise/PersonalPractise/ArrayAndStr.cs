using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonalPractise
{
    class ArrayAndStr
    {
        public static void Main(string[] args)
        {

        }

        // 面试金典1.1 https://leetcode-cn.com/problems/is-unique-lcci/submissions/
        public bool IsUnique(string astr)
        {
            //HashSet<char> temp = new HashSet<char>();
            //foreach(char s in astr.ToCharArray())
            //{
            //    if (!temp.Contains(s))
            //    {
            //        temp.Add(s);
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //return true;

            for(int i = 0; i < astr.Length; i++)
            {
                for(int j = i+1; j<astr.Length; j++)
                {
                    if(astr[i] == astr[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        // 面试金典1.2 https://leetcode-cn.com/problems/check-permutation-lcci/
        public bool CheckPermutation(string s1, string s2)
        {
            var _s1 = s1.ToList();
            var _s2 = s2.ToList();

            _s1.Sort();
            _s2.Sort();
            return new String(_s1.ToArray()) == new string(_s2.ToArray());
        }

        // 面试金典1.3 https://leetcode-cn.com/problems/string-to-url-lcci/
        public string ReplaceSpaces(string S, int length)
        {
            int index = 0;
            int space_count = 0;
            for(int i = 0; i < length; i++)
            {
                if(S[i] == ' ')
                {
                    space_count++;
                }
            }
            char[] temp = new char[length + space_count*2];
            
            for(int i = 0; i < length; i++)
            {
                if(S[i] == ' ')
                {
                    temp[index++] = '%';
                    temp[index++] = '2';
                    temp[index++] = '0';
                }
                else
                {
                    temp[index++] = S[i];
                }
            }
            return new string(temp);
        }

        // 面试金典1.4 https://leetcode-cn.com/problems/palindrome-permutation-lcci/
        public bool CanPermutePalindrome(string s)
        {
            char[] temp = new char[123];
            foreach(char i in s.ToCharArray())
            {
                temp[i]++;
            }
            int one = 0;
            for(int i = 0; i < 123; i++)
            {
                if (temp[i] == 0 || temp[i] == 2)
                    continue;
                else
                    one++;
            }
            return one <= 1;
        }
    }
}
