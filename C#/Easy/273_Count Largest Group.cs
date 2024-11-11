/*Challenge link:https://leetcode.com/problems/count-largest-group/description/
Question:
You are given an integer n.

Each number from 1 to n is grouped according to the sum of its digits.

Return the number of groups that have the largest size.

 

Example 1:

Input: n = 13
Output: 4
Explanation: There are 9 groups in total, they are grouped according sum of its digits of numbers from 1 to 13:
[1,10], [2,11], [3,12], [4,13], [5], [6], [7], [8], [9].
There are 4 groups with largest size.
Example 2:

Input: n = 2
Output: 2
Explanation: There are 2 groups [1], [2] of size 1.
 

Constraints:

1 <= n <= 104
*/

//***************Solution********************
/*
[1,10],  1 = 1 + 0
 [2,11], 2 = 1 + 1
 [3,12],  3 = 1 + 2
 [4,13],  4 = 1 + 3
 [5], [6], [7], [8], [9]. 1 digit

*/
public class Solution {
    public int CountLargestGroup(int n) {
        var a = new int[36];

        //loop from 1 to n
        //set curr to i, set mod 10 remainder to j
        for (int i = 1; i <= n; i++){
            int curr = i, j = curr % 10;     

        //if digit is greater than 0.
        //divide by 10, shifting 1 digit
        //accumulate sum to j
            while (curr / 10 > 0){
            curr /= 10;
            j += (curr % 10);
            }
            //increase a at j-1 by 1
            a[j - 1]++;
        }

        //get max element and count.
        return a.Where(x => x == a.Max()).Count();
    }
}
