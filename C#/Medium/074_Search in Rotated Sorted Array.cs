/*Challenge link:https://leetcode.com/problems/search-in-rotated-sorted-array/description/
Question:
There is an integer array nums sorted in ascending order (with distinct values).

Prior to being passed to your function, nums is possibly rotated at an unknown pivot index k (1 <= k < nums.length) such that the resulting array is [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed). For example, [0,1,2,4,5,6,7] might be rotated at pivot index 3 and become [4,5,6,7,0,1,2].

Given the array nums after the possible rotation and an integer target, return the index of target if it is in nums, or -1 if it is not in nums.

You must write an algorithm with O(log n) runtime complexity.

 

Example 1:

Input: nums = [4,5,6,7,0,1,2], target = 0
Output: 4
Example 2:

Input: nums = [4,5,6,7,0,1,2], target = 3
Output: -1
Example 3:

Input: nums = [1], target = 0
Output: -1
 

Constraints:

1 <= nums.length <= 5000
-104 <= nums[i] <= 104
All values of nums are unique.
nums is an ascending array that is possibly rotated.
-104 <= target <= 104
*/

//***************Solution********************
//binary search
public class Solution {
    public int Search(int[] A, int target) {
        //set boundaries
        int lo = 0, hi = A.Length - 1;

        while (lo < hi){
            //find mid index
            int mid = lo + (hi- lo) / 2;

            //if matches
            if (A[mid] == target)
                return mid;

            //if low index is less than or equal to mid
            //if target is less than or equal to low AND target is less than mid
            //shift high to left by 1, else shift low to right by 1
            if (A[lo] <= A[mid]){
                if (target >= A[lo] && target < A[mid])
                    hi = mid - 1;
                else
                    lo = mid + 1;
            }
            //if target is greater than mid, AND target is less than or equal to high
            //shift low to right by 1, else shift high to left by 1
            else{
                if (target > A[mid] && target <= A[hi])
                    lo = mid + 1;
                else
                    hi = mid - 1;
            }
        }
        //return -1 if target doesn't match, else return low.
        return A[lo] == target ? lo : -1;
    }
}
