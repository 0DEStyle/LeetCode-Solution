/*Challenge link:https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string/description/
Question:
Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.

 

Example 1:

Input: haystack = "sadbutsad", needle = "sad"
Output: 0
Explanation: "sad" occurs at index 0 and 6.
The first occurrence is at index 0, so we return 0.
Example 2:

Input: haystack = "leetcode", needle = "leeto"
Output: -1
Explanation: "leeto" did not occur in "leetcode", so we return -1.
 

Constraints:

1 <= haystack.length, needle.length <= 104
haystack and needle consist of only lowercase English characters.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//get index of first substring.
public class Solution {
    public int StrStr(string haystack, string needle) => haystack.IndexOf(needle);
}

//solution 2
//loop through the length of haystack, 
//if char in haystack is the same as needle. increase matchLoc by 1
//and if matchLoc is the same as needle length, set result to i - matchLoc + 1, then break the loop
//else set i to matchLoc subtract by 1, set matchLoc to 0
public class Solution {
    public int StrStr(string haystack, string needle) {
        int result = -1;
        int matchLoc = 0;

        for(int i = 0; i < haystack.Length; i++){
            if(haystack[i] == needle[matchLoc]){
                matchLoc++;
                if(matchLoc == needle.Length){
                    result = i - matchLoc + 1;
                    break;
                }
            }
            else {
                i -= matchLoc;
                matchLoc = 0;
            }
        }
        return result;
    }
}
