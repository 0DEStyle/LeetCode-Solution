/*Challenge link:https://leetcode.com/problems/smallest-good-base/description/
Question:
Given an integer n represented as a string, return the smallest good base of n.

We call k >= 2 a good base of n, if all digits of n base k are 1's.

 

Example 1:

Input: n = "13"
Output: "3"
Explanation: 13 base 3 is 111.
Example 2:

Input: n = "4681"
Output: "8"
Explanation: 4681 base 8 is 11111.
Example 3:

Input: n = "1000000000000000000"
Output: "999999999999999999"
Explanation: 1000000000000000000 base 999999999999999999 is 11.
 

Constraints:

n is an integer in the range [3, 1018].
n does not contain any leading zeros.
*/

//***************Solution********************
public class Solution {
    public string SmallestGoodBase(string n) {
        BigInteger target = BigInteger.Parse(n), result = target - 1;

        for(int m = 2; m <= 2 * BigInteger.Log(target); ++m){
            //set boundaries
            BigInteger left = 2, right = target + 10;

            while(left <= right){
                //find mid index, sum
                var temp = left + (right - left)/2;
                var sum = (BigInteger.Pow(temp, m) - 1);
                
                //check condition and update result
                if( sum == target * (temp - 1)){   
                    result = BigInteger.Min(result, temp);
                    break;
                }
                //check condition and shift to left or right accordingly
                if( sum < target * (temp - 1))
                    left = temp + 1;
                else
                    right = temp - 1;
            }
        }
        return result.ToString();
    }
}
