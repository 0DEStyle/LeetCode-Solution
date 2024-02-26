/*Challenge link:https://leetcode.com/problems/check-if-n-and-its-double-exist/description/
Question:
Given an array arr of integers, check if there exist two indices i and j such that :

i != j
0 <= i, j < arr.length
arr[i] == 2 * arr[j]
 

Example 1:

Input: arr = [10,2,5,3]
Output: true
Explanation: For i = 0 and j = 2, arr[i] == 10 == 2 * 5 == 2 * arr[j]
Example 2:

Input: arr = [3,1,7,11]
Output: false
Explanation: There is no i and j that satisfy the conditions.
 

Constraints:

2 <= arr.length <= 500
-103 <= arr[i] <= 103
*/

//***************Solution********************public class Solution {
//hashset solution
    public bool CheckIfExist(int[] arr) {
    //create hashset with size arr.Length
    var hash = new HashSet<int>(arr.Length);

    //loop through each element in arr, i is the curretn element
    //if i hash contains i * 2, or i mod 2 == 0 AND hash contains i / 2, 
    //because e.g. 7/2 = 3 not 3.5, so we need to check mod is 0
    //else add i into hash and move on
    foreach (var i in arr){
        if (hash.Contains(i * 2) || (i % 2 == 0 && hash.Contains(i / 2)))
            return true;
        hash.Add(i);
    }
    //no match
    return false;
    }
}

//binary search method
public class Solution {
    public bool CheckIfExist(int[] arr) {
    Array.Sort(arr);
        for(int i = 0; i < arr.Length; i++) {
            int low = 0;
            int high = arr.Length - 1;
            int target = 2 * arr[i];

            while(low <= high) {
                int mid = low + (high - low)/2;
                //check condition and return true, else shift index to either left or right
                if(arr[mid] == target && i != mid) return true;
                else if(arr[mid] < target) low = mid + 1;
                else high = mid - 1;
            }
        }
        return false;
    }
}
