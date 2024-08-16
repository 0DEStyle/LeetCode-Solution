/*Challenge link:https://leetcode.com/problems/monotonic-array/description/
Question:
An array is monotonic if it is either monotone increasing or monotone decreasing.

An array nums is monotone increasing if for all i <= j, nums[i] <= nums[j]. An array nums is monotone decreasing if for all i <= j, nums[i] >= nums[j].

Given an integer array nums, return true if the given array is monotonic, or false otherwise.

 

Example 1:

Input: nums = [1,2,2,3]
Output: true
Example 2:

Input: nums = [6,5,4,4]
Output: true
Example 3:

Input: nums = [1,3,2]
Output: false
 

Constraints:

1 <= nums.length <= 105
-105 <= nums[i] <= 105
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.   
public class Solution {
    public bool IsMonotonic(int[] n) {
        if (n.Length < 2) return true;

        int direction = 0;  // 0 means unknown, 1 means increasing, -1 means decreasing

        for (int i = 1; i < n.Length; i++) {
            if (n[i] > n[i-1]) {  // increasing
                if (direction == 0) 
                    direction = 1;
                else if (direction == -1) 
                    return false;
            } 
            else if (n[i] < n[i-1]) {  // decreasing
                if (direction == 0) 
                    direction = -1;
                else if (direction == 1) 
                    return false;
            }
        }
        return true;
    }
}
