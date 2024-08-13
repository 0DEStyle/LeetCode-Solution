/*Challenge link:https://leetcode.com/problems/largest-triangle-area/description/
Question:
Given an array of points on the X-Y plane points where points[i] = [xi, yi], return the area of the largest triangle that can be formed by any three different points. Answers within 10-5 of the actual answer will be accepted.

 

Example 1:
//see image in link

Input: points = [[0,0],[0,1],[1,0],[0,2],[2,0]]
Output: 2.00000
Explanation: The five points are shown in the above figure. The red triangle is the largest.
Example 2:

Input: points = [[1,0],[0,0],[0,1]]
Output: 0.50000
 

Constraints:

3 <= points.length <= 50
-50 <= xi, yi <= 50
All the given points are unique.
*/

//***************Solution********************
public class Solution {
    public double LargestTriangleArea(int[][] p) {
        var n = p.Length;
        var max = 0.0;

        for(int x = 0; x < n - 2; x++)
            for(int y = x + 1; y < n - 1; y++)
                for(int z = y + 1; z < n; z++)
                    max = Math.Max(max, 0.5 * Math.Abs(p[x][0] * 
                            (p[y][1] - p[z][1]) + p[y][0] * 
                            (p[z][1] - p[x][1]) + p[z][0] * 
                            (p[x][1] - p[y][1])));

        return max;
    }
}
