using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PersonalPractise
{
    class BasicDivideAndConquer
    {
        // 162 寻找峰值 二分法查找峰值
        public int FindPeakElement(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
            {
                return 0;
            }

            int l = 0;
            int r = nums.Length - 1;
            while (l < r)
            {
                int mid = (l + r) / 2;
                if (nums[mid] > nums[mid + 1])
                {
                    r = mid;
                }
                else
                {
                    l = mid + 1;
                }
            }

            return l;
        }

        // 1292 元素和小于等于阈值的正方形的最大边长 切割法求
        // sum[x][y] = sum[x][y-1] + sum[y-1][x] - sum[x-1][y-1] + mat[x][y] --- 二维数组任意矩形和的优化思路
        public bool existSquare(int[][] mat, int[,] area, int side, int threshold)
        {
            int m = mat.Length, n = mat[0].Length;
            for (int i = side; i < m+1; i++)
            {
                for (int j = side; j < n+1; j++)
                {
                    if (area[i,j]-area[i-side,j]-area[i,j-side]+area[i-side,j-side]<=threshold)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public int MaxSideLength(int[][] mat, int threshold)
        {
            int m = mat.Length;
            int n = mat[0].Length;

            int[,] area = new int[m + 1, n + 1];
            for (int i = 1; i < m + 1; i++)
            {
                for (int j = 1; j < n + 1; j++)
                {
                    area[i, j] = mat[i-1][j-1] + area[i - 1, j] + area[i, j - 1] - area[i - 1, j - 1]; 
                }
            }

            int low = 1, high = Math.Min(m,n);
            int result = 0;
            while (low<=high)
            {
                int mid = (low + high) / 2;
                if (existSquare(mat,area,mid,threshold))
                {
                    result = mid;
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return result;
        }

        // 1235 规划兼职工作

        // 240 搜索二维矩阵2
        public bool SearchMatrix(int[,] matrix, int target)
        {
            int row = matrix.GetLength(0) - 1;
            int col = 0;

            while (row>=0&&col<matrix.GetLength(1))
            {
                if (matrix[row, col] > target)
                {
                    row--;
                }
                else if (matrix[row, col]<target)
                {
                    col++;
                }
                else
                {
                    return true;
                }
            }


            return false;
        }

    }
}
