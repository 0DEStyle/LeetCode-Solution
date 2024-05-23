/*Challenge link:https://leetcode.com/problems/maximum-points-inside-the-square/description/
Question:
You are given a 2D array points and a string s where, points[i] represents the coordinates of point i, and s[i] represents the tag of point i.

A valid square is a square centered at the origin (0, 0), has edges parallel to the axes, and does not contain two points with the same tag.

Return the maximum number of points contained in a valid square.

Note:

A point is considered to be inside the square if it lies on or within the square's boundaries.
The side length of the square can be zero.
 

Example 1:
//see image in link


Input: points = [[2,2],[-1,-2],[-4,4],[-3,1],[3,-3]], s = "abdca"

Output: 2

Explanation:

The square of side length 4 covers two points points[0] and points[1].

Example 2:
//see image in link


Input: points = [[1,1],[-2,-2],[-2,2]], s = "abb"

Output: 1

Explanation:

The square of side length 2 covers one point, which is points[0].

Example 3:
//see image in link
Input: points = [[1,1],[-1,-1],[2,-2]], s = "ccd"

Output: 0

Explanation:

It's impossible to make any valid squares centered at the origin such that it covers only one point among points[0] and points[1].

 

Constraints:

1 <= s.length, points.length <= 105
points[i].length == 2
-109 <= points[i][0], points[i][1] <= 109
s.length == points.length
points consists of distinct coordinates.
s consists only of lowercase English letters.
*/

//***************Solution********************

public class Solution {

    //helper method
    //return bool value: current point[0] and point[1] are less than or equal to res
    public bool check(int[][] points, int i, int res) => points[i][0] <= res && points[i][1] <= res;

    public int MaxPointsInsideSquare(int[][] points, string s) {
        //set boundaries
        int n = points.Length, left = 0, right = (int)1e9, res = 0;

        //change all values of points to its absolute value
        for (int i = 0; i < n; ++i){
            points[i][0] = Math.Abs(points[i][0]);
            points[i][1] = Math.Abs(points[i][1]);
        }

        while (left <= right){
            //find mid index
            int mid = left + (right - left) / 2;
            Dictionary<char, int> temp = new Dictionary<char, int>();
            bool flag = true;

            //loop through points.length
            for (int i = 0; i < n; ++i){
                //if current point[0] and point[1] are both less than or equal to mid
                //if temp contains key of s[i](the character), increase temp at s[i] by 1
                //else set temp at s[i] to 1
                if (points[i][0] <= mid && points[i][1] <= mid){
                    if (temp.ContainsKey(s[i]))
                        temp[s[i]]++;
                    else
                        temp[s[i]] = 1;
                }
            }

            //loop through all val in temp.Values
            //if val is greater than 1, set flag to false.
            //if flag is true, set res to mid, and shift left to right by 1 index
            //else shift right to left by 1 index.
            foreach (var val in temp.Values){
                if (val > 1){
                    flag = false;
                    break;
                }
            }
            if (flag){
                res = mid;
                left = mid + 1;
            }
            else
                right = mid - 1;
        }

        int ans = 0;
        //loop through point.length
        //pass variables into check, if condition is true, increase ans by 1.
        for (int i = 0; i < n; ++i){
            if (check(points, i, res))
                ans++;
        }
        return ans;
    }
}
