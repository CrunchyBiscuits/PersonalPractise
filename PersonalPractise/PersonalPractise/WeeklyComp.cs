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

        // 202 周赛5185
        public bool ThreeConsecutiveOdds(int[] arr)
        {
            if (arr.Length < 1 || arr.Length > 1000) return false;
            for(int i = 0; i < arr.Length - 2; i++)
            {
                if (arr[i] % 2 != 0 && arr[i + 1] % 2 != 0 && arr[i + 2] % 2 != 0)
                {
                    return true;
                }
            }
            return false;
        }

        // 202 周赛5488
        public int MinOperations(int n)
        {
            if (n < 1) return -1;
            int ans = 0;
            if (n % 2 == 0)
            {
                int last = 2 * (n - 1) + 1;
                int mid = 2 * (n / 2) + 1;
                int avg = mid - 1; 
                for(int i = last; i >= mid;i = i - 2)
                {
                    ans += i - avg;
                }
            }
            else
            {
                int last = 2 * (n - 1) + 1;
                int avg = 2 * (n / 2) + 1;
                for (int i = last; i >= avg; i = i - 2)
                {
                    ans += i - avg;
                }
            }
            return ans;
        }

        // 202 周赛5489
        public int MaxDistance(int[] position, int m)
        {
            if (m > position.Length || m<2) return -1;
            bool[] positionCheck = { false };
            int ans1 = 0, ans2 = 0;
            int small = int.MaxValue, smallIndex = 0;
            int large = int.MinValue, largeIndex = 0;
            m -= 2;
            for(int i = 0; i < position.Length; i++)
            {
                if (position[i] < small)
                {
                    small = position[i];
                    smallIndex = i;
                }
                if(position[i] > large)
                {
                    large = position[i];
                    largeIndex = i;
                }
            }

            ans1 = large - small;
            positionCheck[smallIndex] = true;
            positionCheck[largeIndex] = true;
            while (m > 0)
            {

            }

            return Math.Max(ans1, ans2);
        }
    }
}
