/*Challenge link:https://leetcode.com/problems/find-common-characters/description/
Question:
Given a string array words, return an array of all characters that show up in all strings within the words (including duplicates). You may return the answer in any order.

 

Example 1:

Input: words = ["bella","label","roller"]
Output: ["e","l","l"]
Example 2:

Input: words = ["cool","lock","cook"]
Output: ["c","o"]
 

Constraints:

1 <= words.length <= 100
1 <= words[i].length <= 100
words[i] consists of lowercase English letters.
*/

//***************Solution********************
public class Solution {
    public IList<string> CommonChars(string[] words) {

        //check null or 0, return result if true
        var result = new List<string>();
        if (words == null || words.Length == 0)
            return result;

        //26 letters, fill array minFreq
        int[] minFreq = new int[26];
        Array.Fill(minFreq, int.MaxValue);

        //loop through each word
        //count each c in word
        foreach (string word in words) {
            int[] charCount = new int[26];
            foreach (char c in word) 
                charCount[c - 'a']++;

            //set min frequency value into list at current index
            for (int i = 0; i < 26; i++) 
                minFreq[i] = Math.Min(minFreq[i], charCount[i]);
        }

        // Collect the common characters
        for (int i = 0; i < 26; i++) 
            for (int j = 0; j < minFreq[i]; j++) 
                result.Add(((char)(i + 'a')).ToString());

        return result;
    }
}
