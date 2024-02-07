/*Challenge link:https://leetcode.com/problems/the-k-weakest-rows-in-a-matrix/description/
Question:
You are given an m x n binary matrix mat of 1's (representing soldiers) and 0's (representing civilians). The soldiers are positioned in front of the civilians. That is, all the 1's will appear to the left of all the 0's in each row.

A row i is weaker than a row j if one of the following is true:

The number of soldiers in row i is less than the number of soldiers in row j.
Both rows have the same number of soldiers and i < j.
Return the indices of the k weakest rows in the matrix ordered from weakest to strongest.

 

Example 1:

Input: mat = 
[[1,1,0,0,0],
 [1,1,1,1,0],
 [1,0,0,0,0],
 [1,1,0,0,0],
 [1,1,1,1,1]], 
k = 3
Output: [2,0,3]
Explanation: 
The number of soldiers in each row is: 
- Row 0: 2 
- Row 1: 4 
- Row 2: 1 
- Row 3: 2 
- Row 4: 5 
The rows ordered from weakest to strongest are [2,0,3,1,4].
Example 2:

Input: mat = 
[[1,0,0,0],
 [1,1,1,1],
 [1,0,0,0],
 [1,0,0,0]], 
k = 2
Output: [0,2]
Explanation: 
The number of soldiers in each row is: 
- Row 0: 1 
- Row 1: 4 
- Row 2: 1 
- Row 3: 1 
The rows ordered from weakest to strongest are [0,2,3,1].
 

Constraints:

m == mat.length
n == mat[i].length
2 <= n, m <= 100
1 <= k <= m
matrix[i][j] is either 0 or 1.
*/

//***************Solution********************
public class Solution {
    public int[] KWeakestRows(int[][] mat, int k) {
    Dictionary<int, int> res = new();

    //loop through each element and check if current cell is i, if so add it to counter, else break
    //at the end, add i and counter into res dictionary
    for(int i = 0; i < mat.Length; i++){
        int counter = 0;
        for(int j = 0; j < mat[i].Length; j++){
            if(mat[i][j] == 1) counter++;
            else break;
        }
        res.Add(i, counter);
    }

    //order the dictionary by value, then store key and value back into res
    //take the first k elements, select the keys, store as array and return the result.
    res = res.OrderBy(x => x.Value).ToDictionary(a => a.Key, b => b.Value);
    return res.Take(k).Select(x => x.Key).ToArray();
    }
}

//solution 2 oneliner Linq
public class Solution {
    public int[] KWeakestRows(int[][] mat, int k) => 
        mat.Select((row, i) => (row.Count(el => el == 1), i))
            .OrderBy(x => x.Item1)
            .ThenBy(x => x.Item2)
            .Take(k)
            .Select(x => x.Item2)
            .ToArray();
}
