/*Challenge link:https://leetcode.com/problems/greatest-common-divisor-of-strings/description/
Question:
For two strings s and t, we say "t divides s" if and only if s = t + t + t + ... + t + t (i.e., t is concatenated with itself one or more times).

Given two strings str1 and str2, return the largest string x such that x divides both str1 and str2.

 

Example 1:

Input: str1 = "ABCABC", str2 = "ABC"
Output: "ABC"
Example 2:

Input: str1 = "ABABAB", str2 = "ABAB"
Output: "AB"
Example 3:

Input: str1 = "LEET", str2 = "CODE"
Output: ""
 

Constraints:

1 <= str1.length, str2.length <= 1000
str1 and str2 consist of English uppercase letters.
*/

//***************Solution********************
public class Solution {
    public string GcdOfStrings(string str1, string str2) {
        int l1 = str1.Length, l2 = str2.Length;

        //if length 1 or 2 equal to 0, OR str1 + str2 not equal to str2 + str1
        //return nothing.
        if(l1 == 0 || l2 == 0 || str1 + str2 != str2 + str1)
            return "";

        //while length1 is not equal 0
        //set l1 to l2 mod l1, and l2 to l1
        while(l1 != 0)
            (l1, l2) = (l2 % l1, l1);
        
        //take substring from 0 to l2
        return str1.Substring(0, l2);
    }
}
