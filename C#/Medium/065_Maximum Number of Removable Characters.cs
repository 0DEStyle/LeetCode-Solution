/*Challenge link:https://leetcode.com/problems/maximum-number-of-removable-characters/description/
Question:
You are given two strings s and p where p is a subsequence of s. You are also given a distinct 0-indexed integer array removable containing a subset of indices of s (s is also 0-indexed).

You want to choose an integer k (0 <= k <= removable.length) such that, after removing k characters from s using the first k indices in removable, p is still a subsequence of s. More formally, you will mark the character at s[removable[i]] for each 0 <= i < k, then remove all marked characters and check if p is still a subsequence.

Return the maximum k you can choose such that p is still a subsequence of s after the removals.

A subsequence of a string is a new string generated from the original string with some characters (can be none) deleted without changing the relative order of the remaining characters.

 

Example 1:

Input: s = "abcacb", p = "ab", removable = [3,1,0]
Output: 2
Explanation: After removing the characters at indices 3 and 1, "abcacb" becomes "accb".
"ab" is a subsequence of "accb".
If we remove the characters at indices 3, 1, and 0, "abcacb" becomes "ccb", and "ab" is no longer a subsequence.
Hence, the maximum k is 2.
Example 2:

Input: s = "abcbddddd", p = "abcd", removable = [3,2,1,4,5,6]
Output: 1
Explanation: After removing the character at index 3, "abcbddddd" becomes "abcddddd".
"abcd" is a subsequence of "abcddddd".
Example 3:

Input: s = "abcab", p = "abc", removable = [0,1,2,3,4]
Output: 0
Explanation: If you remove the first index in the array removable, "abc" is no longer a subsequence.
 

Constraints:

1 <= p.length <= s.length <= 105
0 <= removable.length < s.length
0 <= removable[i] < s.length
p is a subsequence of s.
s and p both consist of lowercase English letters.
The elements in removable are distinct.
*/

//***************Solution********************
//binary search
public class Solution {
    public int MaximumRemovals(string s, string p, int[] rem) {
        int l = 0, r = rem.Length;
        int[] map = new int[s.Length];
        //fill map array with rem.Length
        Array.Fill(map, rem.Length);

        //loop through rem.Length, assign i to map ad rem[i] index
        for (int i = 0; i < rem.Length; ++i)
            map[rem[i]] = i;    

        
        while (l < r) {
            //find mid index
            /*
            Take upper number if l+r is odd.
            It totally depends on binary search logic. If you have left_bound = middle in your binary search you have to do l+r+1,  otherwise infinity loop will be possible.
            Example: left = 2; right = 3; middle = (2 + 3) // 2 = 2; then you have left_bound = middle (what changes nothing).

            avoiding integer overflow with
            lo + (hi - lo) / 2 -> left_bound and
            lo + (hi - lo + 1) / 2 -> right_bound or (l + r + 1) / 2
            */
            int m = (l + r + 1) / 2, j = 0;

            //while i is less than s.length AND j is less than p.length
            //check if current element in map is greater than mid index AND s[i] is the same as p[j]
            //increase j by 1
            //if j is the same as p.length, set l to m
            //elseshift r to to left by 1 index
            for (int i = 0; i < s.Length && j < p.Length; ++i)
                if (map[i] >= m && s[i] == p[j])
                    ++j;
                if (j == p.Length)
                    l = m;
                else
                    r = m - 1;
        }
        return l;
    }
}
