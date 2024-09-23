/*Challenge link:https://leetcode.com/problems/duplicate-zeros/description/
Question:
Given a fixed-length integer array arr, duplicate each occurrence of zero, shifting the remaining elements to the right.

Note that elements beyond the length of the original array are not written. Do the above modifications to the input array in place and do not return anything.

 

Example 1:

Input: arr = [1,0,2,3,0,4,5,0]
Output: [1,0,0,2,3,0,0,4]
Explanation: After calling your function, the input array is modified to: [1,0,0,2,3,0,0,4]
Example 2:

Input: arr = [1,2,3]
Output: [1,2,3]
Explanation: After calling your function, the input array is modified to: [1,2,3]
 

Constraints:

1 <= arr.length <= 104
0 <= arr[i] <= 9
*/

//***************Solution********************
public class Solution {
    public void DuplicateZeros(int[] arr) {
        int zeros = 0, length = arr.Length;
        
        //loop through arr length
        //if current element of arr is 0, increase zeros by 1
        for (int i = 0; i < length; i++)
            if (arr[i] == 0)
                zeros++;

        //loop through arr length down to 0
        //if i + zero is less than length
        //set arr at index i + zero to current element, (checking match index then shift)
        for (int i = length - 1; i >= 0; i--){
            if (i + zeros < length)
                arr[i + zeros] = arr[i];
            //if current element is 0, reduce zeros by 1
            if (arr[i] == 0){
                zeros--;

            //if i + zero is less than length
            //set arr at index i + zero to 0 (Duplicate Zeros)
            if (i + zeros < length)
                arr[i + zeros] = 0;
            }
    }
}
}
