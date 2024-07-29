/*Challenge link:https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/description/
Question:
Given an array nums of n integers where nums[i] is in the range [1, n], return an array of all the integers in the range [1, n] that do not appear in nums.

 

Example 1:

Input: nums = [4,3,2,7,8,2,3,1]
Output: [5,6]
Example 2:

Input: nums = [1,1]
Output: [2]
 

Constraints:

n == nums.length
1 <= n <= 105
1 <= nums[i] <= n
 

Follow up: Could you do it without extra space and in O(n) runtime? You may assume the returned list does not count as extra space.
*/

//***************Solution********************
//[4,3,2,7,8,2,3,1], range 8
// 1 2 2 3 3 4 7 8
//           5 6 
//range 1 - n
public class Solution {
    public IList<int> FindDisappearedNumbers(int[] nums) {
        //loop through, nums length
        //get absolute value of current element - 1, set as index
        //if nums at index is greater than 0, invert sign
        for (int i = 0; i < nums.Length; i++) {
            int index = Math.Abs(nums[i]) - 1;
            if (nums[index] > 0)
             nums[index] = -nums[index];
        }
        var result = new List<int>();

        //loop through nums length
        //if current element at nums is greater than 0, add i+1 to result.
        for (int i = 0; i < nums.Length; i++) 
            if (nums[i] > 0) 
                result.Add(i+1);
        return result;
    }
}
