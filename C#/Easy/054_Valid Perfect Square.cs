/*Challenge link:https://leetcode.com/problems/valid-perfect-square/description/
Question:
Given a positive integer num, return true if num is a perfect square or false otherwise.

A perfect square is an integer that is the square of an integer. In other words, it is the product of some integer with itself.

You must not use any built-in library function, such as sqrt.

 

Example 1:

Input: num = 16
Output: true
Explanation: We return true because 4 * 4 = 16 and 4 is an integer.
Example 2:

Input: num = 14
Output: false
Explanation: We return false because 3.742 * 3.742 = 14 and 3.742 is not an integer.
 

Constraints:

1 <= num <= 231 - 1
*/

//***************Solution********************
//get sqrt of num, round to whole numbner and square it back to see if it is equal to num
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Solution {
    public bool IsPerfectSquare(int num) => (int)Math.Sqrt(num) * (int)Math.Sqrt(num) == num;
}

//binary search method
public class Solution {
    public bool IsPerfectSquare(int num){
        //start and end
        long left = 0, right = num;

        while (left <= right){
            //get mid
            long mid = left + (right - left)/2;

            //if square == num return true, else shift index by 1 towards either left or right
            if (mid*mid == num) return true;
            else if (mid*mid < num) left = mid + 1;
            else if (mid*mid > num) right = mid - 1;
        }
        return false;
    }
}
