/*Challenge link:https://leetcode.com/problems/longest-common-prefix/
Question:
Write a function to find the longest common prefix string amongst an array of strings.

If there is no common prefix, return an empty string "".

 

Example 1:

Input: strs = ["flower","flow","flight"]
Output: "fl"
Example 2:

Input: strs = ["dog","racecar","car"]
Output: ""
Explanation: There is no common prefix among the input strings.
 

Constraints:

1 <= strs.length <= 200
0 <= strs[i].length <= 200
strs[i] consists of only lowercase English letters.
*/

//***************Solution********************

public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        var res = "";
        //loop through each character in the first word inside strs array, compare the first word to the rest
        for(int i = 0; i < strs[0].Length; i++){
            //loop through each word inside strs
            //if index is within boundary, or character inside word is not equal to character inside the first word
            //return result
            foreach(string word in strs){
                if(i == word.Length || word[i] != strs[0][i])
                return res;
            }
            //once the common prefix character is found, add it to result
            res += strs[0][i];
        }
        return res;
    }
}
