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
    }
}
