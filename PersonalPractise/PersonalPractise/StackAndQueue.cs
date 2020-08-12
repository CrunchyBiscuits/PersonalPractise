using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PersonalPractise
{
    class StackAndQueue
    {


    }

    // 面试金典3.1 https://leetcode-cn.com/problems/three-in-one-lcci/
    class TripleInOne
    {
        private int[] arr;
        private int[] stackTop;
        private int stackSize;
        public TripleInOne(int stackSize)
        {
            this.stackSize = stackSize;
            arr = new int[stackSize * 3];
            stackTop = new int[] { 0, 1, 2 };
        }

        public void Push(int stackNum, int value)
        {
            int currentStackTop = stackTop[stackNum];
            if (currentStackTop / 3 == stackSize) return;
            arr[currentStackTop] = value;
            stackTop[stackNum] += 3;
        }

        public int Pop(int stackNum)
        {
            if (IsEmpty(stackNum))
            {
                return -1;
            }
            int value = arr[stackTop[stackNum] - 3];
            stackTop[stackNum] -= 3;
            return value;
        }

        public int Peek(int stackNum)
        {
            if (IsEmpty(stackNum))
            {
                return -1;
            }
            return arr[stackTop[stackNum] - 3];
        }

        public bool IsEmpty(int stackNum)
        {
            return stackTop[stackNum] < 3;
        }
    }

    // 面试金典3.2 https://leetcode-cn.com/problems/min-stack-lcci/
    class MinStack
    {
        Stack<int> s;
        Stack<int> minS;
        public MinStack()
        {
            s = new Stack<int>();
            minS = new Stack<int>();
        }

        public void Push(int x)
        {
            int minNum = x;
            if (minS.Peek() < x)
            {
                minNum = minS.Peek();
            }
            minS.Push(minNum);
            s.Push(x);
        }

        public void Pop()
        {
            s.Pop();
            minS.Pop();
        }

        public int Top()
        {
            return s.Peek();
        }

        public int GetMin()
        {
            return minS.Peek();
        }
    }

    // 面试金典3.3 https://leetcode-cn.com/problems/stack-of-plates-lcci/
    public class StackOfPlates
    {
        LinkedList<Stack<int>> stacks;
        int capacity;
        public StackOfPlates(int cap)
        {
            this.stacks = new LinkedList<Stack<int>>();
            this.capacity = cap;
        }

        public void Push(int val)
        {
            if (this.capacity <= 0) return;
            if (stacks.Count == 0 || stacks.First.Value.Count >= this.capacity)
            {
                stacks.AddFirst(new Stack<int>());
            }
            Stack<int> temp = stacks.First.Value;
            temp.Push(val);
        }

        public int Pop()
        {
            if (stacks.Count <= 0 || this.capacity <= 0) return -1;
            else
            {
                Stack<int> temp = stacks.First.Value;
                if (temp.Count > 0)
                {
                    int ans = temp.Pop();
                    if (temp.Count == 0)
                    {
                        stacks.Remove(temp);
                    }
                    return ans;
                }
                else
                {
                    return -1;
                }

            }
        }

        public int PopAt(int index)
        {
            if (stacks.Count <= 0 || this.capacity <= 0 || index >= stacks.Count) return -1;
            else
            {
                LinkedListNode<Stack<int>> node = stacks.Last;
                while (index > 0)
                {
                    node = node.Previous;
                    index--;
                }
                Stack<int> temp = node.Value;
                if (temp.Count > 0)
                {
                    int ans = temp.Pop();
                    if (temp.Count <= 0)
                    {
                        stacks.Remove(temp);
                    }
                    return ans;
                }
                else
                    return -1;
            }
        }
    }

    // 面试金典3.4 https://leetcode-cn.com/problems/implement-queue-using-stacks-lcci/
    public class MyQueue
    {
        private Stack<int> store;
        private Stack<int> helper;
        /** Initialize your data structure here. */
        public MyQueue()
        {
            this.store = new Stack<int>();
            this.helper = new Stack<int>();
        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            store.Push(x);
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            if (store.Count == 0)
                return -1;


            while (store.Count > 0)
            {
                helper.Push(store.Pop());
            }

            int ans = helper.Pop();

            while (helper.Count > 0)
            {
                store.Push(helper.Pop());
            }

            return ans;
        }

        /** Get the front element. */
        public int Peek()
        {
            if (store.Count == 0)
                return -1;

            while (store.Count > 0) 
            { 
                    helper.Push(store.Pop());
            }
            

            int ans = helper.Peek();

            while (helper.Count>0)
            {
                store.Push(helper.Pop());
            }

            return ans;
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            return store.Count == 0;
        }
    }

    // 面试金典3.5 https://leetcode-cn.com/problems/sort-of-stacks-lcci/
    public class SortedStack
    {
        Stack<int> store;
        Stack<int> helper;

        public SortedStack()
        {
            this.store = new Stack<int>();
            this.helper = new Stack<int>();
        }

        public void Push(int val)
        {
            int maxVal = store.Count == 0 ? int.MaxValue : store.Peek();
            int minVal = helper.Count == 0 ? int.MinValue : helper.Peek();

            while (true)
            {
                if (val > maxVal && store.Count > 0)
                {
                    helper.Push(store.Pop());
                }
                else if (val < minVal && helper.Count > 0)
                {
                    store.Push(helper.Pop());
                }
                else
                    break;
            }
            store.Push(val);
        }

        public void Pop()
        {
            while (helper.Count>0)
            {
                store.Push(helper.Pop());
            }

            if(store.Count > 0)
                store.Pop();
        }

        public int Peek()
        {
            while (helper.Count > 0)
            {
                store.Push(helper.Pop());
            }

            if (store.Count > 0)
                return store.Peek();
            else
                return -1;
        }

        public bool IsEmpty()
        {
            return store.Count == 0 && helper.Count == 0;
        }
    }

    // 面试金典3.6 https://leetcode-cn.com/problems/animal-shelter-lcci/
    public class AnimalShelf
    {
        LinkedList<int[]> all;
        public AnimalShelf()
        {
            all = new LinkedList<int[]>();
        }

        public void Enqueue(int[] animal)
        {
            all.AddLast(animal);
        }

        public int[] DequeueAny()
        {
            if (all.Count > 0)
            {
                int[] ans = all.First.Value;
                all.RemoveFirst();
                return ans;
            }
            else
                return new int[] { -1, -1 };
        }

        public int[] DequeueDog()
        {
            if (all.Count > 0)
            {
            LinkedListNode<int[]> node = all.First;
            while (true)
            {
                if (node.Value[1] == 1)
                {
                    all.Remove(node);
                    return node.Value;
                }
                else
                {
                    if (node.Next == null)
                        return new int[] { -1, -1 };
                    node = node.Next;
                }
            }
        }else
                return new int[] { -1, -1 };
        }

        public int[] DequeueCat()
        {
            if (all.Count > 0)
            {
                LinkedListNode<int[]> node = all.First;
                while (true)
                {
                    if (node.Value[1] == 0)
                    {
                        all.Remove(node);
                        return node.Value;
                    }
                    else
                    {
                        if (node.Next == null)
                            return new int[] { -1, -1 };
                        node = node.Next;
                    }
                }
            }
            else
                return new int[] { -1, -1 };
        }
    }
}
