/*Challenge link:https://leetcode.com/problems/find-words-that-can-be-formed-by-characters/description/
Question:
You are given an array of strings words and a string chars.

A string is good if it can be formed by characters from chars (each character can only be used once).

Return the sum of lengths of all good strings in words.

 

Example 1:

Input: words = ["cat","bt","hat","tree"], chars = "atach"
Output: 6
Explanation: The strings that can be formed are "cat" and "hat" so the answer is 3 + 3 = 6.
Example 2:

Input: words = ["hello","world","leetcode"], chars = "welldonehoneyr"
Output: 10
Explanation: The strings that can be formed are "hello" and "world" so the answer is 5 + 5 = 10.
 

Constraints:

1 <= words.length <= 1000
1 <= words[i].length, chars.length <= 100
words[i] and chars consist of lowercase English letters.
*/

//***************Solution********************
public class Solution {
    public int CountCharacters(string[] words, string chars) {
        int totalLength = 0;
        int[] charCount = new int[26];
        
        //loop through all character in chars, store frequency
        foreach (char ch in chars)
            charCount[ch - 'a']++; 

        //loop through all word in words
        foreach (string word in words) {
            int[] tempCharCount = new int[26];
            bool canForm = true;

            //check char in each word, increase char count 
            foreach (char ch in word)
                tempCharCount[ch - 'a']++; // Increment count for each character in the word

            //if word can't be formed, set flag to false
            for (int i = 0; i < 26; i++) {
                if (tempCharCount[i] > charCount[i]) {
                    canForm = false;
                    break;
                }
            }

            //accumulate word length
            if (canForm) 
                totalLength += word.Length;
        }

        return totalLength;
    }
}
