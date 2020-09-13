using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalPractise
{
    class BasicStack
    {
        public class StackNode<T>
        {
            public T data;
            public StackNode<T> next;

            public StackNode(T data)
            {
                this.data = data;
            }
        }

        private StackNode<int> top;

        public int pop()
        {
            if (top == null)
            {
                throw new InvalidOperationException();
            }
            int val = top.data;
            top = top.next;
            return val;
        }

        public void push(int val)
        {
            StackNode<int> node = new StackNode<int>(val);
            node.next = top;
            top = node;
        }

        public int peek()
        {
            if (top == null)
            {
                throw new InvalidOperationException();
            }
            return top.data;
        }

        public bool isEmpty()
        {
            return top == null;
        }
    }

    // 优先队列

    // 双端队列
    class BasicStackAndQueue
    {

    }
}
