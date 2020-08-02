using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalPractise
{
     public class TreeNode
    {
     public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
    }
    class Daily
    {
        //public static void Main(string[] args)
        //{

        //}

        //NUM392 https://leetcode-cn.com/problems/is-subsequence/
        public bool IsSubsequence(string s, string t)
        {
            var sLength = s.Length;
            if (sLength < 1)
                return true;
            var count = 0;
            char[] sC = s.ToCharArray();
            foreach(char tC in t.ToCharArray())
            {
                if (count == sLength)
                    return true;
                if(tC == sC[count])
                {
                    count++;
                }
            }


            return count==sLength;
        }

        //NUM104 https://leetcode-cn.com/problems/maximum-depth-of-binary-tree/
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            var leftVal = 1 + MaxDepth(root.left);
            var rigthVal = 1 + MaxDepth(root.right);
            return leftVal>rigthVal?leftVal:rigthVal;
        }

        //NUM343 https://leetcode-cn.com/problems/integer-break/
        public int IntegerBreak(int n)
        {
            int[] allN = new int[n + 1];
            allN[0] = allN[1] = 0;
            for(int i = 2; i <= n; i++)
            {
                for(int j = 1; j < i; j++)
                {
                    allN[i] = Math.Max(allN[i], Math.Max(j * (i - j), j * allN[i - j]));
                }
                
            }

            return allN[n];
        }
    }
}
