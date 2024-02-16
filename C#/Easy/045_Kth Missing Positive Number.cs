/*Challenge link:https://leetcode.com/problems/kth-missing-positive-number/description/
Question:
Given an array arr of positive integers sorted in a strictly increasing order, and an integer k.

Return the kth positive integer that is missing from this array.

 

Example 1:

Input: arr = [2,3,4,7,11], k = 5
Output: 9
Explanation: The missing positive integers are [1,5,6,8,9,10,12,13,...]. The 5th missing positive integer is 9.
Example 2:

Input: arr = [1,2,3,4], k = 2
Output: 6
Explanation: The missing positive integers are [5,6,7,...]. The 2nd missing positive integer is 6.
 

Constraints:

1 <= arr.length <= 1000
1 <= arr[i] <= 1000
1 <= k <= 1000
arr[i] < arr[j] for 1 <= i < j <= arr.length
 

Follow up:

Could you solve this problem in less than O(n) complexity?


*/

//***************Solution********************
public class Solution {
    public int FindKthPositive(int[] arr, int k) {
        //set left most and right most index
        var left = 0;
        var right = arr.Length - 1;

        //loop while left is less than or equal to right
        while(left <= right){
            //find the mid index between right and left
            var mid = left + (right - left) / 2;

            //if mid index - mid - 1 is less than k, set left to mid +1
            //else set right to mid -1;
            if(arr[mid] - mid - 1 < k) left = mid + 1;
            else right = mid - 1;
        }
        //return left index + k = the value of missing number
        return left + k;
    }
}


//****************Sample Test*****************
