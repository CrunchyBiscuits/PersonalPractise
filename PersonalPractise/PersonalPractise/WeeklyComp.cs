using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalPractise
{
    class WeeklyComp
    {
        //public static void Main(String[] args)
        //{

        //}


        // 201 周赛 5483
        public string MakeGood(string s)
        {
            StringBuilder sb = new StringBuilder(s);
            int len = -1;
            while(len != sb.Length)
            {
                len = sb.Length;
                for(int i = 0; i < sb.Length - 1; i++)
                {
                    if(Math.Abs(sb[i] - sb[i+1]) == 'a' - 'A')
                    {
                        sb.Remove(i, 2);
                        break;
                    }
                }
            }
            return sb.ToString();
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
