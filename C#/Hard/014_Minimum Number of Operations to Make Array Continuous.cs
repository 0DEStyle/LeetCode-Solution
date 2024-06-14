/*Challenge link:https://leetcode.com/problems/minimum-number-of-operations-to-make-array-continuous/description/
Question:
You are given an integer array nums. In one operation, you can replace any element in nums with any integer.

nums is considered continuous if both of the following conditions are fulfilled:

All elements in nums are unique.
The difference between the maximum element and the minimum element in nums equals nums.length - 1.
For example, nums = [4, 2, 5, 3] is continuous, but nums = [1, 2, 3, 5, 6] is not continuous.

Return the minimum number of operations to make nums continuous.

 

Example 1:

Input: nums = [4,2,5,3]
Output: 0
Explanation: nums is already continuous.
Example 2:

Input: nums = [1,2,3,5,6]
Output: 1
Explanation: One possible solution is to change the last element to 4.
The resulting array is [1,2,3,5,4], which is continuous.
Example 3:

Input: nums = [1,10,100,1000]
Output: 3
Explanation: One possible solution is to:
- Change the second element to 2.
- Change the third element to 3.
- Change the fourth element to 4.
The resulting array is [1,2,3,4], which is continuous.
 

Constraints:

1 <= nums.length <= 105
1 <= nums[i] <= 109
*/

//***************Solution********************
public class Solution {
    public int MinOperations(int[] nums) {
        //sort array in ascending order
        Array.Sort(nums);
        var list = new List<int>();
        
        //loop through num length
        //if i is less than 0 or current num is equal to last num, continue
        //add current num to list.
        for (int i = 0; i < nums.Length; i++){
            if (i > 0 && nums[i] == nums[i - 1])
                continue;
            list.Add(nums[i]);
        }

        int max = 0;
        
        for (int i = 0; i < list.Count; i++){
            //set current target to current element in list + num.length - 1
            //apply binary search to find index
            int target = list[i] + nums.Length - 1, index = list.BinarySearch(target);
            
            //if index is less than 0, bit wise complement and subtract 1
            if (index < 0)
                index = (~index) - 1;
            
            //select max value between max and index - i + 1, update max for next iteration
            max = Math.Max(max, index - i + 1);
        }
        //return difference between length - max
        return nums.Length - max;
}}
