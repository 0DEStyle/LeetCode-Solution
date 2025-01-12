/*Challenge link:https://leetcode.com/problems/sum-of-unique-elements/description/
Question:
You are given an integer array nums. The unique elements of an array are the elements that appear exactly once in the array.

Return the sum of all the unique elements of nums.

 

Example 1:

Input: nums = [1,2,3,2]
Output: 4
Explanation: The unique elements are [1,3], and the sum is 4.
Example 2:

Input: nums = [1,1,1,1,1]
Output: 0
Explanation: There are no unique elements, and the sum is 0.
Example 3:

Input: nums = [1,2,3,4,5]
Output: 15
Explanation: The unique elements are [1,2,3,4,5], and the sum is 15.
 

Constraints:

1 <= nums.length <= 100
1 <= nums[i] <= 100
*/

//***************Solution********************

public class Solution {
    public int SumOfUnique(int[] nums) {
        //length cap 100
        var check = new int[101];
        int sum=0;

        //loop through each number
        foreach(int num in nums){
            check[num]++;
            //if current num is equal to 1, accumulate sum
            //else if num is equal to 2, remove from sum.
            if(check[num] == 1) 
                sum += num;
            else if (check[num] == 2) 
                sum -= num;
        }
        return sum;
    }
}
