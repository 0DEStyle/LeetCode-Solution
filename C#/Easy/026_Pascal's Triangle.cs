/*Challenge link:https://leetcode.com/problems/pascals-triangle/description/
Question:
Given an integer numRows, return the first numRows of Pascal's triangle.

In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:


 //see image

Example 1:

Input: numRows = 5
Output: [[1],[1,1],[1,2,1],[1,3,3,1],[1,4,6,4,1]]
Example 2:

Input: numRows = 1
Output: [[1]]
 

Constraints:

1 <= numRows <= 30
*/

//***************Solution********************
class Solution {
    public IList<IList<int>> Generate(int n) {

        var numList  = new List<IList<int>>();
        if (n == 0) return numList;
        numList.Add(new List<int>() { 1 });

        for (int i = 1; i < n; i++) {
            //create new row, temp is the previous row
            var temp = (List<int>)numList[i - 1];
            var newRow = new List<int> { 1 };

            //set current row to the sum of two numbers above it from the previous row
            for (int j = 1; j < temp.Count; j++) 
                newRow.Add(temp[j - 1] + temp[j]);

            //add 1 to newRow, add newRow into numList
            newRow.Add(1);
            numList.Add(newRow);
        }
        return numList;
    }
}
