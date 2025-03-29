/*Challenge link:https://leetcode.com/problems/minimum-sum-of-four-digit-number-after-splitting-digits/description/
Question:
You are given a positive integer num consisting of exactly four digits. Split num into two new integers new1 and new2 by using the digits found in num. Leading zeros are allowed in new1 and new2, and all the digits found in num must be used.

For example, given num = 2932, you have the following digits: two 2's, one 9 and one 3. Some of the possible pairs [new1, new2] are [22, 93], [23, 92], [223, 9] and [2, 329].
Return the minimum possible sum of new1 and new2.

 

Example 1:

Input: num = 2932
Output: 52
Explanation: Some possible pairs [new1, new2] are [29, 23], [223, 9], etc.
The minimum sum can be obtained by the pair [29, 23]: 29 + 23 = 52.
Example 2:

Input: num = 4009
Output: 13
Explanation: Some possible pairs [new1, new2] are [0, 49], [490, 0], etc. 
The minimum sum can be obtained by the pair [4, 9]: 4 + 9 = 13.
 

Constraints:

1000 <= num <= 9999
*/

//***************Solution********************
/*
2/2 split have smaller sums than 1/3 splits
1,3 and 2,4 combination

*/
public class Solution {
    public int MinimumSum(int num) {
        var arr = num.ToString().ToCharArray();
        Array.Sort(arr);
        return ((arr[0] - '0') * 10 + (arr[2] - '0')) +
               ((arr[1] - '0') * 10 + (arr[3] - '0'));
    }
}
