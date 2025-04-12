/*Challenge link:https://leetcode.com/problems/largest-number-after-digit-swaps-by-parity/description/
Question:
You are given a positive integer num. You may swap any two digits of num that have the same parity (i.e. both odd digits or both even digits).

Return the largest possible value of num after any number of swaps.

 

Example 1:

Input: num = 1234
Output: 3412
Explanation: Swap the digit 3 with the digit 1, this results in the number 3214.
Swap the digit 2 with the digit 4, this results in the number 3412.
Note that there may be other sequences of swaps but it can be shown that 3412 is the largest possible number.
Also note that we may not swap the digit 4 with the digit 1 since they are of different parities.
Example 2:

Input: num = 65875
Output: 87655
Explanation: Swap the digit 8 with the digit 6, this results in the number 85675.
Swap the first digit 5 with the digit 7, this results in the number 87655.
Note that there may be other sequences of swaps but it can be shown that 87655 is the largest possible number.
 

Constraints:

1 <= num <= 109
*/

//***************Solution********************
public class Solution {
    public int LargestInteger(int num) {
       List<int> odds = new(), evens = new();
       int cur = num;

       //if current is bit is even add to even, else odd
       while(cur > 0){
            int res = cur % 10;
            if(res % 2 == 0)
                evens.Add(res);
            else
                odds.Add(res);
            cur /= 10;
       }
 
       int digits = 1, idxOdd = 0, idxEven = 0, ans = 0;
       cur = num;

       //sort in ascending order
       odds.Sort();
       evens.Sort();

       while(cur > 0){
            int res = cur % 10;
            int val = res % 2 == 0 ? evens[idxEven++] : odds[idxOdd++];
            //accumulate value
            ans += (val * digits);
            digits *= 10;
            cur /= 10;
       }

       return ans;
    }
}
