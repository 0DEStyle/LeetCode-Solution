/*Challenge link:https://leetcode.com/problems/largest-perimeter-triangle/description/
Question:
Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

 

Example 1:

Input: nums = [2,1,2]
Output: 5
Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
Example 2:

Input: nums = [1,2,1,10]
Output: 0
Explanation: 
You cannot use the side lengths 1, 1, and 2 to form a triangle.
You cannot use the side lengths 1, 1, and 10 to form a triangle.
You cannot use the side lengths 1, 2, and 10 to form a triangle.
As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.
 

Constraints:

3 <= nums.length <= 104
1 <= nums[i] <= 106
*/

//***************Solution********************
public class Solution {
    public int LargestPerimeter(int[] nums) {
        //less than 3 number, return 0
         if (nums.Length < 3)
            return 0;
        //sort ascendingly
        Array.Sort(nums);

        //loop from end down to 2,
        //if next element + 2nd next element is greater than current element
        //return the sum.
        for(int i=nums.Length-1; i>=2; i--)
            if (nums[i-1] + nums[i-2] > nums[i])
                return nums[i-1] + nums[i-2] + nums[i] ;

        //no match
        return 0;
    }
}
