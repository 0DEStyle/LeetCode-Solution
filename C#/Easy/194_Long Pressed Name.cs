/*Challenge link:https://leetcode.com/problems/long-pressed-name/description/
Question:
Your friend is typing his name into a keyboard. Sometimes, when typing a character c, the key might get long pressed, and the character will be typed 1 or more times.

You examine the typed characters of the keyboard. Return True if it is possible that it was your friends name, with some characters (possibly none) being long pressed.

 

Example 1:

Input: name = "alex", typed = "aaleex"
Output: true
Explanation: 'a' and 'e' in 'alex' were long pressed.
Example 2:

Input: name = "saeed", typed = "ssaaedd"
Output: false
Explanation: 'e' must have been pressed twice, but it was not in the typed output.
 

Constraints:

1 <= name.length, typed.length <= 1000
name and typed consist of only lowercase English letters.
*/

//***************Solution********************
public class Solution {
    public bool IsLongPressedName(string name, string typed) {
        int index = 0;

        for(int i = 0; i < typed.Length; i++){
            //compare length AND check match
            if(index < name.Length && name[index] == typed[i]){
                index++;
                continue;
            }
            else if(index > 0 && name[index - 1] == typed[i]){
                continue;
            }
            return false;
        }
        return !(index < name.Length);
    }
}
