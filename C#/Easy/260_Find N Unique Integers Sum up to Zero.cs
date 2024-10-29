/*Challenge link:https://leetcode.com/problems/find-n-unique-integers-sum-up-to-zero/description/
Question:
Given an integer n, return any array containing n unique integers such that they add up to 0.

 

Example 1:

Input: n = 5
Output: [-7,-1,1,3,4]
Explanation: These arrays also are accepted [-5,-1,1,2,3] , [-3,-1,2,-2,4].
Example 2:

Input: n = 3
Output: [-1,0,1]
Example 3:

Input: n = 1
Output: [0]
 

Constraints:

1 <= n <= 1000
*/

//***************Solution********************
public class Solution {
    public int[] SumZero(int n) {
        //create n size array
        var arr = new int[n];

        //while n is greater than 1
        //set v to arr at index n, then subtract 1
        //set -v to arr at index n, then subtract 1
        while (n > 1) {
            int v = n;
            arr[--n] = v;
            arr[--n] = -v;
        }
        return arr;
    }
}
