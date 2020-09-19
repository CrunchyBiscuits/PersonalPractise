using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PersonalPractise
{
    class ConcurrencyPractise
    {
    }
    // 1114
    public class Foo
    {
        int flag = 1;
        public Foo()
        {

        }

        public void First(Action printFirst)
        {
            while (flag!=1)
            {
                Thread.Sleep(1);
            }
            // printFirst() outputs "first". Do not change or remove this line.
            printFirst();
            flag = 2;
        }

        public void Second(Action printSecond)
        {
            while (flag != 2)
            {
                Thread.Sleep(1);
            }
            // printSecond() outputs "second". Do not change or remove this line.
            printSecond();
            flag = 3;
        }

        public void Third(Action printThird)
        {
            while (flag != 3)
            {
                Thread.Sleep(1);
            }
            // printThird() outputs "third". Do not change or remove this line.
            printThird();
        }
    }
}
