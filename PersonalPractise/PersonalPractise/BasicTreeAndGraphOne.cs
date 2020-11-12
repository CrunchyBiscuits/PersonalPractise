using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonalPractise
{
    class BasicTreeAndGraphOne
    {
        //public static void Main()
        //{
        //    BasicTreeAndGraphOne test = new BasicTreeAndGraphOne();
        //    test.deserialize("1,2,3,null,null,4,5");
        //}

        // 297 序列化，反序列化
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            return serializeHelper(root, "");
        }

        public string serializeHelper(TreeNode root, string str)
        {
            if (root == null)
            {
                str += "null,";
            }
            else
            {
                str += root.val + ",";
                str += serializeHelper(root.left, str);
                str += serializeHelper(root.right, str);
            }
            return str;
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            string[] str_arr = data.Split(",");
            LinkedList<string> data_list = new LinkedList<string>(str_arr);
            foreach (var item in data_list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(data_list.Count);
            return deserializeHelper(data_list);
        }

        public TreeNode deserializeHelper(LinkedList<string> l)
        {
            if (l.First.Value.Equals("null"))
            {
                l.RemoveFirst();
                return null;
            }

            //Console.WriteLine(l.First.Value);
            TreeNode node = new TreeNode(int.Parse(l.First.Value));
            l.RemoveFirst();

            node.left = deserializeHelper(l);
            node.right = deserializeHelper(l);

            return node;
        }

        // 450 删除二叉树中的节点
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null)
            {
                return root;
            }

            if (key<root.val)
            {
                root.left = DeleteNode(root.left, key);
            }
            else if (key>root.val)
            {
                root.right = DeleteNode(root.right, key);
            }
            else
            {
                if (root.left==null&&root.right==null)
                {
                    root = null;
                }
                else if (root.right!=null)
                {
                    root.val = findSuccessor(root);
                    root.right = DeleteNode(root.right, root.val);
                }
                else
                {
                    root.val = findPredecessor(root);
                    root.left = DeleteNode(root.left, root.val);
                }
            }
            return root;
        }

        // 找后继
        public int findSuccessor(TreeNode root)
        {
            root = root.right;
            while (root.left!=null)
            {
                root = root.left;
            }
            return root.val;
        }

        // 找前驱
        public int findPredecessor(TreeNode root)
        {
            root = root.left;
            while (root.right != null)
            {
                root = root.right;
            }
            return root.val;
        }

        // 951 反转等价二叉树
        public bool FlipEquiv(TreeNode root1, TreeNode root2)
        {
            if (root1==null&&root2==null)
            {
                return true;
            }
            else if (root1==null||root2==null||root1.val!=root2.val)
            {
                return false;
            }

            return FlipEquiv(root1.left,root2.left)&&FlipEquiv(root1.right,root2.right)||
                FlipEquiv(root1.right,root2.left)&&FlipEquiv(root1.left,root2.right);
        }

        // 1008 根据先序遍历构造二叉树
        public class TempSol
        {
            int[] preorder;
            int n;
            int index=0;
            public TreeNode BstFromPreorder(int[] preorder)
            {
                this.preorder = preorder;
                n = preorder.Length;
                return helper(int.MinValue,int.MaxValue);
            }

            public TreeNode helper(int lowerBound, int upperBound)
            {
                if (index == n)
                {
                    return null;
                }

                int cur = preorder[index];

                if (cur< lowerBound||cur>upperBound)
                {
                    return null;
                }
                index++;
                TreeNode node = new TreeNode(cur);
                node.left = helper(lowerBound, cur);
                node.right = helper(cur, upperBound);
                return node;
            }
        }

        // 559 N叉树最大深度
        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }
        public int MaxDepth(Node root)
        {
            if (root==null)
            {
                return 0;
            }
            else if (root.children.Count==0)
            {
                return 1;
            }

            int depth = 0;
            foreach (Node item in root.children)
            {
                depth = Math.Max(MaxDepth(item),depth);
            }


            return depth+1;
        }

        // 298 最长连续数列
        public int LongestConsecutive(TreeNode root)
        {
            return LongestConsecutiveHelper(root,null,0);
        }

        public int LongestConsecutiveHelper(TreeNode root, TreeNode parent, int length)
        {
            if (root==null)
            {
                return length;
            }

            length = (parent != null && root.val == parent.val + 1) ?length+1: 1;


            return Math.Max(length, Math.Max(LongestConsecutiveHelper(root.left,root,length),LongestConsecutiveHelper(root.right,root,length)));
        }

        // 1028 先序遍历还原二叉树
        public TreeNode RecoverFromPreorder(string S)
        {
            Stack<TreeNode> path = new Stack<TreeNode>();
            int pos = 0;
            while (pos<S.Length)
            {
                int level = 0;
                // 判断在第几层
                while (S[pos]=='-')
                {
                    level++;
                    pos++;
                }
                int value = 0;
                // 获取需要存储的数字
                while (pos<S.Length&&char.IsDigit(S[pos]))
                {
                    value = value * 10 + (S[pos] - '0');
                    pos++;
                }

                // 创建节点
                TreeNode node = new TreeNode(value);

                // 如果等于栈的大小，说明是当前节点的左节点
                if (level == path.Count)
                {
                    if (path.Count!=0)
                    {
                        path.Peek().left = node;
                    }
                }
                // 如果不是，那么是路径上某一结点的右节点，那么只需要弹出栈顶，直到找到那个节点即可
                else
                {
                    while (level!=path.Count)
                    {
                        path.Pop();
                    }
                    path.Peek().right = node;
                }
                path.Push(node);
            }

            // 保留只剩一个根节点
            while (path.Count>1)
            {
                path.Pop();
            }
            return path.Peek();
        }

        // 树与递归
        // 100 相同的树
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p==null&&q==null)
            {
                return true;
            }
            else if (p==null||q==null)
            {
                return false;
            }
            else if (p.val != q.val)
            {
                return false;
            }
            else
            {
                return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            }
        }
        // 222 完全二叉树的节点个数
        public int CountNodes(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                return 1 + CountNodes(root.right) + CountNodes(root.left);
            }
        }
        // 101 对称二叉树
        public bool IsSymmetric(TreeNode root)
        {
            return helpCheckSymmetric(root,root);
        }

        public bool helpCheckSymmetric(TreeNode p, TreeNode q)
        {
            if (p==null&&q==null)
            {
                return true;
            }

            if (p==null || q==null)
            {
                return false;
            }

            return p.val == q.val && helpCheckSymmetric(p.left, q.right) && helpCheckSymmetric(p.right, q.left);
        }
        // 226 反转二叉树
        public TreeNode InvertTree(TreeNode root)
        {
            if (root==null)
            {
                return null;
            }
            if (root!=null)
            {
                TreeNode temp = root.left;
                root.left = root.right;
                root.right = temp;
            }
            if (root.left!=null)
            {
                InvertTree(root.left);
            }
            if (root.right!=null)
            {
                InvertTree(root.right);
            }

            return root;
        }
        // 437 路径总和

        // 563
        // 617
        // 508
        // 572
        // 543
        // 654
        // 687
        // 87

        // 树的层次遍历
        // 102
        // 429
        // 690
        // 559
        // 662
        // 671
        // 513
        // 515
        // 637
        // 103
        // 107
        // 257
        // 623
        // 653
        // 104
        // 111
        // 112
        // 113
        // 129
        // 404
        // 199
        // 655
        // 116
        // 117
    }
}
