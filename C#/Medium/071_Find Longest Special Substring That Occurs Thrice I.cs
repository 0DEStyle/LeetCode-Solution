/*Challenge link:https://leetcode.com/problems/find-longest-special-substring-that-occurs-thrice-i/description/
Question:
You are given a string s that consists of lowercase English letters.

A string is called special if it is made up of only a single character. For example, the string "abc" is not special, whereas the strings "ddd", "zz", and "f" are special.

Return the length of the longest special substring of s which occurs at least thrice, or -1 if no special substring occurs at least thrice.

A substring is a contiguous non-empty sequence of characters within a string.

 

Example 1:

Input: s = "aaaa"
Output: 2
Explanation: The longest special substring which occurs thrice is "aa": substrings "aaaa", "aaaa", and "aaaa".
It can be shown that the maximum length achievable is 2.
Example 2:

Input: s = "abcdef"
Output: -1
Explanation: There exists no special substring which occurs at least thrice. Hence return -1.
Example 3:

Input: s = "abcaba"
Output: 1
Explanation: The longest special substring which occurs thrice is "a": substrings "abcaba", "abcaba", and "abcaba".
It can be shown that the maximum length achievable is 1.
 

Constraints:

3 <= s.length <= 50
s consists of only lowercase English letters.
*/

//***************Solution********************
//dictionary
public class Solution {
    public int MaximumLength(string s) {
        //char and list  dictionary to store the count for each characters.
        var hash = new Dictionary<char, List<int>>();
        int n = s.Length, i = 0;

        //while i is less than s.length
        while (i < n){
            int index = 1;
            char ch = s[i]; //current char in string s
            //while i is less than n-1 AND current character is the same as the next
            //increase index and i by 1
            while (i < n - 1 && s[i] == s[i + 1]){
                index++;
                i++;
            }
            //if hash doesn't contain ch, create a new int list, store in ch element.
            if (!hash.ContainsKey(ch))
                hash[ch] = new List<int>();
            //add index at ch element, increase i by 1
            hash[ch].Add(index);
            i++;
        }

        //max
        int maxi = -1;
        //loop through list inside each hash values.
        foreach (List<int> lis in hash.Values){
            //sort current list
            lis.Sort((a, b) => b.CompareTo(a));
            
            //if first element of list is greater or equal to 3, select max value between maxi and current element of list -2
            if (lis[0] >= 3)
                maxi = Math.Max(maxi, lis[0] - 2);
            //if list count is greater or equal to 2
            //and if first element of list is greater or equal to 2, select max value betwween maxi and 
            //min value between lis[0] - 1, and list[1]
            //if list count is greater or equal to 3
            //select max value betwween maxi and min value between lis[0], Math.Min(lis[1], lis[2]
            if (lis.Count >= 2){
                if (lis[0] >= 2)
                    maxi = Math.Max(maxi, Math.Min(lis[0] - 1, lis[1]));
                if (lis.Count >= 3)
                    maxi = Math.Max(maxi, Math.Min(lis[0], Math.Min(lis[1], lis[2])));
            }
        }
        return maxi;
    }
}
