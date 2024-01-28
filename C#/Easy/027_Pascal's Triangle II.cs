/*Challenge link:https://leetcode.com/problems/pascals-triangle-ii/description/
Question:
Given an integer rowIndex, return the rowIndexth (0-indexed) row of the Pascal's triangle.

In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:


//see image in link 

Example 1:

Input: rowIndex = 3
Output: [1,3,3,1]
Example 2:

Input: rowIndex = 0
Output: [1]
Example 3:

Input: rowIndex = 1
Output: [1,1]
 

Constraints:

0 <= rowIndex <= 33
 

Follow up: Could you optimize your algorithm to use only O(rowIndex) extra space?
*/

//***************Solution********************
public class Solution {
    public IList<int> GetRow(int n) {
        var numList  = new List<int> {1};
        if (n == 0) return numList;
        //first number, set as long because test case will cause overflow
        long prev = 1;

        //start from 1, up to n
        //newVal is the number next to the prev.
        //apply formula to find newVal, store it into numList, 
        //and set prev to newVal for next iteration
        for (int i = 1; i <= n; i++) {
            long newVal = prev * (n - i + 1) / i;
            numList.Add((int)newVal);
            prev = newVal;
        }
        return numList;
    }
}
