/*Challenge link:https://leetcode.com/problems/consecutive-characters/description/
Question:
The power of the string is the maximum length of a non-empty substring that contains only one unique character.

Given a string s, return the power of s.

 

Example 1:

Input: s = "leetcode"
Output: 2
Explanation: The substring "ee" is of length 2 with the character 'e' only.
Example 2:

Input: s = "abbcccddddeeeeedcba"
Output: 5
Explanation: The substring "eeeee" is of length 5 with the character 'e' only.
 

Constraints:

1 <= s.length <= 500
s consists of only lowercase English letters.
*/

//***************Solution********************
public class Solution {
    public int MaxPower(string s) {
        int count = 1, max = 1;

        //loop from 1 to s length
        //if current element matches last element, count +1
        //else check if count is greater than max, if true set max to count, else keep it the same
        //set count to 1
        for (int i = 1; i < s.Length; i++){
            if (s[i] == s[i - 1])
                count++;
            else{
                max = count > max ? count : max;
                count = 1; 
            }
        }

        //if count is greater than max, return count, else max.
        return count > max ? count : max;
    }
}
