/*Challenge link:https://leetcode.com/problems/longest-increasing-subsequence/description/
Question:
Given an integer array nums, return the length of the longest strictly increasing 
subsequence
.

 

Example 1:

Input: nums = [10,9,2,5,3,7,101,18]
Output: 4
Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4.
Example 2:

Input: nums = [0,1,0,3,2,3]
Output: 4
Example 3:

Input: nums = [7,7,7,7,7,7,7]
Output: 1
 

Constraints:

1 <= nums.length <= 2500
-104 <= nums[i] <= 104
 

Follow up: Can you come up with an algorithm that runs in O(n log(n)) time complexity?
*/

//***************Solution********************
//binary search method
public class Solution {
    public int LengthOfLIS(int[] nums) {
        //create tail array
        //size for output
        int[] tails = new int[nums.Length];
        int size = 0;

        foreach(int x in nums) {
            int low = 0, high = size;

            while (low != high) {
                //find mid index
                int mid = low + (high - low) / 2;

                //check if condition met, if true, shift low to right by 1 index
                //else shift high to mid
                if (tails[mid] < x)
                    low = mid + 1;
                else
                    high = mid;
            }
            //set low index to current element
            //if low is equal to size, increase size by 1
            tails[low] = x;
            if (low == size) ++size;
        }
        return size;
    }
}
