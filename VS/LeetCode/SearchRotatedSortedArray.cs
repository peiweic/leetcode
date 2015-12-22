using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class SearchRotatedSortedArray
    {
        /*
        Suppose a sorted array is rotated at some pivot unknown to you beforehand.

        (i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).

        You are given a target value to search. If found in the array return its index, otherwise return -1.

        You may assume no duplicate exists in the array.
        */
        public int Search(int[] nums, int target)
        {
            return SearchInternal(nums, target, 0, nums.Length-1);
        }

        private int SearchInternal(int[] nums, int target, int begin, int end)
        {
            if (begin > end) return -1;
            if (begin == end ) return nums[begin] == target ? begin : -1;

            int mid = (begin + end) / 2;
            if (target == nums[mid]) return mid;
            
            if (nums[mid] >= nums[begin]) //left is normal; right is potentially rotated
            {
                return nums[mid] >= target && nums[begin] <= target ?
                     SearchInternal(nums, target, begin, mid - 1) :
                     SearchInternal(nums, target, mid + 1, end);
            } else  //right is normal 
            {
                return nums[mid] < target && nums[end] >= target ?
                    SearchInternal(nums, target, mid + 1, end) :
                    SearchInternal(nums, target, begin, mid - 1);
            }
        }

        public static void Test()
        {
            SearchRotatedSortedArray test = new SearchRotatedSortedArray();
            int[] data = new int[] { 3, 1 }; //{4,5,6,7,0,1,2};
            int ret = test.Search(data, 1);
        }
    }
}
