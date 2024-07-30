/*Challenge link:https://leetcode.com/problems/hamming-distance/description/
Question:
The Hamming distance between two integers is the number of positions at which the corresponding bits are different.

Given two integers x and y, return the Hamming distance between them.

 

Example 1:

Input: x = 1, y = 4
Output: 2
Explanation:
1   (0 0 0 1)
4   (0 1 0 0)
       ↑   ↑
The above arrows point to positions where the corresponding bits are different.
Example 2:

Input: x = 3, y = 1
Output: 1
 

Constraints:

0 <= x, y <= 231 - 1
*/

//***************Solution********************
//3 = 0011
//1 = 0001
//      ^
public class Solution {
    public int HammingDistance(int x, int y){
        //xor x and y
        int m = x ^ y, count = 0;

        //while m is greater than 0
        //accumulate sum m AND 1
        //left bit shift m by 1 each iteration.
        while(m > 0){
            count += m & 1;
            m >>=1;
        }
        return count;

    }
}
