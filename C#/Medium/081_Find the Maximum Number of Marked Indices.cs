/*Challenge link:https://leetcode.com/problems/find-the-maximum-number-of-marked-indices/
Question:

Code
Testcase
Testcase
Test Result
2576. Find the Maximum Number of Marked Indices
Medium
Topics
Companies
Hint
You are given a 0-indexed integer array nums.

Initially, all of the indices are unmarked. You are allowed to make this operation any number of times:

Pick two different unmarked indices i and j such that 2 * nums[i] <= nums[j], then mark i and j.
Return the maximum possible number of marked indices in nums using the above operation any number of times.

 

Example 1:

Input: nums = [3,5,2,4]
Output: 2
Explanation: In the first operation: pick i = 2 and j = 1, the operation is allowed because 2 * nums[2] <= nums[1]. Then mark index 2 and 1.
It can be shown that there's no other valid operation so the answer is 2.
Example 2:

Input: nums = [9,2,5,4]
Output: 4
Explanation: In the first operation: pick i = 3 and j = 0, the operation is allowed because 2 * nums[3] <= nums[0]. Then mark index 3 and 0.
In the second operation: pick i = 1 and j = 2, the operation is allowed because 2 * nums[1] <= nums[2]. Then mark index 1 and 2.
Since there is no other operation, the answer is 4.
Example 3:

Input: nums = [7,6,8]
Output: 0
Explanation: There is no valid operation to do, so the answer is 0.

 

Constraints:

1 <= nums.length <= 105
1 <= nums[i] <= 109
*/

//***************Solution********************
//2 pointers
public class Solution {
    public int MaxNumOfMarkedIndices(int[] nums) {
        //if length is less than 2, return 0
        //set boundaries and sort nums in ascending order
        if (nums.Length < 2) return 0;
        Array.Sort(nums);
        int left = 0, right = (nums.Length + 1) / 2, res = 0;

        //loop while num length is greater than right
        //if condition met, shift left to right by 1, increase res by 2
        while (right < nums.Length){
            if (nums[left] * 2 <= nums[right]){
                left++;
                res += 2;
            }
            //increase right by 1 for next iteration
            right++;
        }
        return res;
    }
}
