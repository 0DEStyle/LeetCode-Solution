/*Challenge link:https://leetcode.com/problems/earliest-second-to-mark-indices-i/description/
Question:
You are given two 1-indexed integer arrays, nums and, changeIndices, having lengths n and m, respectively.

Initially, all indices in nums are unmarked. Your task is to mark all indices in nums.

In each second, s, in order from 1 to m (inclusive), you can perform one of the following operations:

Choose an index i in the range [1, n] and decrement nums[i] by 1.
If nums[changeIndices[s]] is equal to 0, mark the index changeIndices[s].
Do nothing.
Return an integer denoting the earliest second in the range [1, m] when all indices in nums can be marked by choosing operations optimally, or -1 if it is impossible.

 

Example 1:

Input: nums = [2,2,0], changeIndices = [2,2,2,2,3,2,2,1]
Output: 8
Explanation: In this example, we have 8 seconds. The following operations can be performed to mark all indices:
Second 1: Choose index 1 and decrement nums[1] by one. nums becomes [1,2,0].
Second 2: Choose index 1 and decrement nums[1] by one. nums becomes [0,2,0].
Second 3: Choose index 2 and decrement nums[2] by one. nums becomes [0,1,0].
Second 4: Choose index 2 and decrement nums[2] by one. nums becomes [0,0,0].
Second 5: Mark the index changeIndices[5], which is marking index 3, since nums[3] is equal to 0.
Second 6: Mark the index changeIndices[6], which is marking index 2, since nums[2] is equal to 0.
Second 7: Do nothing.
Second 8: Mark the index changeIndices[8], which is marking index 1, since nums[1] is equal to 0.
Now all indices have been marked.
It can be shown that it is not possible to mark all indices earlier than the 8th second.
Hence, the answer is 8.
Example 2:

Input: nums = [1,3], changeIndices = [1,1,1,2,1,1,1]
Output: 6
Explanation: In this example, we have 7 seconds. The following operations can be performed to mark all indices:
Second 1: Choose index 2 and decrement nums[2] by one. nums becomes [1,2].
Second 2: Choose index 2 and decrement nums[2] by one. nums becomes [1,1].
Second 3: Choose index 2 and decrement nums[2] by one. nums becomes [1,0].
Second 4: Mark the index changeIndices[4], which is marking index 2, since nums[2] is equal to 0.
Second 5: Choose index 1 and decrement nums[1] by one. nums becomes [0,0].
Second 6: Mark the index changeIndices[6], which is marking index 1, since nums[1] is equal to 0.
Now all indices have been marked.
It can be shown that it is not possible to mark all indices earlier than the 6th second.
Hence, the answer is 6.
Example 3:

Input: nums = [0,1], changeIndices = [2,2,2]
Output: -1
Explanation: In this example, it is impossible to mark all indices because index 1 isn't in changeIndices.
Hence, the answer is -1.
 

Constraints:

1 <= n == nums.length <= 2000
0 <= nums[i] <= 109
1 <= m == changeIndices.length <= 2000
1 <= changeIndices[i] <= n
*/

//***************Solution********************
public class Solution {
    public int EarliestSecondToMarkIndices(int[] nums, int[] changeIndices) {
        int n = nums.Length, m = changeIndices.Length;
        List<int>[] v = new List<int>[n];

        //loop through n store current i to list v
        for (int i = 0; i < n; ++i) v[i] = new List<int>();
        //loop through m, add index changesIndices i - 1, add i
        for (int i = 0; i < m; ++i) v[changeIndices[i] - 1].Add(i);

        //condition check, if false, return -1
        if (!check(nums, v, m - 1)) return -1;

        //set boundaries
        int left = 0, right = m - 1;
        while (left < right) {
            //get mid index
            int mid = left + (right - left) / 2;
            //if condition check is true, set right to mid, else shift left to right by 1 index
            if (check(nums, v, mid)) right = mid;
            else left = mid + 1;
        }
        //return left + 1
        return left + 1;
    }

    //helper method for validation check
     private bool check(int[] nums, List<int>[] v, int m) {
        int n = nums.Length;
        int[] data = new int[m + 1];

        //loop through nums.length
        for (int i = 0; i < n; ++i) {
            //if list count is 0 OR v[i][0] is less than m, return false
            if (v[i].Count == 0 || v[i][0] > m) return false;

            //set bondaries
            int left = 0, right = v[i].Count - 1;
            while (left < right) {
                //find mid index
                int mid = right - (right - left) / 2;

                //if v[i][mid] is less than or equal to m, set left to mid, else shift right to left by 1 index
                if (v[i][mid] <= m) left = mid;
                else right = mid - 1;
            }
            //accumulate sum for data, by adding current num + 1
            data[v[i][left]] += nums[i] + 1;
        }

        long sum = 0;
        //loop through m and accumulate data, if sum is greater than i + 1 return false
        for (int i = 0; i <= m; ++i) {
            sum += data[i];
            if (sum > i + 1) return false;
        }
        return true;
    }
}
