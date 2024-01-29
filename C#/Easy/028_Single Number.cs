/*Challenge link:https://leetcode.com/problems/single-number/
Question:
Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.

You must implement a solution with a linear runtime complexity and use only constant extra space.

 

Example 1:

Input: nums = [2,2,1]
Output: 1
Example 2:

Input: nums = [4,1,2,1,2]
Output: 4
Example 3:

Input: nums = [1]
Output: 1
 

Constraints:

1 <= nums.length <= 3 * 104
-3 * 104 <= nums[i] <= 3 * 104
Each element in the array appears twice except for one element which appears only once.
*/

//***************Solution********************
//group each number, select number where count is 1, from it select the key and get the first element.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Solution {
    public int SingleNumber(int[] nums)  => nums.GroupBy(x => x).Where(x => x.Count() == 1).Select(x => x.Key).First();
}
