/*Challenge link:https://leetcode.com/problems/two-sum/
Question:
Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

You can return the answer in any order.

 

Example 1:

Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
Example 2:

Input: nums = [3,2,4], target = 6
Output: [1,2]
Example 3:

Input: nums = [3,3], target = 6
Output: [0,1]
 

Constraints:

2 <= nums.length <= 104
-109 <= nums[i] <= 109
-109 <= target <= 109
Only one valid answer exists.
 

Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?
*/

//***************Solution********************

//x is current element, i is index
//array.IndexOf: public static int IndexOf (Array array, object? value, int startIndex);
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;

public class Solution {
    public int[] TwoSum(int[] nums, int target) => 
    nums.Select((x,i) => new [] {i, Array.IndexOf(nums, target - x, i + 1)}).First(x => x[1] != -1);
} 

//solution 2
using System;
using System.Linq;
using System.Collections.Generic;

public class Solution {
    public int[] TwoSum(int[] nums, int target){
        Dictionary<int, int> res = new();
        if(nums == null || nums.Length <2) 
            return Array.Empty<int>();
        for(int i = 0; i< nums.Length; i++){
            int nextNum = target - nums[i];
            if(res.TryGetValue(nextNum, out int index))
                return new[]{index, i};
            res[nums[i]] = i;
        }
        return Array.Empty<int>();
        }
}
