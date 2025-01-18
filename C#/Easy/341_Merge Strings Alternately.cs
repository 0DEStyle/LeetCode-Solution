/*Challenge link:https://leetcode.com/problems/merge-strings-alternately/description/
Question:
You are given two strings word1 and word2. Merge the strings by adding letters in alternating order, starting with word1. If a string is longer than the other, append the additional letters onto the end of the merged string.

Return the merged string.

 

Example 1:

Input: word1 = "abc", word2 = "pqr"
Output: "apbqcr"
Explanation: The merged string will be merged as so:
word1:  a   b   c
word2:    p   q   r
merged: a p b q c r
Example 2:

Input: word1 = "ab", word2 = "pqrs"
Output: "apbqrs"
Explanation: Notice that as word2 is longer, "rs" is appended to the end.
word1:  a   b 
word2:    p   q   r   s
merged: a p b q   r   s
Example 3:

Input: word1 = "abcd", word2 = "pq"
Output: "apbqcd"
Explanation: Notice that as word1 is longer, "cd" is appended to the end.
word1:  a   b   c   d
word2:    p   q 
merged: a p b q c   d
 

Constraints:

1 <= word1.length, word2.length <= 100
word1 and word2 consist of lowercase English letters.
*/

//***************Solution********************
public class Solution {
    public string MergeAlternately(string word1, string word2) {
        var res = "";
        int x = 0, a = word1.Length, b = word2.Length;
            
            //loop while a or b is greater than x
            //if x is less than either a or b, append current letter of respective string to res.
            while(x < a || x < b){
                if(x < a) res += word1[x];
                if(x < b) res += word2[x];
                x++;
            }
           return res; 
    }
}
