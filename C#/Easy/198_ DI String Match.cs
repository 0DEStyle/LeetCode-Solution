/*Challenge link:https://leetcode.com/problems/di-string-match/description/
Question:
A permutation perm of n + 1 integers of all the integers in the range [0, n] can be represented as a string s of length n where:

s[i] == 'I' if perm[i] < perm[i + 1], and
s[i] == 'D' if perm[i] > perm[i + 1].
Given a string s, reconstruct the permutation perm and return it. If there are multiple valid permutations perm, return any of them.

 

Example 1:

Input: s = "IDID"
Output: [0,4,1,3,2]
Example 2:

Input: s = "III"
Output: [0,1,2,3]
Example 3:

Input: s = "DDI"
Output: [3,2,0,1]
 

Constraints:

1 <= s.length <= 105
s[i] is either 'I' or 'D'.
*/

//***************Solution********************
/*
Better description
basically you just need to simply run D towards decrement from the length of s and I towards increment. That is if s="DDD" then output is [3,2,1,0] where first 3 of array is denoting length of s and being decrementd by 1 each time when "D" occurs again. if there was I also, lets suppose "DIIIDI" then D will be decrementing and I will be incrementing by1. output => [6,0,1,2,5,3,4].

Note :- D will start from the length of s and will be decreasing by 1 whenever "D" occurs again, and I will start from 0 and will be increasing by 1 whenever "I" occurs again. at the end I and D will be on same position so just push any of them in to the array at the end, and you will get your output.

*/public class Solution {
    public int[] DiStringMatch(string s) {
        int[] list = new int[s.Length+1];
        int left=0, right=s.Length, i=0;

        foreach(char c in s){
            if(c=='I')
                list[i++]=left++;
            else
                list[i++]=right--;
        }
        
        list[s.Length]=left;
        return list;
    }
}
