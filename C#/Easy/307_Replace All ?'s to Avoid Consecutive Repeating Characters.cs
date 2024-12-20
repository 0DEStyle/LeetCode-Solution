/*Challenge link:https://leetcode.com/problems/replace-all-s-to-avoid-consecutive-repeating-characters/description/
Question:
Given a string s containing only lowercase English letters and the '?' character, convert all the '?' characters into lowercase letters such that the final string does not contain any consecutive repeating characters. You cannot modify the non '?' characters.

It is guaranteed that there are no consecutive repeating characters in the given string except for '?'.

Return the final string after all the conversions (possibly zero) have been made. If there is more than one solution, return any of them. It can be shown that an answer is always possible with the given constraints.

 

Example 1:

Input: s = "?zs"
Output: "azs"
Explanation: There are 25 solutions for this problem. From "azs" to "yzs", all are valid. Only "z" is an invalid modification as the string will consist of consecutive repeating characters in "zzs".
Example 2:

Input: s = "ubv?w"
Output: "ubvaw"
Explanation: There are 24 solutions for this problem. Only "v" and "w" are invalid modifications as the strings will consist of consecutive repeating characters in "ubvvw" and "ubvww".
 

Constraints:

1 <= s.length <= 100
s consist of lowercase English letters and '?'.
*/

//***************Solution********************
public class Solution {

    public string ModifyString(string s) {
        var arr = s.ToCharArray();

        for(int i = 0; i < arr.Length; i++){
            //if '?' is in the string
            if(arr[i] == '?'){
                //set current letter to shift letter
                arr[i] = shiftLetter(getLetter(i - 1));

                //if shifted letter equal next letter, shift to new letter
                if(arr[i] == getLetter(i + 1))
                    arr[i] = shiftLetter(arr[i]);
            }
        }

        return string.Concat(arr);

        //Helper methods
        //find difference, get remainder, then shift the index from 'a'
        char shiftLetter(char x) => (char)((x - 'a' + 1) % ('z' - 'a' + 1) + 'a');
        //if index is greater or equal to 0, AND  less than arr.Length, return current element, else 'z'
        char getLetter(int x) => (x >= 0 && x < arr.Length) ? arr[x] : 'z';
    }
}

