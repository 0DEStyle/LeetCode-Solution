/*Challenge link:https://leetcode.com/problems/preimage-size-of-factorial-zeroes-function/description/
Question:
Let f(x) be the number of zeroes at the end of x!. Recall that x! = 1 * 2 * 3 * ... * x and by convention, 0! = 1.

For example, f(3) = 0 because 3! = 6 has no zeroes at the end, while f(11) = 2 because 11! = 39916800 has two zeroes at the end.
Given an integer k, return the number of non-negative integers x have the property that f(x) = k.

 

Example 1:

Input: k = 0
Output: 5
Explanation: 0!, 1!, 2!, 3!, and 4! end with k = 0 zeroes.
Example 2:

Input: k = 5
Output: 0
Explanation: There is no x such that x! ends in k = 5 zeroes.
Example 3:

Input: k = 3
Output: 5
 

Constraints:

0 <= k <= 109
*/

//***************Solution********************
public class Solution {

    //helper method.
    private long numOfTrailingZeros(long x) {
    long res = 0;
    for (; x > 0; x /= 5)
        res += x/5;
    return res;
}

    public int PreimageSizeFZF(int K) {
        //k = num of trailing zero at the end of the number
        //set boundaries, left = 0, right = 5L * (K + 1), while l is less than or equal to r
        for (long l = 0, r =  5L * (K + 1); l <= r;) {
            //find mid index
            long m = l + (r - l) / 2;
            //get trailing zero and set to k
            long k = numOfTrailingZeros(m);
            
            //check condition and shift left and right index accordingly
            if (k < K) 
                l = m + 1;
            else if (k > K)
                r = m - 1;
            else 
                return 5;

    }
    return 0;
}
}
