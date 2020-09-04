using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalPractise
{
    class SortAndFind
    {
        // 面试金典 10.01
        public void Merge(int[] A, int m, int[] B, int n)
        {
            for (int j = 0; j < B.Length; j++)
            {
                for (int i = A.Length - 1; i >=0 ; i--)
                {
                    if (B[j]<=A[i])
                    {
                        for (int k = A.Length - 1; k >= i; k--)
                        {
                            A[k] = A[k - 1];
                        }
                        A[i] = B[j];
                        break;
                    }
                }
            }
        }
    }

}
