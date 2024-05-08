/*Challenge link:https://leetcode.com/problems/sorting-three-groups/description/
Question:
You are given an integer array nums. Each element in nums is 1, 2 or 3. In each operation, you can remove an element from nums. Return the minimum number of operations to make nums non-decreasing.

 

Example 1:

Input: nums = [2,1,3,2,1]

Output: 3

Explanation:

One of the optimal solutions is to remove nums[0], nums[2] and nums[3].

Example 2:

Input: nums = [1,3,2,1,3,3]

Output: 2

Explanation:

One of the optimal solutions is to remove nums[1] and nums[2].

Example 3:

Input: nums = [2,2,2,2,3,3]

Output: 0

Explanation:

nums is already non-decreasing.

 

Constraints:

1 <= nums.length <= 100
1 <= nums[i] <= 3
 

Follow-up: Can you come up with an algorithm that runs in O(n) time complexity?
*/

//***************Solution********************
public class Solution {
    public int MinimumOperations(IList<int> nums) {
        //count num in list
        //create dp(dynamic programming) storage, with n,n,n,n
        int n = nums.Count;
        var dp = new int[] { n, n, n, n };

        //loop through all num in nums
        //decrease num by , select min value between dp[2] and dp[1], update to dp[2]
        //select min value between dp[3] and dp[3], update to dp[2]
        foreach (int num in nums){
            dp[num]--;                       //update result each iteration
            dp[2] = Math.Min(dp[2], dp[1]);  //2nd to last
            dp[3] = Math.Min(dp[3], dp[2]);  //last value
        }
        //return the last value of dp
        return dp[3];
    }
}
