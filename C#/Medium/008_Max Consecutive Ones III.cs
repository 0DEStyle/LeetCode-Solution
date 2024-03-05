/*Challenge link:https://leetcode.com/problems/max-consecutive-ones-iii/description/
Question:
Given a binary array nums and an integer k, return the maximum number of consecutive 1's in the array if you can flip at most k 0's.

 

Example 1:

Input: nums = [1,1,1,0,0,0,1,1,1,1,0], k = 2
Output: 6
Explanation: [1,1,1,0,0,1,1,1,1,1,1]
Bolded numbers were flipped from 0 to 1. The longest subarray is underlined.
Example 2:

Input: nums = [0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1], k = 3
Output: 10
Explanation: [0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,1,1,1,1]
Bolded numbers were flipped from 0 to 1. The longest subarray is underlined.
 

Constraints:

1 <= nums.length <= 105
nums[i] is either 0 or 1.
0 <= k <= nums.length
*/

//***************Solution********************
//sliding window O(n)
public class Solution {
    public int LongestOnes(int[] nums, int k) {
        //two pointers, left and right pointer to create a window
        int left = 0, count = 0, ans = 0; 

        //loop through each element, i is right pointer
        for(int i = 0; i < nums.Length; i++){
            //if current index is 0, count + 1
            if(nums[i] == 0) count++;

            //while when count doesn't exceed k, 
            //if current element is 0, reduce count by 1, else increase left by 1(the acutal result)
            while(count > k){
                if(nums[left] == 0) count--;
                left++;
            }
            //select max value between current ans and current window's length
            //i - left + 1 =>  right - left + 1
            ans = Math.Max(ans, i - left + 1);
        }
        return ans; 
    }
}

//sliding window  + binary search
public class Solution {
    public bool checkValid(int[] nums, int windowSize, int k){
        //2 pointers, i is right, j is left, zero count and one count
        int i = 0, j = 0, ans = 0, zCount = 0, oCount = 0;

        //loop through each number while not exceeding nums' length
        while(j < nums.Length) {
            //increase either zero or one's count
            if(nums[j] == 0) zCount++;
            else oCount++;

            //matches windowSize, then reduce count
            if((j - i + 1) == windowSize) {
                int temp = oCount + Math.Min(zCount, k);
                ans = Math.Max(ans, temp);

                //reduce count of either zero or one by 1 if matched
                if (nums[i] == 0) zCount--;
                else if (nums[i] == 1) oCount--;

                //shift to right by 1
                i++;
            }
            // early return. little optimization, then shift to left point to right by 1
            if(ans == windowSize) return true; 
            j++;
        }
        //return the bool value to see if ans is the same as windowSize
        return ans == windowSize;
    }

    public int LongestOnes(int[] nums, int k) {
        int low = 0, high = nums.Length, ans = 0;

        while(low <= high) {
            //find mid index of windowSize
            int mid = low + (high - low) / 2;

            //check if window is valid, if so set mid as current ans, shift mid to the right, else shift to left
            if(checkValid(nums, mid, k)) {
                ans = mid;
                low = mid + 1;
            } 
            else 
                high = mid - 1;
        }
		return ans;
    }
}
