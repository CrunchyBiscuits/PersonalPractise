using System;
using System.Collections.Generic;

namespace PersonalPractise
{
    class IsUniqueStr
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
    }
}
