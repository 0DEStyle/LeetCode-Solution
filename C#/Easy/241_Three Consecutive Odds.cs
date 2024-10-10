/*Challenge link:https://leetcode.com/problems/three-consecutive-odds/description/
Question:
Given an integer array arr, return true if there are three consecutive odd numbers in the array. Otherwise, return false.
 

Example 1:

Input: arr = [2,6,4,1]
Output: false
Explanation: There are no three consecutive odds.
Example 2:

Input: arr = [1,2,34,3,4,5,7,23,12]
Output: true
Explanation: [5,7,23] are three consecutive odds.
 

Constraints:

1 <= arr.length <= 1000
1 <= arr[i] <= 1000
*/

//***************Solution********************
public class Solution {
    public bool ThreeConsecutiveOdds(int[] arr) {
        int window = 0;
        
        //first 3, mod 2 to get 1, if odd
        for (int i = 0; i < 3 && i < arr.Length; i++) 
            window += arr[i] % 2;

        //check if count is 3, return true
        if (window == 3) 
            return true;


        //3 until the end
        //accumulate window by mod current element to 2
        //decrease window by mod i - 3 element by 2
        //if window has 3 odd, return true.
        for (int i = 3; i < arr.Length; i++) {
            window += arr[i] % 2;
            window -= arr[i - 3] % 2;
            if (window == 3) 
                return true;
        }
        //no 3 consecutive odds.
        return false;
    }
}
