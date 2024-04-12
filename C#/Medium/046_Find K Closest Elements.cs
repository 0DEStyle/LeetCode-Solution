/*Challenge link:https://leetcode.com/problems/find-k-closest-elements/description/
Question:
Given a sorted integer array arr, two integers k and x, return the k closest integers to x in the array. The result should also be sorted in ascending order.

An integer a is closer to x than an integer b if:

|a - x| < |b - x|, or
|a - x| == |b - x| and a < b
 

Example 1:

Input: arr = [1,2,3,4,5], k = 4, x = 3
Output: [1,2,3,4]
Example 2:

Input: arr = [1,2,3,4,5], k = 4, x = -1
Output: [1,2,3,4]
 

Constraints:

1 <= k <= arr.length
1 <= arr.length <= 104
arr is sorted in ascending order.
-104 <= arr[i], x <= 104
*/

//***************Solution********************
//binary search
public class Solution {
    public IList<int> FindClosestElements(int[] arr, int k, int x) {
        //set boundaries
         int low = 0, high = arr.Length - k;
         var res = new List<int>(k);

        while (low < high) {
            //find mid index
            int midpoint = low + (high - low) / 2; 

            //check condition, 
            //if true shift low to right by 1 index
            //else shift high to left by 1 index 
            if (x - arr[midpoint] > arr[midpoint + k] - x) 
                low = midpoint + 1;
            else
                high = midpoint;
        }
        //add results to list.
        for (int i = low; i < low + k; i++)
            res.Add(arr[i]);
        return res;
    }
}
