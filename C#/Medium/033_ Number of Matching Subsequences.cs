/*Challenge link:https://leetcode.com/problems/number-of-matching-subsequences/description/
Question:
Given a string s and an array of strings words, return the number of words[i] that is a subsequence of s.

A subsequence of a string is a new string generated from the original string with some characters (can be none) deleted without changing the relative order of the remaining characters.

For example, "ace" is a subsequence of "abcde".
 

Example 1:

Input: s = "abcde", words = ["a","bb","acd","ace"]
Output: 3
Explanation: There are three strings in words that are a subsequence of s: "a", "acd", "ace".
Example 2:

Input: s = "dsahjpjauf", words = ["ahjpjau","ja","ahbwzgqnuk","tnmlanowax"]
Output: 2
 

Constraints:

1 <= s.length <= 5 * 104
1 <= words.length <= 5000
1 <= words[i].length <= 50
s and words[i] consist of only lowercase English letters.
*/

//***************Solution********************
//dictionaries method
public class Solution {
    public int NumMatchingSubseq(string s, string[] words) {

        Dictionary<char, List<int>> charIndexes = new Dictionary<char, List<int>>();
        int ind = 0, res = 0;;

        //loop through each character in s, check if it contains c, if so add to dictionary
        //else add new list with index to dictionary
		foreach (char c in s){
			if (charIndexes.ContainsKey(c))
				charIndexes[c].Add(ind);
			else
				charIndexes.Add(c, new List<int>() { ind });
			ind++;
			}

        //loop through each word in words.
		foreach (string word in words){
			bool sub = true;
			int lastInd = -1;
			Dictionary<char, int> lastUsedInd = new Dictionary<char, int>();
            
            //loop through each character in word, if dictonary contains character, update index from list indexes
            foreach (char c in word){
				if (charIndexes.ContainsKey(c)){  
					List<int> indexes = charIndexes[c];
					bool found = false;
                    int i = 0;

                    //check if last used index contains character, if true, increase it by 1
					if (lastUsedInd.ContainsKey(c))
						i = lastUsedInd[c]++;

                    //check if current index is greater than last index,
                    //if it doesn't contains character, update the new character and i
                    //else set last used to i
					while (i < indexes.Count){
						if (indexes[i]>lastInd){
							found = true;
							lastInd = indexes[i];
							if (!lastUsedInd.ContainsKey(c))
								lastUsedInd.Add(c, i);
							else
								lastUsedInd[c] = i;
							break;
							}
						i++;
						}
                    //set sub to false if nothing is found
					if (!found) sub = false;
					}
                    //set sub to false if nothing is found
                    //if no sub, then break.
					else sub = false;
					if (!sub) break;
				}
                //if sub is true, add 1 to res
				if (sub) res++;
			}
			return res;
    }
}
