/*Challenge link:https://leetcode.com/problems/move-zeroes/description/
Question:
Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

Note that you must do this in-place without making a copy of the array.

 

Example 1:

Input: nums = [0,1,0,3,12]
Output: [1,3,12,0,0]
Example 2:

Input: nums = [0]
Output: [0]
 

Constraints:

1 <= nums.length <= 104
-231 <= nums[i] <= 231 - 1
 

Follow up: Could you minimize the total number of operations done?
*/

//***************Solution********************
public class Solution {
    public void MoveZeroes(int[] nums , int left = 0){
        //loop through num. length
        //if num right is not 0, (left, right) = (right, left), increase left by 1
        for (int right = 0; right < nums.Length; right++){
            if(nums[right] != 0){
                (nums[left], nums[right]) = (nums[right], nums[left]);
                left ++;
            }
        }
    }
}
