/*Challenge link:https://leetcode.com/problems/find-lucky-integer-in-an-array/description/
Question:
Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.

Return the largest lucky integer in the array. If there is no lucky integer return -1.

 

Example 1:

Input: arr = [2,2,3,4]
Output: 2
Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
Example 2:

Input: arr = [1,2,2,3,3,3]
Output: 3
Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.
Example 3:

Input: arr = [2,2,2,3,3]
Output: -1
Explanation: There are no lucky numbers in the array.
 

Constraints:

1 <= arr.length <= 500
1 <= arr[i] <= 500
*/

//***************Solution********************
//lucky num =>  frequency in the array  = value.

public class Solution {
    public int FindLucky(int[] arr) {
        //limit is 500
        int[] nums = new int[501];
        
        //count j in index nums.
        foreach(int j in arr) 
			nums[j]++; 
        
        //loop through 500, if match, return i, else -1
        for (int i = 500; i > 0; i--) 
			if (i == nums[i]) 
                return i; 

        return -1;
    }
}
