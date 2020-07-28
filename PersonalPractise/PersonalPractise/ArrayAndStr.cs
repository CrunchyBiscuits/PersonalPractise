using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        // 面试金典1.5 https://leetcode-cn.com/problems/one-away-lcci/
        public static bool OneEditAway(string first, string second)
        {
            if (first.Length == second.Length)
            {
                var diffCount = 0;
                for (int i = 0; i < first.Length; i++)
                {
                    if (first[i] != second[i])
                        diffCount++;
                    if (diffCount > 1)
                        return false;
                }
            }else if (Math.Abs(first.Length - second.Length) > 1)
                return false;
            else
            {
                int index1 = 0;
                int index2 = 0;
                int count = 0;
                while(index1<first.Length && index2 < second.Length)
                {
                    Console.WriteLine(first[index1] +"," + second[index2]);
                    if (first[index1] != second[index2])
                    {
                        if (first.Length > second.Length)
                            index1++;
                        else
                            index2++;
                        count++;
                    }
                    else
                    {
                        index1++;
                        index2++;
                    }
                    if (count > 1)
                        return false;
                }
            }

            return true;
        }

        // 面试金典1.6 https://leetcode-cn.com/problems/compress-string-lcci/
        public string CompressString(string S)
        {
            if (S.Length == 0)
                return "";
            StringBuilder sbuilder = new StringBuilder();
            int count = 1, index = 0;

            while (index < S.Length)
            {
                if(index == S.Length - 1)
                {
                    sbuilder.Append(S[index]);
                    sbuilder.Append(count);
                    count = 1;
                }
                else if(S[index] == S[index + 1])
                {
                    count++;
                }
                else
                {
                    sbuilder.Append(S[index]);
                    sbuilder.Append(count);
                    count = 1;
                }
                index++;
            }



            string answer = sbuilder.ToString();

            return S.Length > answer.Length ? answer : S;
        }

        // 面试金典1.7 https://leetcode-cn.com/problems/rotate-matrix-lcci/
        public void Rotate(int[][] matrix)
        {
            for(int i = 0; i < matrix[0].Length-1; i++)
            {
                int x = 0, y = i;
                int newX = matrix[i].Length-1-y, newY = x;

                int temp = matrix[x][y];
                matrix[x][y] = matrix[newX][newY];

                x = newX;
                y = newY;

                newX = matrix[i].Length - 1 - y;
                newY = x;
                matrix[x][y] = matrix[newX][newY];

                x = newX;
                y = newY;

                newX = matrix[i].Length - 1 - y;
                newY = x;
                matrix[x][y] = matrix[newX][newY];

                matrix[newX][newY] = temp;
            }
        }

        // 面试金典1.8

        // 面试金典1.9
    }
}
