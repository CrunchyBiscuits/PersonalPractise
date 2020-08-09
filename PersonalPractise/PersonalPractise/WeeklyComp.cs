using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalPractise
{
    class WeeklyComp
    {
        public static void Main(String[] args)
        {
            WeeklyComp a = new WeeklyComp();
            Console.WriteLine(a.MakeGood("abBAcC"));
        }


        // 201 周赛 5483
        public string MakeGood(string s)
        {
            if (s.Length < 2 || s.Length > 100) return s;
            string result = s;
            bool flag = true;
            while (flag)
            {
                result = cal(result);
                flag = CheckFinish(result);
            }

            return result;
        }
        public bool CheckFinish(string s)
        {
            for (int i = 0; i < s.Length - 1 ; i++)
            {
                if (s[i] + 32 == s[i + 1] || s[i] - 32 == s[i + 1])
                {
                    return true;
                }
            }
            return false;
        }

        public string cal(string s) 
        {
            int index = 0;
            string result = "";
            for (int i = 0; i < s.Length - 2; i++)
            {
                if (s[index] + 32 == s[index + 1] || s[index] - 32 == s[index + 1])
                {
                    index += 2;
                }
                else
                {
                    result += s[index];
                    index++;
                }
            }
            return result;
        }

        // 201 周赛 5484
        public char FindKthBit(int n, int k)
        {
            string result = "0";
            for(int i = 1; i <= n; i++)
            {
                if (i == 1) continue;
                else
                {
                    result = result + "1" + reverseString(invertString(result));
                }
            }
            return result[k];
        }

        public string reverseString(string s)
        {
            char[] temp = s.ToCharArray();
            Array.Reverse(temp);

            return new string(temp);
        }

        public string invertString(string s)
        {
            char[] temp = s.ToCharArray();
            for(int i = 0; i < s.Length; i++)
            {
                if (temp[i] == '0') temp[i] = '1';
                else if (temp[i] == '1') temp[i] = '0';
            }

            return new string(temp);
        }

        // 201 周赛 5471
        //public int MaxNonOverlapping(int[] nums, int target)
        //{

        //}
    }
}
