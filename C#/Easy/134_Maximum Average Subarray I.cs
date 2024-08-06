/*Challenge link:https://leetcode.com/problems/maximum-average-subarray-i/description/
Question:
You are given an integer array nums consisting of n elements, and an integer k.

Find a contiguous subarray whose length is equal to k that has the maximum average value and return this value. Any answer with a calculation error less than 10-5 will be accepted.

 

Example 1:

Input: nums = [1,12,-5,-6,50,3], k = 4
Output: 12.75000
Explanation: Maximum average is (12 - 5 - 6 + 50) / 4 = 51 / 4 = 12.75
Example 2:

Input: nums = [5], k = 1
Output: 5.00000
 

Constraints:

n == nums.length
1 <= k <= n <= 105
-104 <= nums[i] <= 104
*/

//***************Solution********************
//max average at length k
public class Solution {
    public double FindMaxAverage(int[] nums, int k) {
        double sum = 0, avg = 0;
        
        //loop through k, accumulate sum for each element at nums
        for(int i = 0; i < k; i++) 
            sum += nums[i];
        
        //get average from sum
        avg = sum / k;

        //from k loop until nums.length
        //accumulate sum
        //if avg is less than sum/k
        //update avg
        for(int i = k; i < nums.Length; i++){               
                sum += nums[i] - nums [i - k];
                if(avg < sum / k) 
                    avg = sum / k;
        }
        return avg;
    }
}
