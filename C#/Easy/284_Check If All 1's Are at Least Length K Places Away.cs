/*Challenge link:https://leetcode.com/problems/check-if-all-1s-are-at-least-length-k-places-away/description/
Question:
Given an binary array nums and an integer k, return true if all 1's are at least k places away from each other, otherwise return false.

 

Example 1:


Input: nums = [1,0,0,0,1,0,0,1], k = 2
Output: true
Explanation: Each of the 1s are at least 2 places away from each other.
Example 2:


Input: nums = [1,0,0,1,0,1], k = 2
Output: false
Explanation: The second 1 and third 1 are only one apart from each other.
 

Constraints:

1 <= nums.length <= 105
0 <= k <= nums.length
nums[i] is 0 or 1

*/

//***************Solution********************
public class Solution {
    public bool KLengthApart(int[] nums, int k) {
        int count = k;
        for(int i = 0; i < nums.Length; i++){
            //matches 0, increase count by 1
            //if count greater than k distance, reset count
            //else return false
            if(nums[i]==0)
                count++;
            else if (count >= k)
                count = 0;
            else
                return false;
    }
    return true;
}}
