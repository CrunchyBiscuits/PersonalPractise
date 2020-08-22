using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PersonalPractise
{
    class TreeAndGraph
    {

        // 面试金典 4.1 https://leetcode-cn.com/problems/route-between-nodes-lcci/
        public bool FindWhetherExistsPath(int n, int[][] graph, int start, int target)
        {
            HashSet<int> visited = new HashSet<int>();
            Queue<int> frontier = new Queue<int>();
            frontier.Enqueue(start);

            Dictionary<int, HashSet<int>> paths = new Dictionary<int, HashSet<int>>();
            foreach (int[] s in graph)
            {
                if (!paths.ContainsKey(s[0]))
                {
                    paths.Add(s[0], new HashSet<int>());
                }
                paths[s[0]].Add(s[1]);
            }


            bool answer = false;
            while (frontier.Count > 0)
            {
                int s = frontier.Dequeue();
                if (visited.Contains(s))
                {
                    continue;
                }
                if (s == target)
                {
                    answer = true;
                    break;
                }
                else
                {
                    visited.Add(s);
                    if (paths.ContainsKey(s))
                    {
                        foreach (int end in paths[s])
                        {
                            frontier.Enqueue(end);
                        }
                    }
                }

            }

            return answer;
        }

        // 面试金典 4.2 https://leetcode-cn.com/problems/minimum-height-tree-lcci/
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return helper(nums, 0, nums.Length - 1);
        }

        TreeNode helper(int[] nums, int start, int end)
        {
            if (start > end) return null;

            int mid = (end - start) / 2 + start;
            TreeNode root = new TreeNode(nums[mid]);
            root.left = helper(nums, start, mid - 1);
            root.right = helper(nums, mid + 1, end);
            return root;
        }

        // 面试金典 4.3 https://leetcode-cn.com/problems/list-of-depth-lcci/
        public ListNode[] ListOfDepth(TreeNode tree)
        {
            if (tree == null) return null;
            List<ListNode> listOfLevels = new List<ListNode>();
            int curr = 1;
            int next = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(tree);
            ListNode node = new ListNode(0);
            ListNode find = node;
            while (queue.Count > 0)
            {
                TreeNode temp = queue.Dequeue();
                node.next = new ListNode(temp.val);
                node = node.next;
                curr--;
                if (temp.left != null)
                {
                    queue.Enqueue(temp.left);
                    next++;
                }
                if (temp.right != null)
                {
                    queue.Enqueue(temp.right);
                    next++;
                }
                if(curr == 0)
                {
                    curr = next;
                    next = 0;
                    listOfLevels.Add(find.next);
                    node = new ListNode(0);
                    find = node;
                }
            }


            return listOfLevels.ToArray();
        }

        // 面试金典 4.4 https://leetcode-cn.com/problems/check-balance-lcci/
        public bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;
            int diff = Math.Abs(heightOfTree(root.left) - heightOfTree(root.right));
            if (diff > 1)
                return false;
            else
                return IsBalanced(root.left) && IsBalanced(root.right);
        }

        public int heightOfTree(TreeNode root)
        {
            if (root == null) return 0;
            return Math.Max(1 + heightOfTree(root.left), 1 + heightOfTree(root.right));
        }

        // 面试金典 4.5 https://leetcode-cn.com/problems/legal-binary-search-tree-lcci/
        public bool IsValidBST(TreeNode root)
        {
            List<int> ans = new List<int>();
            AddNodes(root, ans);
            for(int i = 1; i < ans.Count; i++)
            {
                if (ans[i - 1] >= ans[i])
                    return false;
            }
            return true;
        }

        public void AddNodes(TreeNode root, List<int> ans)
        {
            if (root != null)
            {
                AddNodes(root.left,ans);
                ans.Add(root.val);
                AddNodes(root.right, ans);
            }
        }

        // 面试金典 4.6 https://leetcode-cn.com/problems/successor-lcci/
        public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
        {
            if (root == null) return null;
            TreeNode node = root;
            TreeNode temp = root;
            while (node != null)
            {
                if (node.val <= p.val)
                {
                    node = node.right;
                }
                else
                {
                    temp = node;
                    node = node.left;
                }
            }
            return temp.val>p.val ? temp : null;
        }

        // 面试金典 4.8 https://leetcode-cn.com/problems/first-common-ancestor-lcci/
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return null;

            if (root == p || root == q) return root;

            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);

            if (left != null && right != null) return root;
            else if (left == null) return right;
            else if (right == null) return left;

            return null;
        }

        public bool HasNode(TreeNode root, TreeNode x)
        {
            if (root == null) return false;
            if (root == x) return true;
            return HasNode(root.left, x) || HasNode(root.right, x);
        }

        // 面试金典 4.9 https://leetcode-cn.com/problems/bst-sequences-lcci/
        //public IList<IList<int>> BSTSequences(TreeNode root)
        //{

        //}

        // 面试金典 4.10 https://leetcode-cn.com/problems/check-subtree-lcci/
        public bool CheckSubTree(TreeNode t1, TreeNode t2)
        {
            StringBuilder t1Builder = new StringBuilder();
            StringBuilder t2Builder = new StringBuilder();

            preOrderTravel(t1, t1Builder);
            preOrderTravel(t2, t2Builder);

            string t1Str = t1Builder.ToString();
            string t2Str = t2Builder.ToString();

            return t1Str.Contains(t2Str);
        }

        public void preOrderTravel(TreeNode node, StringBuilder builder)
        {
            if (node == null) builder.Append(" ");
            else
            {
                builder.Append(node.val);
                preOrderTravel(node.left, builder);
                preOrderTravel(node.right, builder);
            }
        }

        // 面试金典 4.12 https://leetcode-cn.com/problems/paths-with-sum-lcci/
        public int PathSum(TreeNode root, int sum)
        {
            if (root == null) return 0;
            int rootPaht = countPath(root, 0, sum);

            int rightPath = PathSum(root.right, sum);
            int leftPath = PathSum(root.left, sum);


            return rootPaht + rightPath + leftPath;
        }

        public int countPath(TreeNode tree, int total, int sum)
        {
            if (tree == null) return 0;

            int allPaths = 0;

            total += tree.val;
            if(total == sum)
            {
                allPaths++;
            }

            allPaths += countPath(tree.left, total, sum);
            allPaths += countPath(tree.right, total, sum);
            return allPaths;
        }
    }
}
