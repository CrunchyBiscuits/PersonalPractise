using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PersonalPractise
{
    class WeeklyComp
    {
        //public static void Main(String[] args)
        //{
        //    WeeklyComp a = new WeeklyComp();
        //    int[] b = { 2,2};
        //    Console.WriteLine(a.ContainsPattern(b,1,2));
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

        // 203 周赛5495
        public IList<int> MostVisited(int n, int[] rounds)
        {
            IList<int> result = new List<int>();
            int[] temp = new int[n];
            int large = int.MinValue;

            for(int m = 1; m < rounds.Length; m++)
            {
                int start = rounds[m - 1];
                int end = rounds[m];
                if (m == 1)
                {
                    if(end < start)
                    {
                        for (int j = start; j <= n; j++)
                        {
                            temp[j - 1]++;
                            if (temp[j - 1] > large)
                            {
                                large = temp[j - 1];
                            }
                        }
                        for (int j = 1; j <= end; j++)
                        {
                            temp[j - 1]++;
                            if (temp[j - 1] > large)
                            {
                                large = temp[j - 1];
                            }
                        }
                    }
                    else
                    {
                        for (int j = start; j <= end; j++)
                        {
                            temp[j - 1]++;
                            if (temp[j - 1] > large)
                            {
                                large = temp[j - 1];
                            }
                        }
                    }

                }
                else
                {
                    if (end < start)
                    {
                        for (int j = start+1; j <= n; j++)
                        {
                            temp[j - 1]++;
                            if (temp[j - 1] > large)
                            {
                                large = temp[j - 1];
                            }
                        }
                        for (int j = 1; j <= end; j++)
                        {
                            temp[j - 1]++;
                            if (temp[j - 1] > large)
                            {
                                large = temp[j - 1];
                            }
                        }
                    }
                    else
                    {
                        for (int j = start+1; j <= end; j++)
                        {
                            temp[j - 1]++;
                            if (temp[j - 1] > large)
                            {
                                large = temp[j - 1];
                            }
                        }
                    }
                }

            }

            for(int i = 0; i < temp.Length; i++)
            {
                Console.WriteLine(temp[i]);
                if (temp[i] == large)
                {
                    result.Add(i + 1);
                }
            }

            return result;
        }

        // 203 周赛5496
        public int MaxCoins(int[] piles)
        {
            int rounds = piles.Length / 3;
            int total = 0;

            Array.Sort(piles);
            int index = piles.Length-2;
            for (int i = 0;i<rounds;i++)
            {
                total += piles[index];
                index -= 2;
            }

            return total;
        }

        // 203 周赛5497
        public int FindLatestStep(int[] arr, int m)
        {
            int size = int.MinValue;
            StringBuilder wholeString = new StringBuilder();
            StringBuilder testCase = new StringBuilder();
            for(int i = 0; i < m; i++)
            {
                testCase.Append("1");
            }

            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i]>size)
                {
                    size = arr[i];
                }
            }

            for (int i = 0; i < size; i++)
            {
                wholeString.Append("0");
            }

            int ans = -1;
            string temp = wholeString.ToString();
            string request = testCase.ToString();

            for (int i = 0; i < size; i++)
            {
                int index = arr[i]-1;
                char[] chars = temp.ToCharArray();
                chars[index] = '1';
                temp = new string(chars);
                string[] strs = temp.Split("0");
                for(int j = 0; j < strs.Length; j++)
                {
                    if (strs[j].Equals(request))
                    {
                        ans = i+1;
                    }
                }
               
            }

            return ans;
        }

        // 204 周赛5499
        public bool ContainsPattern(int[] arr, int m, int k)
        {
            if (arr.Length < m * k) return false;
            for(int i = 0; i < (arr.Length-m*k)+1; i++)
            {
                bool find = true;
                for (int j = 0; j < m; j++)
                {
                    int currentIndex = i + j;
                    int current = arr[currentIndex];
                    for (int e = 1; e < k; e++)
                    {
                        if (arr[currentIndex+e*m]!=current)
                        {
                            find = false;
                        }
                    }
                }
                if (find)
                {
                    return true;
                }
            }
            return false ;
        }

        // 205 周赛5500
        //public int GetMaxLen(int[] nums)
        //{

        //}

        // 206 周赛5501
    }
}
