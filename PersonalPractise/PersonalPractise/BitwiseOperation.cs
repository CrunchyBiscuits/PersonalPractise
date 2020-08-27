using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalPractise
{

    class BitwiseOperation
    {
        public static void Main(string[] args)
        {
            BitwiseOperation a = new BitwiseOperation();
            int[] ans = a.FindClosedNumbers(2);
            foreach (var item in ans)
            {
                Console.WriteLine(item);
            }
        }
        // 面试金典 5.1
        public int InsertBits(int N, int M, int i, int j)
        {
            for (int k = i; k <= j; k++)
            {
                N &= ~(1 << k);
            }

            return N | (M << i);
        }

        // 面试金典 5.2
        public string PrintBin(double num)
        {
            StringBuilder sbuilder = new StringBuilder();
            sbuilder.Append("0.");
            while (num != 0)
            {
                num *= 2;
                if (num >= 1)
                {
                    sbuilder.Append(1);
                    num = num - (int)num;
                }
                else
                {
                    sbuilder.Append(0);
                }
                if (sbuilder.Length > 32)
                {
                    return "ERROR";
                }
            }
            return sbuilder.ToString();
        }

        // 面试金典 5.3
        public int ReverseBits(int num)
        {
            int cnt1 = 1;
            int pos = -1;
            int result = 0;
            for (int i = 0; i < 33; i++)
            {
                if ((num & 1) == 1)
                {
                    cnt1++;
                }
                else
                {
                    result = Math.Max(result, cnt1);
                    cnt1 = i - pos;
                    pos = i;
                }
                num >>= 1;
                num &= 0x7fffffff;
            }

            return result;
        }

        // 面试金典 5.4
        public int[] FindClosedNumbers(int num)
        {
            int[] ans = { -1, -1 };
            int ones = calculateOne(num);

            for(int i = num + 1; i < 2147483647; i++)
            {
                if(ones == calculateOne(i))
                {
                    ans[0] = i;
                    break;
                }
            }

            for(int i = num - 1; i >= 1; i--)
            {
                if (ones == calculateOne(i))
                {
                    ans[1] = i;
                    break;
                }
            }


            return ans;
        }

        public int calculateOne(int num)
        {
            string numStr = Convert.ToString(num, 2);
            int count = 0;
            foreach (var item in numStr)
            {
                if(item == '1')
                {
                    count++;
                }
            }
            return count;
        }

        // 面试金典 5.5
        public int ConvertInteger(int A, int B)
        {
            int num = A ^ B;
            string str = Convert.ToString(num, 2);
            int count = 0;
            foreach (var item in str)
            {
                if (item == '1')
                {
                    count++;
                }
            }
            return count;
        }

        // 面试金典 5.6
        public int ExchangeBits(int num)
        {
            long evenNum = num & 0xaaaaaaaa;
            long oddNum = num & 0x5555555555;

            evenNum >>= 1;

            oddNum <<= 1;

            return (int)(oddNum | evenNum);
        }
    }
}
