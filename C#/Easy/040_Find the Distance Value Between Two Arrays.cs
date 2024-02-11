/*Challenge link:https://leetcode.com/problems/find-the-distance-value-between-two-arrays/description/
Question:
Given two integer arrays arr1 and arr2, and the integer d, return the distance value between the two arrays.

The distance value is defined as the number of elements arr1[i] such that there is not any element arr2[j] where |arr1[i]-arr2[j]| <= d.

 

Example 1:

Input: arr1 = [4,5,8], arr2 = [10,9,1,8], d = 2
Output: 2
Explanation: 
For arr1[0]=4 we have: 
|4-10|=6 > d=2 
|4-9|=5 > d=2 
|4-1|=3 > d=2 
|4-8|=4 > d=2 
For arr1[1]=5 we have: 
|5-10|=5 > d=2 
|5-9|=4 > d=2 
|5-1|=4 > d=2 
|5-8|=3 > d=2
For arr1[2]=8 we have:
|8-10|=2 <= d=2
|8-9|=1 <= d=2
|8-1|=7 > d=2
|8-8|=0 <= d=2
Example 2:

Input: arr1 = [1,4,2,3], arr2 = [-4,-3,6,10,20,30], d = 3
Output: 2
Example 3:

Input: arr1 = [2,1,100,3], arr2 = [-5,-2,10,-3,7], d = 6
Output: 1
 

Constraints:

1 <= arr1.length, arr2.length <= 500
-1000 <= arr1[i], arr2[j] <= 1000
0 <= d <= 100
*/

//***************Solution********************
//binary search
public class Solution {
     public int FindTheDistanceValue(int[] arr1, int[] arr2, int d) {
         //sort the array, for mid search
        Array.Sort(arr2);
        int count = 0;
        foreach (int x in arr1) {
            int i = ClosestBinarySearch(arr2, x);
            if (Math.Abs(x - arr2[i]) > d) count++;
        }
        return count;
    }
    
    //return index if condition met using arr2  and current element in arr1
    private int ClosestBinarySearch(int[] arr, int x) {
        //i is start, j is end 
        int i = 0;
        int j = arr.Length - 1;

        //while i is less than or equal to j
        //mid is ((j - i) / 2 )+ i
        //if mid is less than x, then set j to mid -1
        //if mid is greater than x, then set i to mid + 1
        //else return mid
        while (i <= j) {
            int mid = i + (j - i) / 2;
            if (arr[mid] > x) j = mid - 1;
            else if (arr[mid] < x) i = mid + 1;
            else return mid;
        }

        //if j is less than 1, return i
        //if i is equal to the arr.length return j
        if (j < 0) return i;
        if (i == arr.Length) return j;

        //if Math.Abs(arr[i] - x) < Math.Abs(arr[j] - x) , return i, else j
        return Math.Abs(arr[i] - x) < Math.Abs(arr[j] - x) ? i : j;
    }
}
