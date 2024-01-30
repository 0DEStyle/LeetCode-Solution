/*Challenge link:https://leetcode.com/problems/valid-palindrome/description/
Question:
A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.

Given a string s, return true if it is a palindrome, or false otherwise.

 

Example 1:

Input: s = "A man, a plan, a canal: Panama"
Output: true
Explanation: "amanaplanacanalpanama" is a palindrome.
Example 2:

Input: s = "race a car"
Output: false
Explanation: "raceacar" is not a palindrome.
Example 3:

Input: s = " "
Output: true
Explanation: s is an empty string "" after removing non-alphanumeric characters.
Since an empty string reads the same forward and backward, it is a palindrome.
 

Constraints:

1 <= s.length <= 2 * 105
s consists only of printable ASCII characters.
*/

//***************Solution********************
//convert s to lower, replace only a-z and 0-9 to nothing
//convert s to char, reverse the order, then compare to the original string.
using System.Text.RegularExpressions;

public class Solution {
    public bool IsPalindrome(string s) {
        s = Regex.Replace(s.ToLower(), @"[^a-z0-9]", "");

        char[] chars = s.ToCharArray();
        Array.Reverse(chars);
        string reverse = new string(chars);
        
        return s.Equals(reverse);
    }
}

//faster solution
public class Solution 
{
    public bool IsPalindrome(string s) 
    {
        for (int i = 0, j = s.Length - 1 ; j > i ; )
        {
            if ( !char.IsLetterOrDigit(s[i]) )
            {
                i++;
                continue;
            }

            if ( !char.IsLetterOrDigit(s[j]) )
            {
                j--;
                continue;
            }

            if ( char.ToLower(s[i++]) != char.ToLower(s[j--]) )
            {
                return false;
            }
        }
        return true;
    }
}
