/*Challenge link:https://leetcode.com/problems/random-point-in-non-overlapping-rectangles/description/
Question:
You are given an array of non-overlapping axis-aligned rectangles rects where rects[i] = [ai, bi, xi, yi] indicates that (ai, bi) is the bottom-left corner point of the ith rectangle and (xi, yi) is the top-right corner point of the ith rectangle. Design an algorithm to pick a random integer point inside the space covered by one of the given rectangles. A point on the perimeter of a rectangle is included in the space covered by the rectangle.

Any integer point inside the space covered by one of the given rectangles should be equally likely to be returned.

Note that an integer point is a point that has integer coordinates.

Implement the Solution class:

Solution(int[][] rects) Initializes the object with the given rectangles rects.
int[] pick() Returns a random integer point [u, v] inside the space covered by one of the given rectangles.
 

Example 1:
//see image in link

Input
["Solution", "pick", "pick", "pick", "pick", "pick"]
[[[[-2, -2, 1, 1], [2, 2, 4, 6]]], [], [], [], [], []]
Output
[null, [1, -2], [1, -1], [-1, -2], [-2, -2], [0, 0]]

Explanation
Solution solution = new Solution([[-2, -2, 1, 1], [2, 2, 4, 6]]);
solution.pick(); // return [1, -2]
solution.pick(); // return [1, -1]
solution.pick(); // return [-1, -2]
solution.pick(); // return [-2, -2]
solution.pick(); // return [0, 0]
 

Constraints:

1 <= rects.length <= 100
rects[i].length == 4
-109 <= ai < xi <= 109
-109 <= bi < yi <= 109
xi - ai <= 2000
yi - bi <= 2000
All the rectangles do not overlap.
At most 104 calls will be made to pick.
*/

//***************Solution********************
public class Solution {
    private int[][] rects;
    private int[] areas;
    //global random num
    private Random rand = new Random();

    public int[] Pick() {
         // pick a rectangle
        int randArea = rand.Next(areas.Last()) + 1;
        int index = Array.BinarySearch(areas, randArea);

        if (index < 0)
            index = ~index; //bit wise complement

        // pick a point within the rectangle for x and y
        int[] rect = rects[index];
        int x = rand.Next(rect[0], rect[2] + 1);
        int y = rand.Next(rect[1], rect[3] + 1);
        return new int[] { x, y };
    }

    //main
    public Solution(int[][] rects) {
        this.rects = rects;
        this.areas = new int[rects.Length];
        int totalArea = 0;

        //loop through rects.Length
        //calculate the area of the rectangle, accumulate area sum, update current areas to totalArea.
        for (int i = 0; i < rects.Length; i++){
            int area = (rects[i][2] - rects[i][0] + 1) * (rects[i][3] - rects[i][1] + 1);
            totalArea += area;
            this.areas[i] = totalArea;
        }
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(rects);
 * int[] param_1 = obj.Pick();
 */
