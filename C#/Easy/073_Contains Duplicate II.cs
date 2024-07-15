/*Challenge link:https://leetcode.com/problems/contains-duplicate-ii/description/
Question:
Given an integer array nums and an integer k, return true if there are two distinct indices i and j in the array such that nums[i] == nums[j] and abs(i - j) <= k.

 

Example 1:

Input: nums = [1,2,3,1], k = 3
Output: true
Example 2:

Input: nums = [1,0,1,1], k = 1
Output: true
Example 3:

Input: nums = [1,2,3,1,2,3], k = 2
Output: false
 

Constraints:

1 <= nums.length <= 105
-109 <= nums[i] <= 109
0 <= k <= 105
*/

//***************Solution********************
public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        //create hashset
        var numIndices = new HashSet<int>();
        
        //loop through num.length
        //if hashset contains currrent element of nums, return true
        //add current nums into hashset
        //if hashset count is greater than k
        //remove hashset element at nums[i-k]
        for (int i = 0; i < nums.Length; i++){
            if (numIndices.Contains(nums[i])) 
                return true;
            numIndices.Add(nums[i]);
            if (numIndices.Count > k) 
                numIndices.Remove(nums[i - k]);
        }
        //no match
        return false;
    }
}
