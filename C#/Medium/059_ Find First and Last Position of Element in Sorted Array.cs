/*Challenge link:https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/description/
Question:
Given an array of integers nums sorted in non-decreasing order, find the starting and ending position of a given target value.

If target is not found in the array, return [-1, -1].

You must write an algorithm with O(log n) runtime complexity.

 

Example 1:

Input: nums = [5,7,7,8,8,10], target = 8
Output: [3,4]
Example 2:

Input: nums = [5,7,7,8,8,10], target = 6
Output: [-1,-1]
Example 3:

Input: nums = [], target = 0
Output: [-1,-1]
 

Constraints:

0 <= nums.length <= 105
-109 <= nums[i] <= 109
nums is a non-decreasing array.
-109 <= target <= 109
*/

//***************Solution********************
public class Solution {

    //find range of first and last occuraence of the number, and return those position in an array
    public int[] SearchRange(int[] nums, int target) {
        int left = FindFirstOccurrence(nums, target), right = FindLastOccurrence(nums, target);
        return new int[] { left, right };
    }

    //binary search to find first occurrence
    private int FindFirstOccurrence(int[] nums, int target) {
        //set boundaries
        int left = 0, right = nums.Length - 1, firstOccurrence = -1;

        while (left <= right) {
            //find mid index
            int mid = left + (right - left) / 2;

            if (nums[mid] >= target) {
                if (nums[mid] == target)
                    firstOccurrence = mid;
                right = mid - 1;
            }
            else 
                left = mid + 1;
        }
        return firstOccurrence;
    }

    //binary search to find last occurrence
    private int FindLastOccurrence(int[] nums, int target) {
        int left = 0, right = nums.Length - 1, lastOccurrence = -1;

        while (left <= right) {
            //find mid index
            int mid = left + (right - left) / 2;

            if (nums[mid] <= target) {
                if (nums[mid] == target)
                    lastOccurrence = mid;
                left = mid + 1;
            }
            else 
                right = mid - 1;
        }
        return lastOccurrence;
    }
}
