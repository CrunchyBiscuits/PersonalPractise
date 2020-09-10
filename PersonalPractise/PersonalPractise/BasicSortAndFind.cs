using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalPractise
{
    class BasicSortAndFind
    {
        // 二分查找
        public int binarySearch(int[] arr, int target)
        {
            if (arr == null || arr.Length == 0)
            {
                return -1;
            }
            int low = 0;
            int high = arr.Length - 1;
            int mid;

            while (low<=high)
            {
                mid = (low + high) / 2;
                if (arr[mid]<target)
                {
                    low = mid + 1;
                }
                else if(arr[mid]>target)
                {
                    high = mid - 1;
                }else
                {
                    return mid;
                }
            }
            // return low;
            return -1;
        }

        public int binarySearchRecursive(int[] arr, int target, int low, int high)
        {
            if (low > high)
            {
                return -1;
            }

            int mid = (low + high) / 2;
            if (arr[mid]<target)
            {
                return binarySearchRecursive(arr, target, mid+1, high);
            }
            else if (arr[mid]>target)
            {
                return binarySearchRecursive(arr, target, low, mid-1);
            }
            else
            {
                return mid;
            }
        }
    }
}
