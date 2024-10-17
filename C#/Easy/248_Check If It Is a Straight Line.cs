/*Challenge link:https://leetcode.com/problems/check-if-it-is-a-straight-line/description/
Question:
You are given an array coordinates, coordinates[i] = [x, y], where [x, y] represents the coordinate of a point. Check if these points make a straight line in the XY plane.

 

 

Example 1:
//see image in link


Input: coordinates = [[1,2],[2,3],[3,4],[4,5],[5,6],[6,7]]
Output: true
Example 2:
//see image in link


Input: coordinates = [[1,1],[2,2],[3,4],[4,5],[5,6],[7,7]]
Output: false
 

Constraints:

2 <= coordinates.length <= 1000
coordinates[i].length == 2
-10^4 <= coordinates[i][0], coordinates[i][1] <= 10^4
coordinates contains no duplicate point.
*/

//***************Solution********************
//check gradient

public class Solution {
    public bool CheckStraightLine(int[][] c) {
        //if only 2 points, it's a straight line
        if(c.Length==2)
            return true;

        //loop through c.legnth -2
        //y - y1 = m(x - x1)
        //rearrange
        //l = (y3 - y1) - (x2 - x1)
        //r = (y2 - y1) - (x3 - x1)
        for (int i = 0; i < c.Length-2; i++){
                int l = (c[i+2][1] -c[i][1]) * (c[i+1][0] - c[i][0]),
                    r = (c[i+1][1] - c[i][1]) * (c[i+2][0] -c[i][0]);

                if (l != r) 
                    return false;
            }
        return true;
    }
}
