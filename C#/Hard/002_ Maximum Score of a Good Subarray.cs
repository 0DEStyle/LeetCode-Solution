/*Challenge link:https://leetcode.com/problems/maximum-score-of-a-good-subarray/description/
Question:
You are given an array of integers nums (0-indexed) and an integer k.

The score of a subarray (i, j) is defined as min(nums[i], nums[i+1], ..., nums[j]) * (j - i + 1). A good subarray is a subarray where i <= k <= j.

Return the maximum possible score of a good subarray.

 

Example 1:

Input: nums = [1,4,3,7,4,5], k = 3
Output: 15
Explanation: The optimal subarray is (1, 5) with a score of min(4,3,7,4,5) * (5-1+1) = 3 * 5 = 15. 
Example 2:

Input: nums = [5,5,4,5,4,1,1,1], k = 0
Output: 20
Explanation: The optimal subarray is (0, 4) with a score of min(5,5,4,5,4) * (4-0+1) = 4 * 5 = 20.
 

Constraints:

1 <= nums.length <= 105
1 <= nums[i] <= 2 * 104
0 <= k < nums.length
*/

//***************Solution********************
//2 pointers
public class Solution {
    public int MaximumScore(int[] nums, int k) {
        //set boundaries
        int left = k, right = k, min_val = nums[k],  max_score = min_val, len = nums.Length - 1;

        //while k is greater than 0 OR k is less than len
        //if left equal 0 OR (k is less than len AND nums right + 1 is greater than nums left -1
        //increase right by 1, else decrease left by 1
        while (left > 0 || right < len) {
            if (left == 0 || (right < len && nums[right + 1] > nums[left - 1]))
                right++;
            else
                left--;

            //select min value
            min_val = Math.Min(min_val, Math.Min(nums[left], nums[right]));
            //select max value
            max_score = Math.Max(max_score, min_val * (right - left + 1));
        }
        return max_score;
    }
}
