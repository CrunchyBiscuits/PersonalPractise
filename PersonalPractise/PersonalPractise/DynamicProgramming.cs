using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO.Pipes;
using System.Linq;
using System.Text;

namespace PersonalPractise
{
    class DynamicProgramming
    {
        // 面试金典 8.1
        public int WaysToStep(int n)
        {
            if (n <= 2) return n;
            int[] dp = new int[n];
            dp[0] = 1;
            dp[1] = 2;
            dp[2] = 4;
            for (int i = 3; i < n; i++)
            {
                dp[i] = (dp[i - 1] + (dp[i - 2] + dp[i - 3]) % 1000000007) % 1000000007;
            }
            return dp[n - 1];
        }

        // 面试金典 8.2
        public IList<IList<int>> PathWithObstacles(int[][] obstacleGrid)
        {
            if (obstacleGrid == null || obstacleGrid.Length == 0 || obstacleGrid[0][0] == 1) return null;
            int hidth = obstacleGrid.Length;
            int width = obstacleGrid[0].Length;

            IList<IList<int>> paths = new List<IList<int>>();
            HashSet<IList<int>> visited = new HashSet<IList<int>>();

            if (findPath(obstacleGrid, hidth - 1, width - 1, paths, visited))
            {
                return paths;
            }

            return paths;
        }

        public bool findPath(int[][] obs, int row, int col, IList<IList<int>> paths, HashSet<IList<int>> visited)
        {
            if (row < 0 || col < 0 || obs[row][col] == 1)
            {
                return false;
            }

            int[] node = new int[2];
            node[0] = row;
            node[1] = col;

            if (visited.Contains(node))
            {
                return false;
            }

            if ((row == 0 && col == 0) || findPath(obs, row - 1, col, paths, visited) || findPath(obs, row, col - 1, paths, visited))
            {
                paths.Add(node);
                return true;
            }

            visited.Add(node);
            return false;
        }

        //面试金典 8.3
        public int FindMagicIndex(int[] nums)
        {
            int minVal = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i < minVal && i == nums[i])
                {
                    minVal = i;
                    break;
                }
            }
            if (minVal == int.MaxValue)
                return -1;
            return minVal;
        }

        // 面试金典 8.4
        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            ans.Add(new List<int>());
            for (int i = 0; i < nums.Length; i++)
            {
                IList<IList<int>> tempstore = new List<IList<int>>();
                foreach (List<int> item in ans)
                {
                    List<int> newVal = new List<int>();
                    foreach (int val in item)
                    {
                        newVal.Add(val);
                    }
                    newVal.Add(nums[i]);
                    tempstore.Add(newVal);
                }
                foreach (List<int> item in tempstore)
                {
                    ans.Add(item);
                }
            }

            return ans;
        }

        // 面试金典 8.5
        public int Multiply(int A, int B)
        {
            int temp = A;
            for (int i = 1; i < B; i++)
            {
                A += temp;
            }
            return A;
        }

        // 面试金典 8.6
        public void Hanota(IList<int> A, IList<int> B, IList<int> C)
        {
            move(A.Count, A, B, C);
        }

        public void move(int num, IList<int> A, IList<int> B, IList<int> C)
        {
            if (num == 1)
            {
                C.Add(A[A.Count - 1]);
                A.Remove(A[A.Count - 1]);
                return;
            }
            else
            {
                move(num - 1, A, C, B);
                move(1, A, B, C);
                move(num - 1, B, A, C);
            }
        }

        // 面试金典 8.7
        public string[] Permutation(string S)
        {
            if (S.Length <= 0)
            {
                return new string[] { S };
            }

            IList<IList<string>> ans = new List<IList<string>>();
            List<string> temp = new List<string>();
            temp.Add(S[0].ToString());
            ans.Add(temp);

            for (int i = 1; i < S.Length; i++)
            {
                temp = new List<string>();
                for (int j = 0; j <= i; j++)
                {
                    foreach (string str in ans[i - 1])
                    {
                        temp.Add(str.Insert(j, S[i].ToString()));
                    }
                }
                ans.Add(temp);
            }
            return ans[ans.Count - 1].ToArray();
        }

        // 面试金典 8.8
        public string[] PermutationNoRepeat(string S)
        {
            if (S.Length <= 0)
            {
                return new string[] { S };
            }

            IList<HashSet<string>> ans = new List<HashSet<string>>();
            HashSet<string> temp = new HashSet<string>();
            temp.Add(S[0].ToString());
            ans.Add(temp);

            for (int i = 1; i < S.Length; i++)
            {
                temp = new HashSet<string>();
                for (int j = 0; j <= i; j++)
                {
                    foreach (string str in ans[i - 1])
                    {
                        temp.Add(str.Insert(j, S[i].ToString()));
                    }
                }
                ans.Add(temp);
            }
            return ans[ans.Count - 1].ToArray();
        }

        // 面试金典 8.9
        public IList<string> GenerateParenthesis(int n)
        {
            IList<string> ans = new List<string>();
            char[] str = new char[n * 2];
            InsertParen(ans, n, n, str, 0);
            return ans;
        }

        public void InsertParen(IList<string> ans, int left, int right, char[] parenStr, int index)
        {
            if (left < 0 || left > right)
            {
                return;
            }

            if (left == 0 && right == 0)
            {
                ans.Add(new string(parenStr));
            }
            else
            {
                parenStr[index] = '(';
                InsertParen(ans, left - 1, right, parenStr, index + 1);

                parenStr[index] = ')';
                InsertParen(ans, left, right - 1, parenStr, index + 1);
            }
        }

        // 面试金典 8.10
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            int oldColor = image[sr][sc];
            bool[,] visited = new bool[image.Length,image[0].Length];
            changeColor(image, sr, sc, newColor, oldColor, visited);
            return image;
        }

        public void changeColor(int[][] image, int r, int c, int newColor, int oldColor, bool[,] visited)
        {
            if (r < 0 || r >= image.Length||c<0||c>=image[0].Length)
            {
                return;
            }
            if (!visited[r,c])
            {
                visited[r, c] = true;
                if (image[r][c] == oldColor)
                {
                    image[r][c] = newColor;
                    changeColor(image, r, c, newColor, oldColor, visited);
                    changeColor(image, r - 1, c, newColor, oldColor, visited);
                    changeColor(image, r, c - 1, newColor, oldColor, visited);
                    changeColor(image, r + 1, c, newColor, oldColor, visited);
                    changeColor(image, r, c + 1, newColor, oldColor, visited);
                }
            }
        }

        // 面试金典 8.11
        public int WaysToChange(int n)
        {
            int[] coins = { 25, 10, 5, 1 };
            int mod = 1000000007;

            int[] dp = new int[n + 1];
            dp[0] = 1;
            for (int i = 0; i < coins.Length; i++)
            {
                int coin = coins[i];
                for (int j = coin; j <= n; j++)
                {
                    dp[j] = (dp[j] + dp[j - coin]) % mod;
                }
            }
            return dp[n];
        }

        //// 面试金典 8.12
        //public IList<IList<string>> SolveNQueens(int n)
        //{

        //}

        //// 面试金典 8.13
        //public int PileBox(int[][] box)
        //{

        //}
    }
}
