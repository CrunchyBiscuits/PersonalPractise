using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;

namespace PersonalPractise
{
    class MediumProblems
    {
        // 16.01
        public int[] SwapNumbers(int[] numbers)
        {
            numbers[0] = numbers[0] ^ numbers[1];
            numbers[1] = numbers[0] ^ numbers[1];
            numbers[0] = numbers[0] ^ numbers[1];
            return numbers;
        }

        // 16.02
        public class WordsFrequency
        {
            Dictionary<string, int> freqs;
            public WordsFrequency(string[] book)
            {
                freqs = new Dictionary<string, int>();
                foreach (string item in book)
                {
                    if (!freqs.ContainsKey(item))
                    {
                        freqs.Add(item, 1);
                    }
                    else
                    {
                        freqs[item] += 1;
                    }
                }
            }

            public int Get(string word)
            {
                if (freqs.ContainsKey(word))
                {
                    return freqs[word];
                }
                return 0;
            }
        }

        // 16.03
        public double[] Intersection(int[] start1, int[] end1, int[] start2, int[] end2)
        {
            // 列出所有的点，方便记忆和计算
            int x1 = start1[0];
            int y1 = start1[1];
            int x2 = end1[0];
            int y2 = end1[1];
            int x3 = start2[0];
            int y3 = start2[1];
            int x4 = end2[0];
            int y4 = end2[1];

            // 存答案
            List<double> ans = new List<double>();

            // 使用参数方程判断是否平行
            if ((y4 - y3) * (x2 - x1) == (y2 - y1) * (x4 - x3))
            {
                // 如果平行，那么只需要判断（x3,y3）是否在（x1,y1）~（x2,y2）的直线上
                // 代入参数方程
                // 即将（x3,y3）代入直线（x1,y1）~（x2,y2）的参数方程成立
                // x3 = x1 + t(x2-x1)
                // y3 = y1 + t(y2-y1)
                // 解参数方程t，得到 t = (x3-x1)/(x2-x1) = (y3-y1)/(y2-y1)
                if ((x3 - x1) * (y2 - y1) == (y3 - y1) * (x2 - x1))
                {
                    // 如果共线只需要判断4个端点是否在另一条线段里边儿，再找出最优解

                    // 判断（x3,y3）
                    if (inside(x1, y1, x2, y2, x3, y3))
                    {
                        update(ans, x3, y3);
                    }

                    // 判断（x4,y4）
                    if (inside(x1, y1, x2, y2, x4, y4))
                    {
                        update(ans, x4, y4);
                    }

                    // 判断（x2,y2）
                    if (inside(x3, y3, x4, y4, x2, y2))
                    {
                        update(ans, x2, y2);
                    }

                    // 判断（x1,y1）
                    if (inside(x3, y3, x4, y4, x1, y1))
                    {
                        update(ans, x1, y1);
                    }
                }
            }
            else
            {
                // 如果不平行，则肯定有唯一交点，判断交点是否在两条线段上即可
                // 两直线的参数方程分别是
                // x = x1 + t1(x2-x1)
                // y = y1 + t1(y2-y1)
                // 
                // x = x3 + t2(x4-x3)
                // y = y3 + t2(y4-y3)

                double t1 = (double)((x3 - x1) * (y4 - y3) + (y1 - y3) * (x4 - x3)) / ((x2 - x1) * (y4 - y3) - (y2 - y1) * (x4 - x3));
                double t2 = (double)((x1 - x3) * (y2 - y1) + (y3 - y1) * (x2 - x1)) / ((x4 - x3) * (y2 - y1) - (y4 - y3) * (x2 - x1));

                // 判断 t1,t2 是否在 [0,1] 之间
                if (t1 >= 0.0 && t1 <= 1.0 && t2 >= 0.0 && t2 <= 1.0)
                {
                    ans.Add(x1 + t1 * (x2 - x1));
                    ans.Add(y1 + t1 * (y2 - y1));
                }

            }

            return ans.ToArray();
        }

        public void update(List<double> ans, double xk, double yk)
        {
            // 根据题目要求更新答案，找到最小的x值
            // 如果x值相等，取最小的y值
            if (ans.Count == 0)
            {
                ans.Add(xk);
                ans.Add(yk);
            }
            else if (xk < ans[0] || (xk == ans[0] && yk < ans[1]))
            {
                ans[0] = xk;
                ans[1] = yk;
            }
        }

        // 判断（xk,yk）是否在线段（x1,y1）~（x2,y2）上
        // 判断前提是（xk,yk）一定在直线（x1,y1）~（x2,y2）上
        public bool inside(int x1, int y1, int x2, int y2, int xk, int yk)
        {
            return (x1 == x2 || (Math.Min(x1, x2) <= xk && xk <= Math.Max(x1, x2))) && (y1 == y2 || (Math.Min(y1, y2) <= yk && yk <= Math.Max(y1, y2)));
        }

        // 16.04
        public string Tictactoe(string[] board)
        {
            if (board.Length == 1)
            {
                return board[0];
            }

            bool isFull = true;
            int size = board.Length;

            // 检查行
            for (int i = 0; i < size; i++)
            {
                char first = board[i][0];
                if (first == ' ')
                {
                    isFull = false;
                    continue;
                }
                for (int j = 1; j < size; j++)
                {
                    if (board[i][j] != first)
                    {
                        break;
                    }
                    else if (j == size - 1)
                    {
                        return first.ToString();
                    }
                }
            }

            // 检查列
            for (int i = 0; i < size; i++)
            {
                char first = board[0][i];
                if (first == ' ')
                {
                    isFull = false;
                    continue;
                }
                for (int j = 1; j < size; j++)
                {
                    if (board[j][i] != first)
                    {
                        break;
                    }
                    else if (j == size - 1)
                    {
                        return first.ToString();
                    }
                }
            }

            // 检查对角线
            char dia = board[0][0];
            if (dia == ' ')
            {
                isFull = false;
            }
            else
            {
                for (int i = 1; i < size; i++)
                {
                    if (board[i][i] != dia)
                    {
                        break;
                    }
                    else if (i == size - 1)
                    {
                        return dia.ToString();
                    }
                }
            }


            dia = board[0][size - 1];
            if (dia == ' ')
            {
                isFull = false;
            }
            else
            {
                for (int i = 1; i < size; i++)
                {
                    if (board[i][size - i - 1] != dia)
                    {
                        break;
                    }
                    else if (i == size - 1)
                    {
                        return dia.ToString();
                    }
                }
            }


            if (isFull)
            {
                return "Draw";
            }
            else
            {
                return "Pending";
            }
        }

        // 16.05
        public int TrailingZeroes(int n)
        {
            int count = 0;
            while (n > 0)
            {
                count += n / 5;
                n /= 5;
            }
            return count;
        }

        // 16.06
        public int SmallestDifference(int[] a, int[] b)
        {
            if (a == null || b == null || a.Length < 1 || b.Length < 1)
            {
                return -1;
            }

            long ans = Int32.MaxValue;
            Array.Sort(a);
            Array.Sort(b);

            int indexA = 0, indexB = 0;

            while (indexA < a.Length && indexB < b.Length)
            {
                ans = Math.Min(ans, Math.Abs((long)a[indexA] - (long)b[indexB]));
                if (ans == 0) return 0;
                if (a[indexA] < b[indexB])
                {
                    indexA++;
                }
                else
                {
                    indexB++;
                }
            }

            return (int)ans;
        }

        // 16.07
        public int Maximum(int a, int b)
        {
            long minus = (long)a - (long)b;
            int ans = (int)(minus >> 63) + 1;
            int[] pool = { a, b };
            return pool[ans];
        }

        // 16.08
        public string NumberToWords(int num)
        {

        }

        // 16.09
        public class Operations
        {

            public Operations()
            {

            }

            public int Minus(int a, int b)
            {
                return a + negate(b);
            }

            public int Multiply(int a, int b)
            {
                if (a == 0 || b == 0)
                {
                    return 0;
                }

                int aSign = a < 0 ? -1 : 1;
                int bSign = b < 0 ? -1 : 1;
                bool needNeg = aSign == bSign;

                a = Math.Abs(a);
                b = Math.Abs(b);
                int ans = 0;
                for (int i = 0; i < b; i++)
                {
                    ans += a;
                }

                if (needNeg)
                {
                    return negate(ans);
                }
                else
                {
                    return ans;
                }
            }

            public int Divide(int a, int b)
            {
                if (b == 0)
                {
                    throw new DivideByZeroException();
                }

                int aSign = a < 0 ? -1 : 1;
                int bSign = b < 0 ? -1 : 1;
                bool needNeg = aSign == bSign;


                int abs_a = Math.Abs(a);
                int abs_b = Math.Abs(b);

                int product = 0;
                int ans = 0;

                while (product + abs_b <= abs_a)
                {
                    product += abs_b;
                    ans++;
                }

                if (needNeg)
                {
                    return negate(ans);
                }
                else
                {
                    return ans;
                }
            }

            public int negate(int a)
            {
                int neg = 0;
                int negSign = a < 0 ? 1 : -1;
                int delta = negSign;
                while (a != 0)
                {
                    bool diff = (a + delta > 0) != (a > 0);
                    if (a + delta != 0 && diff)
                    {
                        delta = negSign;
                    }
                    neg += delta;
                    a += delta;
                    delta += delta;
                }

                return neg;
            }
        }

        // 16.10
        public int MaxAliveYear(int[] birth, int[] death)
        {
            int[] alive = new int[101];
            for (int i = 0; i < birth.Length; i++)
            {
                for (int j = birth[i]; j <= death[i]; j++)
                {
                    alive[j - 1900]++;
                }
            }

            return Array.IndexOf(alive, alive.Max()) + 1900;

        }

        // 16.11
        public int[] DivingBoard(int shorter, int longer, int k)
        {
            if (k == 0)
            {
                return new int[] { };
            }
            else if (shorter == longer)
            {
                return new int[] { shorter * k };
            }
            int[] lengths = new int[k + 1];
            for (int i = 0; i < lengths.Length; i++)
            {
                lengths[i] = shorter * (k - i) + longer * i;
            }
            return lengths;
        }

        // 16.13
        public double[] CutSquares(int[] square1, int[] square2)
        {
            // 两个正方形的中心
            double centerX1 = square1[0] + square1[2] / 2.0;
            double centerY1 = square1[1] + square1[2] / 2.0;
            double centerX2 = square2[0] + square2[2] / 2.0;
            double centerY2 = square2[1] + square2[2] / 2.0;


            // 特殊情况，x相同，平行于Y轴，斜率无穷大
            if (centerX1 == centerX2)
            {
                // 两个正方形左下坐标决定了最底端的y值，因为x已经确定
                double y1 = Math.Min(square1[1], square2[1]);
                // 顶端根据左下角坐标和边长计算得出
                double y2 = Math.Max(square1[1] + square1[2], square2[1] + square2[2]);
                return new double[] { centerX1, y1, centerX1, y2 };
            }

            // 直线斜率和在y轴截距
            double k = (centerY2 - centerY1) / (centerX2 - centerX1);
            double b = centerY1 - k * centerX1;

            // 交点坐标
            double p1X, p1Y, p2X, p2Y;

            // 必定经过中心点，所以不存在直线经过相邻直角边的情况
            // 超过45°就是上下两条边
            // 小于就是左右
            if (Math.Abs(k) < 1)
            {
                p1X = Math.Min(square1[0], square2[0]);
                p1Y = k * p1X + b;
                p2X = Math.Max(square1[0] + square1[2], square2[0] + square2[2]);
                p2Y = k * p2X + b;
            }
            else
            {
                p1Y = Math.Min(square1[1], square2[1]);
                p1X = (p1Y - b) / k;
                p2Y = Math.Max(square1[1] + square1[2], square2[1] + square2[2]);
                p2X = (p2Y - b) / k;

                if (p1X > p2X)
                {
                    double temp = p1X;
                    p1X = p2X;
                    p2X = temp;
                    temp = p1Y;
                    p1Y = p2Y;
                    p2Y = temp;
                }

            }

            return new double[] { p1X, p1Y, p2X, p2Y };

        }

        // 16.15
        public int[] MasterMind(string solution, string guess)
        {
            int[] ans = new int[2];
            Dictionary<char, int> sMap = new Dictionary<char, int>();
            sMap.Add('R', 0);
            sMap.Add('G', 0);
            sMap.Add('Y', 0);
            sMap.Add('B', 0);
            Dictionary<char, int> gMap = new Dictionary<char, int>();
            gMap.Add('R', 0);
            gMap.Add('G', 0);
            gMap.Add('Y', 0);
            gMap.Add('B', 0);
            for (int i = 0; i < solution.Length; i++)
            {
                if (solution[i] == guess[i])
                {
                    ans[0]++;
                }
                sMap[solution[i]]++;
                gMap[guess[i]]++;
            }

            ans[1] = Math.Min(sMap['R'], gMap['R']) + Math.Min(sMap['G'], gMap['G']) + Math.Min(sMap['Y'], gMap['Y']) + Math.Min(sMap['B'], gMap['B']);

            ans[1] = ans[1] - ans[0];

            return ans;
        }

        // 16.16
        public int[] SubSort(int[] array)
        {
            if (array.Length == 0 || array == null)
            {
                return new int[] { -1, -1 };
            }
            // 根据题意初始化
            int left = -1;
            int right = -1;

            int maxNum = int.MinValue;
            int minNum = int.MaxValue;
            int len = array.Length;

            for (int i = 0; i < len; i++)
            {
                if (array[i] < maxNum)
                {
                    right = i;
                }
                else
                {
                    maxNum = Math.Max(maxNum, array[i]);
                }

                if (array[len - i - 1] > minNum)
                {
                    left = len - i - 1;
                }
                else
                {
                    minNum = Math.Min(minNum, array[len - i - 1]);
                }
            }

            return new int[] { left, right };
        }

        // 16.17
        public int MaxSubArray(int[] nums)
        {
            int maxSum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] >= 0)
                {
                    nums[i] += nums[i - 1];
                }
                if (nums[i] > maxSum)
                {
                    maxSum = nums[i];
                }
            }
            return maxSum;
        }

        // 16.25
        public class LRUCache
        {

            private int capacity;
            private LinkedList<int> lruTrack;
            private Dictionary<int, int> cache;
            public LRUCache(int capacity)
            {
                this.capacity = capacity;
                lruTrack = new LinkedList<int>();
                this.cache = new Dictionary<int, int>();
            }

            public int Get(int key)
            {
                if (cache.ContainsKey(key))
                {
                    lruTrack.Remove(key);
                    lruTrack.AddLast(key);
                    return cache[key];
                }
                return -1;
            }

            public void Put(int key, int value)
            {
                if (cache.ContainsKey(key))
                {
                    lruTrack.Remove(key);
                    lruTrack.AddLast(key);
                    cache[key] = value;
                    return;
                }
                if (cache.Count == capacity)
                {
                    int removeVal = lruTrack.First.Value;
                    lruTrack.RemoveFirst();
                    cache.Remove(removeVal);
                }
                cache.Add(key, value);
                lruTrack.AddLast(key);
            }
        }
    }
}
