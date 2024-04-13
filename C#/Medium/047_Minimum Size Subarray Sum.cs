/*Challenge link:https://leetcode.com/problems/minimum-size-subarray-sum/description/
Question:
Given an array of positive integers nums and a positive integer target, return the minimal length of a 
subarray
 whose sum is greater than or equal to target. If there is no such subarray, return 0 instead.

 

Example 1:

Input: target = 7, nums = [2,3,1,2,4,3]
Output: 2
Explanation: The subarray [4,3] has the minimal length under the problem constraint.
Example 2:

Input: target = 4, nums = [1,4,4]
Output: 1
Example 3:

Input: target = 11, nums = [1,1,1,1,1,1,1,1]
Output: 0
 

Constraints:

1 <= target <= 109
1 <= nums.length <= 105
1 <= nums[i] <= 104
 

Follow up: If you have figured out the O(n) solution, try coding another solution of which the time complexity is O(n log(n)).
*/

//***************Solution********************
//2 pointers 
public class Solution {
    public int MinSubArrayLen(int target, int[] nums) {
        //l left, r right, s sum
        int l = 0, s = 0, res = int.MaxValue;

        for (int r = 0; r < nums.Length; r++) {
            //accumulate sum at index r
            s += nums[r];

            //check if current sum is greater or equal to target
            //if true, select min value between res and r - l + 1, 0 indexed. update the result
            //decrease s by num[l]
            //shift l to right by 1 index
            while (s >= target) {
                res = Math.Min(res, r - l + 1);
                s -= nums[l];
                l++;
            }
        }
        //if res is not equal to max value, return res, else 0
        return res != int.MaxValue ? res : 0;
    }
}
