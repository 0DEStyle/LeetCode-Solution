/*Challenge link:https://leetcode.com/problems/add-binary/description/
Question:
Given two binary strings a and b, return their sum as a binary string.

 

Example 1:

Input: a = "11", b = "1"
Output: "100"
Example 2:

Input: a = "1010", b = "1011"
Output: "10101"
 

Constraints:

1 <= a.length, b.length <= 104
a and b consist only of '0' or '1' characters.
Each string does not contain leading zeros except for the zero itself.
*/

//***************Solution********************
public class Solution {
    public string AddBinary(string a, string b) {

      //initiate variables...
        var ans = new StringBuilder();
        int carry = 0;
        int i = a.Length - 1, j = b.Length - 1;

      //while these conditions are true
        while(i >= 0 || j >= 0 || carry == 1){

          //while i and j are greater or equal to 0, convert a[i] and b[j] to ASCII by subtracting '0'(48), then add the result to carry
          //decrease i or j by 1 for next iteration.
            if(i >= 0) carry += a[i--] - '0';
            if(j >= 0) carry += b[j--] - '0';

          //start from index 0 insert carry mod 2 
          //divide carry by 2, and go to next iteration
            ans.Insert(0, carry % 2);
            carry /= 2;
        }

      //if carry is greater than 0, insert carry at index 0
        if(carry > 0) ans.Insert(0, carry);
        return ans.ToString();
    }
}
