/*Challenge link:https://leetcode.com/problems/ways-to-split-array-into-three-subarrays/description/
Question:
A split of an integer array is good if:

The array is split into three non-empty contiguous subarrays - named left, mid, right respectively from left to right.
The sum of the elements in left is less than or equal to the sum of the elements in mid, and the sum of the elements in mid is less than or equal to the sum of the elements in right.
Given nums, an array of non-negative integers, return the number of good ways to split nums. As the number may be too large, return it modulo 109 + 7.

 

Example 1:

Input: nums = [1,1,1]
Output: 1
Explanation: The only good way to split nums is [1] [1] [1].
Example 2:

Input: nums = [1,2,2,2,5,0]
Output: 3
Explanation: There are three good ways of splitting nums:
[1] [2] [2,2,5,0]
[1] [2,2] [2,5,0]
[1,2] [2,2] [5,0]
Example 3:

Input: nums = [3,2,1]
Output: 0
Explanation: There is no good way to split nums.
 

Constraints:

3 <= nums.length <= 105
0 <= nums[i] <= 104
*/

//***************Solution********************
public class Solution {
    public int WaysToSplit(int[] nums) {
        const int MOD = (int) (1e9 + 7);
        int N = nums.Length,  res = 0;

        // prefix array
        int[] A = new int[N];
        A[0] = nums[0];

        for (int i = 1; i < N; ++i) 
            A[i] = A[i - 1] + nums[i];

        for (int i = 1; i < N - 1; ++i) {
            if (A[i - 1] > (A[N - 1] - A[i - 1]) / 2) 
                break;  // early termination

            int left = Helper(A, A[i - 1], i, true);
            int right = Helper(A, A[i - 1], i, false);

            if (left == -1 || right == -1) 
                continue;  // none is satisfied
            res = (res + (right - left + 1) % MOD) % MOD;
        }
        return res;
        }

        private int Helper(int[] A, int leftSum, int index, bool searchLeft) {
            int N = A.Length, l = index, r = N - 2, res = -1;

            while (l <= r) {
                //find mid index
                int m = (r - l) / 2 + l;
                int midSum = A[m] - A[index - 1];
                int rightSum = A[N - 1] - A[m];

                if (leftSum <= midSum && midSum <= rightSum) {
                    res = m;
                    if (searchLeft) r = m - 1;
                    else l = m + 1;
                }
                else if (leftSum > midSum) // shrink left
                    l = m + 1;
                else // shrink right
                    r = m - 1;

            }
            return res;
        }
}
