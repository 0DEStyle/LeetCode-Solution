/*Challenge link:https://leetcode.com/problems/verifying-an-alien-dictionary/description/
Question:
In an alien language, surprisingly, they also use English lowercase letters, but possibly in a different order. The order of the alphabet is some permutation of lowercase letters.

Given a sequence of words written in the alien language, and the order of the alphabet, return true if and only if the given words are sorted lexicographically in this alien language.

 

Example 1:

Input: words = ["hello","leetcode"], order = "hlabcdefgijkmnopqrstuvwxyz"
Output: true
Explanation: As 'h' comes before 'l' in this language, then the sequence is sorted.
Example 2:

Input: words = ["word","world","row"], order = "worldabcefghijkmnpqstuvxyz"
Output: false
Explanation: As 'd' comes after 'l' in this language, then words[0] > words[1], hence the sequence is unsorted.
Example 3:

Input: words = ["apple","app"], order = "abcdefghijklmnopqrstuvwxyz"
Output: false
Explanation: The first three characters "app" match, and the second string is shorter (in size.) According to lexicographical rules "apple" > "app", because 'l' > '∅', where '∅' is defined as the blank character which is less than any other character (More info).
 

Constraints:

1 <= words.length <= 100
1 <= words[i].length <= 20
order.length == 26
All characters in words[i] and order are English lowercase letters.
*/

//***************Solution********************
/*
hlabcdefgijkmnopqrstuvwxy
abcdefghijklmnopqrstuvwxyz

*/

public class Solution {
    public bool IsAlienSorted(string[] words, string order) {
        Dictionary<char, char> alphabet = new();

        //map character
        for (int i = 0; i < 26; i++)
            alphabet.Add(order[i], (char)('a' + i));

        
        var translated = new string[words.Length];

        //loop through words. length
        //loop through each character in current words
        //append alphabet.
        for (int i = 0; i < words.Length; i++){
            StringBuilder translation = new();
            foreach (char c in words[i])
                translation.Append(alphabet[c]);
            translated[i] = translation.ToString();
        }
        
        //sort in ascending order, compare with original.
        return translated.OrderBy(x => x).SequenceEqual(translated);
    }
}
