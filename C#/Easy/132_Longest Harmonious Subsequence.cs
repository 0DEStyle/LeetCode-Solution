/*Challenge link:https://leetcode.com/problems/longest-harmonious-subsequence/description/
Question:
We define a harmonious array as an array where the difference between its maximum value and its minimum value is exactly 1.

Given an integer array nums, return the length of its longest harmonious subsequence among all its possible subsequences.

A subsequence of array is a sequence that can be derived from the array by deleting some or no elements without changing the order of the remaining elements.

 

Example 1:

Input: nums = [1,3,2,2,5,2,3,7]
Output: 5
Explanation: The longest harmonious subsequence is [3,2,2,2,3].
Example 2:

Input: nums = [1,2,3,4]
Output: 2
Example 3:

Input: nums = [1,1,1,1]
Output: 0
 

Constraints:

1 <= nums.length <= 2 * 104
-109 <= nums[i] <= 109
*/

//***************Solution********************
public class Solution {
    public int FindLHS(int[] nums) {
        //sort array in ascending order
        Array.Sort(nums);
        int a = 0, b = 0, count = nums.Length, res = 0;

        //loop while a is less than count
        //if index a == b OR diff of a and b is 1, a++
        //else b++
        //update res
        while(a < count){
            if(nums[a] == nums[b] || nums[a] - nums[b] == 1)
                a++;
            else
                b++;
            res = nums[a - 1] - nums[b] == 1 ? Math.Max(res, a - b) : res;
        }
        return res;
    }
}
