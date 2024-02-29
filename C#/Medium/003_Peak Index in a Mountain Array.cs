/*Challenge link:https://leetcode.com/problems/peak-index-in-a-mountain-array/description/
Question:
An array arr is a mountain if the following properties hold:

arr.length >= 3
There exists some i with 0 < i < arr.length - 1 such that:
arr[0] < arr[1] < ... < arr[i - 1] < arr[i] 
arr[i] > arr[i + 1] > ... > arr[arr.length - 1]
Given a mountain array arr, return the index i such that arr[0] < arr[1] < ... < arr[i - 1] < arr[i] > arr[i + 1] > ... > arr[arr.length - 1].

You must solve it in O(log(arr.length)) time complexity.

 

Example 1:

Input: arr = [0,1,0]
Output: 1
Example 2:

Input: arr = [0,2,1,0]
Output: 1
Example 3:

Input: arr = [0,10,5,2]
Output: 1
 

Constraints:

3 <= arr.length <= 105
0 <= arr[i] <= 106
arr is guaranteed to be a mountain array.
*/

//***************Solution********************
//binary search method
public class Solution {
    public int PeakIndexInMountainArray(int[] arr) {
        //set start and end
         int low = 0, high = arr.Length-1, mid = 0;

        while(low <= high){
            //get mid index
            mid = low + (high - low) /2;

            //if mid is 0 or arr[mid] is less than previous and next index, return peek index
            //else shift index by 1 either to left or right and continue the search
            if((mid == 0 || arr[mid] > arr[mid-1]) && arr[mid] > arr[mid+1])
                return mid;
            else if((mid == 0 || arr[mid] > arr[mid - 1]) && arr[mid] < arr[mid+1])
                low = mid + 1;
            else 
                high = mid - 1;
        }
        //return mid index
        return mid;
    }
}
