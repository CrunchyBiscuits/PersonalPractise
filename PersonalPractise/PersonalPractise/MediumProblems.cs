using System;
using System.Collections.Generic;
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
            if ((y4-y3)*(x2-x1)==(y2-y1)*(x4-x3))
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
                    if (inside(x1,y1,x2,y2,x3,y3))
                    {
                        update(ans,x3,y3);
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
                if (t1>=0.0&&t1<=1.0&&t2>=0.0&&t2<=1.0)
                {
                    ans.Add(x1 + t1*(x2 - x1));
                    ans.Add(y1 + t1*(y2 - y1));
                }

            }

            return ans.ToArray();
        }

        public void update(List<double> ans, double xk, double yk)
        {
            // 根据题目要求更新答案，找到最小的x值
            // 如果x值相等，取最小的y值
            if (ans.Count==0)
            {
                ans.Add(xk);
                ans.Add(yk);
            }
            else if (xk<ans[0]||(xk==ans[0]&&yk<ans[1]))
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
    }
}
