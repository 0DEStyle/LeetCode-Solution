/*Challenge link:https://leetcode.com/problems/check-if-every-row-and-column-contains-all-numbers/description/
Question:
An n x n matrix is valid if every row and every column contains all the integers from 1 to n (inclusive).

Given an n x n integer matrix matrix, return true if the matrix is valid. Otherwise, return false.

 

Example 1:
//see image in link

Input: matrix = [[1,2,3],[3,1,2],[2,3,1]]
Output: true
Explanation: In this case, n = 3, and every row and column contains the numbers 1, 2, and 3.
Hence, we return true.
Example 2:
//see image in link


Input: matrix = [[1,1,1],[1,2,3],[1,2,3]]
Output: false
Explanation: In this case, n = 3, but the first row and the first column do not contain the numbers 2 or 3.
Hence, we return false.
 

Constraints:

n == matrix.length == matrix[i].length
1 <= n <= 100
1 <= matrix[i][j] <= n
*/

//***************Solution********************
public class Solution {
    public bool CheckValid(int[][] m) {
        if(m == null || m.Length == 0)
            throw new ArgumentException("Invalid Input.");
        
        int n = m.Length;
        
        //iterate through matrix column
        for(int i = 0; i < n; i++){
            //row and column
            var r = new HashSet<int>();
            var c = new HashSet<int>();
            
            //iterate through matrix row
            for(int j = 0; j < n; j++){
                if(m[i][j] < 1 || m[i][j] > n)
                    return false;
                
                r.Add(m[i][j]); // populate i-th row
                c.Add(m[j][i]); // populate i-th column
            }
            
            //either row or column's count less then matrix's length
            if(r.Count < n || c.Count < n)
                return false;
        }
        return true;
    }
}
