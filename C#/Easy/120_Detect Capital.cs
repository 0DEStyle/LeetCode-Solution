/*Challenge link:https://leetcode.com/problems/detect-capital/description/
Question:
We define the usage of capitals in a word to be right when one of the following cases holds:

All letters in this word are capitals, like "USA".
All letters in this word are not capitals, like "leetcode".
Only the first letter in this word is capital, like "Google".
Given a string word, return true if the usage of capitals in it is right.

 

Example 1:

Input: word = "USA"
Output: true
Example 2:

Input: word = "FlaG"
Output: false
 

Constraints:

1 <= word.length <= 100
word consists of lowercase and uppercase English letters.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//all leters are uppercase OR
//word skip 1, all letters are lower case.
public class Solution {
    public bool DetectCapitalUse(string w) => w.All(char.IsUpper) || w.Skip(1).All(char.IsLower);
}
