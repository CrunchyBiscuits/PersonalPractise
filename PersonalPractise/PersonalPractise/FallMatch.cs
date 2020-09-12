using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonalPractise
{
    class FallMatch
    {
        public int Calculate(string s)
        {
            int x = 1;
            int y = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'A')
                {
                    x = 2 * x + y;
                }
                else
                {
                    y = 2 * y + x;
                }
            }

            return x + y;
        }

        public int BreakfastNumber(int[] staple, int[] drinks, int x)
        {
            int ans = 0;
            Array.Sort(drinks);
            for (int i = 0; i < staple.Length; i++)
            {
                if (staple[i]>=x)
                {
                    continue;
                }
                else
                {
                    int temp = x - staple[i];
                    int low = 0;
                    int high = drinks.Length - 1;
                    int mid = 0;
                    while (low<=high)
                    {
                        mid = (low + high) / 2;
                        if (drinks[mid]>temp)
                        {
                            high = mid - 1;
                        }
                        else if (drinks[mid]<temp)
                        {
                            low = mid + 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                    ans += (mid+1);
                }
            }

            return ans%1000000007;
        }

        public int MinimumOperations(string leaves)
        {
            int ans = 0;
            int left = 0;
            int right = leaves.Length - 1;
            bool hasSeenYellowLeft = false;
            bool hasSeenYellowRight = false;
            while (left!=right)
            {
                if (!hasSeenYellowLeft&&leaves[left]=='y')
                {
                    hasSeenYellowLeft = true;
                }
                if (!hasSeenYellowLeft && leaves[left] == 'y')
                {
                    hasSeenYellowLeft = true;
                }

                left++;
                right--;
            }

            return ans = 0;
        }
    }
}
