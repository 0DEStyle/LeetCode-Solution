/*Challenge link:https://leetcode.com/problems/count-the-number-of-fair-pairs/description/
Question:
Given a 0-indexed integer array nums of size n and two integers lower and upper, return the number of fair pairs.

A pair (i, j) is fair if:

0 <= i < j < n, and
lower <= nums[i] + nums[j] <= upper
 

Example 1:

Input: nums = [0,1,7,4,4,5], lower = 3, upper = 6
Output: 6
Explanation: There are 6 fair pairs: (0,3), (0,4), (0,5), (1,3), (1,4), and (1,5).
Example 2:

Input: nums = [1,7,9,2,5], lower = 11, upper = 11
Output: 1
Explanation: There is a single fair pair: (2,3).
 

Constraints:

1 <= nums.length <= 105
nums.length == n
-109 <= nums[i] <= 109
-109 <= lower <= upper <= 109
*/

//***************Solution********************public class Solution {
     public long CountFairPairs(int[] nums, int lower, int upper){
        var result = 0L;
        //sort array in ascending order
        Array.Sort(nums);

        for (var i = 0; i < nums.Length; i++){
            var j_beg = FindIndex(nums, i, num => num + nums[i] >= lower);
            var j_end = FindIndex(nums, i, num => num + nums[i] > upper);
            result += j_end - j_beg;
        }
        return result;
    }

    public int FindIndex(int[] nums, int i, Predicate<int> predicate){
        var left = i + 1;
        var right = nums.Length;

        while (left < right){
            //find mid index
            var mid = left + (right - left) / 2;

            if (predicate(nums[mid]))
                right = mid;
            else
                left = mid + 1;
        }
        return left;
    }
}
