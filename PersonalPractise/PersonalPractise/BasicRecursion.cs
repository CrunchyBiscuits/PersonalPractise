using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace PersonalPractise
{
    class BasicRecursion
    {
        // 894 所有可能的满二叉树 递归
        public IList<TreeNode> AllPossibleFBT(int N)
        {
            IList<TreeNode> result = new List<TreeNode>();
            if (N % 2 == 0)
            {
                return result;
            }

            if (N == 1)
            {
                TreeNode node = new TreeNode(0);
                result.Add(node);
                return result;
            }

            // 去掉root
            N -= 1;

            for (int i = 1; i < N; i+=2)
            {
                IList<TreeNode> left = AllPossibleFBT(i);
                IList<TreeNode> right = AllPossibleFBT(N - i);

                foreach (TreeNode lnode in left)
                {
                    foreach (TreeNode rnode in right)
                    {
                        TreeNode root = new TreeNode(0);
                        root.left = lnode;
                        root.right = rnode;
                        result.Add(root);
                    }
                }
            }

            return result;
        }

        // 140 单词拆分2 递归+记忆化搜索
        // 记忆化搜索，在计算过程中的中间结果都保存到一个数据结构中
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            return WordBreakHelper(s, wordDict, new Dictionary<string, List<string>>());
        }

        // 通过字典来存储已经计算过的结果
        public IList<string> WordBreakHelper(string s, IList<string> wordDict, Dictionary<string, List<string>> preResult)
        {
            // 首先判断有没有判断过，如果有直接返回结果
            if (preResult.ContainsKey(s))
            {
                return preResult[s];
            }

            // 存储当前单词的答案
            List<string> result = new List<string>();

            // 如果判断字符串为空，那么直接返回
            if (s.Length==0)
            {
                result.Add("");
                return result;
            }

            // 依次遍历所给字典中的单词，如果当前字符串有这个单词起头的
            foreach (string word in wordDict)
            {
                if (s.StartsWith(word))
                {
                    // 递归遍历子字符串
                    IList<string> subResult = WordBreakHelper(s.Substring(word.Length), wordDict, preResult);
                    // 挨个添加从子字符串出现的结果
                    foreach (string item in subResult)
                    {
                        result.Add(word + (item.Length==0?"": " ") + item);
                    }
                }
            }

            // 将遍历好的结果添加到preResult中，以方便其他遍历使用
            preResult.Add(s, result);
            return result;
        }

        // 687 最长同值路径
        // 递推三要素
        // 递推方程
        // 基础值
        // 每次function call记录

        public int ans=0;
        public int LongestUnivaluePath(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            helper(root);
            return this.ans;
        }

        public int helper(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            // 获得左右递归的结果
            int l = helper(root.left);
            int r = helper(root.right);

            int pl = 0, pr = 0;
            // 如果和当前节点相同那么加1，更新最大值
            if (root.left != null && root.val == root.left.val) pl = l + 1;
            if (root.right != null && root.val == root.right.val) pr = r + 1;
            this.ans = Math.Max(this.ans, pl + pr);

            // 如果不同那么直接返回
            return Math.Max(pl, pr);
        }

        // 783 二叉搜索树节点最小距离, 中序遍历，记录前一个值找最小差值
        public int minAns = int.MaxValue;
        public object prev;
        public int MinDiffInBST(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            prev = int.MinValue;
            prev = null;
            MinDiffInBSTHelper(root);
            return minAns;
        }

        public void MinDiffInBSTHelper(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            MinDiffInBSTHelper(root.left);
            if (prev!=null)
            {
                minAns = Math.Min(minAns, root.val - (int)prev);
            }
            prev = root.val;
            MinDiffInBSTHelper(root.right);
        }

        // 1137 第N个泰波那契数
        // 中间值保存
        // dp数组保存
        public int Tribonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1 || n == 2)
            {
                return 1;
            }
            int[] dp = new int[n+1];
            dp[0] = 0;
            dp[1] = dp[2] = 1;

            for (int i = 3; i < n+1; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2] + dp[i - 3];
            }

            return dp[n];
        }
    }
}
