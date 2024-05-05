/*Challenge link:https://leetcode.com/problems/k-diff-pairs-in-an-array/description/
Question:
Given an array of integers nums and an integer k, return the number of unique k-diff pairs in the array.

A k-diff pair is an integer pair (nums[i], nums[j]), where the following are true:

0 <= i, j < nums.length
i != j
|nums[i] - nums[j]| == k
Notice that |val| denotes the absolute value of val.

 

Example 1:

Input: nums = [3,1,4,1,5], k = 2
Output: 2
Explanation: There are two 2-diff pairs in the array, (1, 3) and (3, 5).
Although we have two 1s in the input, we should only return the number of unique pairs.
Example 2:

Input: nums = [1,2,3,4,5], k = 1
Output: 4
Explanation: There are four 1-diff pairs in the array, (1, 2), (2, 3), (3, 4) and (4, 5).
Example 3:

Input: nums = [1,3,1,5,4], k = 0
Output: 1
Explanation: There is one 0-diff pair in the array, (1, 1).
 

Constraints:

1 <= nums.length <= 104
-107 <= nums[i] <= 107
0 <= k <= 107
*/

//***************Solution********************
//binary search
public class Solution {
    public int FindPairs(int[] nums, int k) {
        //create int hashset
        //sort num array in ascending order
        var uniquePair = new HashSet<int>();
        Array.Sort(nums);
        int n = nums.Length;

        //loop through num.length -1
        //do binary search on ()array nums, starting value, range, comparer)
        //BinarySearch(Array, Int32, Int32, Object, IComparer)
        //https://learn.microsoft.com/en-us/dotnet/api/system.array.binarysearch?view=net-8.0
        //if true, add current index of nums into uniquePair.
        for (int i = 0; i < n - 1; i++){
            if (Array.BinarySearch(nums, i + 1, n - i - 1, nums[i] + k) >= 0)
                uniquePair.Add(nums[i]);
        }
        return uniquePair.Count;
    }
}

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
