/*Challenge link:https://leetcode.com/problems/word-pattern/description/
Question:
Given a pattern and a string s, find if s follows the same pattern.

Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in s.

 

Example 1:

Input: pattern = "abba", s = "dog cat cat dog"
Output: true
Example 2:

Input: pattern = "abba", s = "dog cat cat fish"
Output: false
Example 3:

Input: pattern = "aaaa", s = "dog cat cat dog"
Output: false
 

Constraints:

1 <= pattern.length <= 300
pattern contains only lower-case English letters.
1 <= s.length <= 3000
s contains only lowercase English letters and spaces ' '.
s does not contain any leading or trailing spaces.
All the words in s are separated by a single space.
*/

//***************Solution********************
public class Solution {
    public bool WordPattern(string pattern, string s) {
    var dict1 = new Dictionary<char,string>();
    var dict2 = new Dictionary<string,char>();
    var sList = s.Split(' '); //split by space

    //if pattern length is different to list count, return false
      if(pattern.Length != sList.Count()) 
        return false;

    //compare dictionary (pattern) to list at index i 
    //compare dictionary (list) to pattern at index i
      for(int i=0;i<sList.Count();i++){
        dict1.TryAdd(pattern[i], sList[i]);
        dict2.TryAdd(sList[i],pattern[i]);


        if(dict1[pattern[i]] != sList[i]) 
            return false;
        if(dict2[sList[i]] != pattern[i]) 
            return false;
      }
      return true;
    }
}
