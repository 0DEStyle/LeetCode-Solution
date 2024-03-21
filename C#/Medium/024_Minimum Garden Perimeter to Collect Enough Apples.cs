/*Challenge link:https://leetcode.com/problems/minimum-garden-perimeter-to-collect-enough-apples/description/
Question:
In a garden represented as an infinite 2D grid, there is an apple tree planted at every integer coordinate. The apple tree planted at an integer coordinate (i, j) has |i| + |j| apples growing on it.

You will buy an axis-aligned square plot of land that is centered at (0, 0).

Given an integer neededApples, return the minimum perimeter of a plot such that at least neededApples apples are inside or on the perimeter of that plot.

The value of |x| is defined as:

x if x >= 0
-x if x < 0
 

Example 1:
//see image in link

Input: neededApples = 1
Output: 8
Explanation: A square plot of side length 1 does not contain any apples.
However, a square plot of side length 2 has 12 apples inside (as depicted in the image above).
The perimeter is 2 * 4 = 8.
Example 2:

Input: neededApples = 13
Output: 16
Example 3:

Input: neededApples = 1000000000
Output: 5040
*/

//***************Solution********************
/*
Each apple tree gives 3 apples
Every next iteration, the number of apples in the area grows by =>
Formula: (P / 8)^2 * 12

Where 12 comes from 4 * 3.
4 is the count of the square's sides.
3 is the amount of apples from each apple tree

p = 8 ,16, 24, 32, 40
*/
public class Solution {
    public long MinimumPerimeter(long neededApples) {
        //starting at 1 perimeter
        long side = 1;

        //while the needed apples is still greater than 0,
        //find the number of apple for each perimeter, and subtract from neededApples, increase side by 1 each time
        while (neededApples > 0){
            neededApples -= (side * side * 12);
            side++;
        }

        //start at 0, so subtract 1, then times 8 for the adjacent cells
        return (side - 1) * 8;
    }
}
