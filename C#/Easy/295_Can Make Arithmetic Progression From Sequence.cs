/*Challenge link:https://leetcode.com/problems/can-make-arithmetic-progression-from-sequence/description/
Question:
A sequence of numbers is called an arithmetic progression if the difference between any two consecutive elements is the same.

Given an array of numbers arr, return true if the array can be rearranged to form an arithmetic progression. Otherwise, return false.

 

Example 1:

Input: arr = [3,5,1]
Output: true
Explanation: We can reorder the elements as [1,3,5] or [5,3,1] with differences 2 and -2 respectively, between each consecutive elements.
Example 2:

Input: arr = [1,2,4]
Output: false
Explanation: There is no way to reorder the elements to obtain an arithmetic progression.
 

Constraints:

2 <= arr.length <= 1000
-106 <= arr[i] <= 106
*/

//***************Solution********************
public class Solution {
    public bool CanMakeArithmeticProgression(int[] a) {
        //sort in ascending order
        Array.Sort(a);
        //from 2 count a.length -2
        //i is current element
        //check the difference between 2nd and 1st elements is equal diff of current and last element
        //get all bool values, and return true is all true.
        return Enumerable.Range(2, a.Length - 2)
                         .All(i => a[1] - a[0] == a[i] - a[i - 1]);
    }
}
