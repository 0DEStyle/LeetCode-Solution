/*Challenge link:https://leetcode.com/problems/find-first-palindromic-string-in-the-array/description/
Question:
A string is palindromic if it reads the same forward and backward.

 

Example 1:

Input: words = ["abc","car","ada","racecar","cool"]
Output: "ada"
Explanation: The first string that is palindromic is "ada".
Note that "racecar" is also palindromic, but it is not the first.
Example 2:

Input: words = ["notapalindrome","racecar"]
Output: "racecar"
Explanation: The first and only string that is palindromic is "racecar".
Example 3:

Input: words = ["def","ghi"]
Output: ""
Explanation: There are no palindromic strings, so the empty string is returned.
 

Constraints:

1 <= words.length <= 100
1 <= words[i].length <= 100
words[i] consists only of lowercase English letters.
*/

//***************Solution********************
//faster
//check if current elemnent equal its reversed version
//if null return nothing.
public class Solution {
    public string FirstPalindrome(string[] s){
        foreach(var i in s)
            if(checkPal(i)) return i;
        return "";
    }

    private bool checkPal(string s){
        int p1 = 0, p2 = s.Length - 1;

        while(p1 < p2){
            if(s[p1] != s[p2])
                return false;
            p1++; p2--;
        }
        return true;
    }
}
//slow 90ms
//check if current elemnent equal its reversed version
//if null return nothing.
public class Solution {
    public string FirstPalindrome(string[] s)  =>
    s.FirstOrDefault(x => x == string.Concat(x.Reverse())) ?? "";
}
