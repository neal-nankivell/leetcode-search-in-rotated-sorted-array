using System;
using System.Linq;

namespace Solution
{
    /*
    Suppose an array sorted in ascending order is rotated
    at some pivot unknown to you beforehand.

    (i.e., [0,1,2,4,5,6,7] might become [4,5,6,7,0,1,2]).

    You are given a target value to search. If found in
    the array return its index, otherwise return -1.

    You may assume no duplicate exists in the array.

    Your algorithm's runtime complexity must be in the
    order of O(log n).
    */
    public interface ISolution
    {
        int Search(int[] nums, int target);
    }

    public class NaiveSolution : ISolution
    {
        public int Search(int[] nums, int target)
        {
            int result = -1;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target)
                {
                    return i;
                }
            }

            return result;
        }
    }

    public class ImprovedSolution : ISolution
    {
        public int Search(int[] nums, int target)
        {
            int result = -1;

            int startIndex = 0;
            int endIndex = nums.Length - 1;

            while (startIndex < endIndex)
            {
                int midIndex = ((endIndex - startIndex) / 2) + startIndex;

                int startValue = nums[startIndex];
                int endValue = nums[endIndex];
                int midValue = nums[midIndex];

                if (startValue == target) { return startIndex; }
                if (midValue == target) { return midIndex; }
                if (endValue == target) { return endIndex; }

                if (startValue < midValue && target > startValue && target < midValue)
                {
                    // The target is between the start and middle, and the start
                    // and the rotation point is not between these values
                    endIndex = midIndex - 1;
                    startIndex++;
                }
                else if (startValue > midValue && (target > startValue || target < midValue))
                {
                    // The rotation point is between the start and middle
                    // And the target is larger than the start or smaller than the middle
                    endIndex = midIndex - 1;
                    startIndex++;
                }
                else
                {
                    // Else we should look for the target in the second half
                    startIndex = midIndex + 1;
                    endIndex--;
                }
            }

            return result;
        }
    }
}
