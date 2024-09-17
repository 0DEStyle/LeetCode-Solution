/*Challenge link:https://leetcode.com/problems/valid-boomerang/description/
Question:
Given an array points where points[i] = [xi, yi] represents a point on the X-Y plane, return true if these points are a boomerang.

A boomerang is a set of three points that are all distinct and not in a straight line.

 

Example 1:

Input: points = [[1,1],[2,3],[3,2]]
Output: true
Example 2:

Input: points = [[1,1],[2,2],[3,3]]
Output: false
 

Constraints:

points.length == 3
points[i].length == 2
0 <= xi, yi <= 100
*/

//***************Solution********************
public class Solution {
    public bool IsBoomerang(int[][] p) {
        //get x and y for all 3 points
        int x1 = p[0][0], y1 = p[0][1],
            x2 = p[1][0], y2 = p[1][1],
            x3 = p[2][0], y3 = p[2][1];
        
        //check if gradient  is not the same, return a boool value
        //return (y1 * (x3 - x2) + y2 * (x1 - x3) + y3 * (x2 - x1)) != 0;
        return (y3 - y2) * (x2 - x1) != (y2 - y1) * (x3 - x2);
    }
}
