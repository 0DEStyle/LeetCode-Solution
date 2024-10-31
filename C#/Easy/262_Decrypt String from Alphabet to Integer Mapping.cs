/*Challenge link:https://leetcode.com/problems/decrypt-string-from-alphabet-to-integer-mapping/description/
Question:
You are given a string s formed by digits and '#'. We want to map s to English lowercase characters as follows:

Characters ('a' to 'i') are represented by ('1' to '9') respectively.
Characters ('j' to 'z') are represented by ('10#' to '26#') respectively.
Return the string formed after mapping.

The test cases are generated so that a unique mapping will always exist.

 

Example 1:

Input: s = "10#11#12"
Output: "jkab"
Explanation: "j" -> "10#" , "k" -> "11#" , "a" -> "1" , "b" -> "2".
Example 2:

Input: s = "1326#"
Output: "acz"
 

Constraints:

1 <= s.length <= 1000
s consists of digits and the '#' letter.
s will be a valid string such that mapping is always possible.
*/

//***************Solution********************
public class Solution {
    public string FreqAlphabets(string s) {
    StringBuilder str = new();

    //loop until s.length
    for (int i = 0; i < s.Length;) {
        
        //'j' to 'z' => '10#' to '26#'
        //if i is less than s.length -2, AND index is #
        //offset asciii s[i] by subtracting '1', times 10.
        //'j' + s[i + 1] - '0', then convert to char
        if (i < s.Length - 2 && s[i + 2] == '#') {
        str.Append((char)('j' + (s[i] - '1') * 10 + s[i + 1] - '0'));
        //shfit index by 3
        i += 3;
        }

        //'a' to 'i' => '1' to '9'
        //offset s[i] by subtracting '1', + 'a' then convert to char.
        else {
        str.Append((char)('a' + (s[i] - '1')));
        //shift index by 1
        i++;
        }
        }
        return str.ToString();
    }
}
