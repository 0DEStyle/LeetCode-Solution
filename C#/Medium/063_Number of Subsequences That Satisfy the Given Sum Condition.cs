/*Challenge link:https://leetcode.com/problems/number-of-subsequences-that-satisfy-the-given-sum-condition/description/
Question:
You are given an array of integers nums and an integer target.

Return the number of non-empty subsequences of nums such that the sum of the minimum and maximum element on it is less or equal to target. Since the answer may be too large, return it modulo 109 + 7.

 

Example 1:

Input: nums = [3,5,6,7], target = 9
Output: 4
Explanation: There are 4 subsequences that satisfy the condition.
[3] -> Min value + max value <= target (3 + 3 <= 9)
[3,5] -> (3 + 5 <= 9)
[3,5,6] -> (3 + 6 <= 9)
[3,6] -> (3 + 6 <= 9)
Example 2:

Input: nums = [3,3,6,8], target = 10
Output: 6
Explanation: There are 6 subsequences that satisfy the condition. (nums can have repeated numbers).
[3] , [3] , [3,3], [3,6] , [3,6] , [3,3,6]
Example 3:

Input: nums = [2,3,3,4,6,7], target = 12
Output: 61
Explanation: There are 63 non-empty subsequences, two of them do not satisfy the condition ([6,7], [7]).
Number of valid subsequences (63 - 2 = 61).
 

Constraints:

1 <= nums.length <= 105
1 <= nums[i] <= 106
1 <= target <= 106
*/

//***************Solution********************
public class Solution {
    public int NumSubseq(int[] nums, int target) {
        //sort in ascending order
        Array.Sort(nums);
        // Initialize variables, 10^9+7 = 1000000007
        int mod = 1000000007, n = nums.Length, ans = 0;

        // Use two pointers to find subsequences
        int left = 0, right = n - 1;

        // Calculate powers of 2 modulo mod
        var pow2 = new int[n];
        pow2[0] = 1;
        for (int i = 1; i < n; i++)
            pow2[i] = (pow2[i - 1] * 2) % mod;

        while (left <= right) {
            // If the sum of the minimum and maximum values is less than or equal to target,
            // add the number of subsequences of length (right - left) to the answer
            // else, move the right pointer to the left
            if (nums[left] + nums[right] <= target) {
                ans = (ans + pow2[right - left]) % mod;
                left++;
            }
            else
                right--;
        }
        return ans;
    }
}
