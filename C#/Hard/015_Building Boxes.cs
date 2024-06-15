/*Challenge link:https://leetcode.com/problems/building-boxes/description/
Question:
You have a cubic storeroom where the width, length, and height of the room are all equal to n units. You are asked to place n boxes in this room where each box is a cube of unit side length. There are however some rules to placing the boxes:

You can place the boxes anywhere on the floor.
If box x is placed on top of the box y, then each side of the four vertical sides of the box y must either be adjacent to another box or to a wall.
Given an integer n, return the minimum possible number of boxes touching the floor.

 

Example 1:
//see image in link


Input: n = 3
Output: 3
Explanation: The figure above is for the placement of the three boxes.
These boxes are placed in the corner of the room, where the corner is on the left side.
Example 2:
//see image in link


Input: n = 4
Output: 3
Explanation: The figure above is for the placement of the four boxes.
These boxes are placed in the corner of the room, where the corner is on the left side.
Example 3:
//see image in link


Input: n = 10
Output: 6
Explanation: The figure above is for the placement of the ten boxes.
These boxes are placed in the corner of the room, where the corner is on the back side.
 

Constraints:

1 <= n <= 109
*/

//***************Solution********************
public class Solution {
    public int MinimumBoxes(int n) {
        //set boundaries
        long low = 0L, high = (long)n;

        while (low < high){
            //find mid index
            long mid = low + (high - low) / 2; 
            //find first number of product terms
            long prodTerms = (long)(Math.Sqrt(2 * mid + 0.25) - 0.5);
            long remTerms = mid - (prodTerms * (prodTerms + 1)) / 2;
            long prodSum = 0;

            //accumulate product sum
            for (long i = 1; i <= prodTerms; i++)
                prodSum += (i) * (i + 1);

            long midMax = ((remTerms) * (remTerms + 1) + prodSum) / 2;
            //check validation and set high and low accordingly
            if (midMax < n)
                low = mid + 1;
            else
                high = mid;
        }
        return (int)low;
    }
}
