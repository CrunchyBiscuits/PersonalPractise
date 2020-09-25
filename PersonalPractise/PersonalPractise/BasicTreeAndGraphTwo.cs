using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalPractise
{
    class BasicTreeAndGraphTwo
    {
        // 785判断二分图，通过着色的方法判断是否满足二分图
        public bool IsBipartite(int[][] graph)
        {
            int[] colors = new int[graph.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                // 保证遍历所有节点
                if (colors[i]==0&&!dfs(graph,i,colors,1))
                {
                    return false;
                }
            }
            return true;
        }

        bool dfs(int[][] graph, int cur, int[] colors, int color)
        {
            colors[cur] = color;
            foreach (int next in graph[cur])
            {
                // 颜色相同返回false
                if (colors[next]==color)
                {
                    return false;
                }
                // 如果下一个节点没有着色，进行递归查找
                if (colors[next]==0&&!dfs(graph,next,colors,-color))
                {
                    return false;
                }
            }
            return true;
        }

        // 1168 水资源分配优化，最小生成树


        // 1136 平行课程，拓扑算法
        // 拓扑排序条件，无环有向图
        // 节点之间有制约关系，每个顶点只出现一次

        // 克隆图
        public class CloneGraphs
        {
            public class Node
            {
                public int val;
                public IList<Node> neighbors;

                public Node()
                {
                    val = 0;
                    neighbors = new List<Node>();
                }

                public Node(int _val)
                {
                    val = _val;
                    neighbors = new List<Node>();
                }

                public Node(int _val, List<Node> _neighbors)
                {
                    val = _val;
                    neighbors = _neighbors;
                }
            }

            public Node CloneGraph(Node node)
            {
                if (node == null)
                {
                    return node;
                }

                Dictionary<Node, Node> visited = new Dictionary<Node, Node>();
                Queue<Node> queue = new Queue<Node>();
                queue.Enqueue(node);
                visited.Add(node, new Node(node.val, new List<Node>()));
                while (queue.Count!=0)
                {
                    Node n = queue.Dequeue();
                    foreach (Node neighbour in n.neighbors)
                    {
                        if (!visited.ContainsKey(neighbour))
                        {
                            visited.Add(neighbour, new Node(neighbour.val, new List<Node>()));
                            queue.Enqueue(neighbour);
                        }
                        visited[n].neighbors.Add(visited[neighbour]);
                    }

                }


                return visited[node];
            }
        }

    }
}
