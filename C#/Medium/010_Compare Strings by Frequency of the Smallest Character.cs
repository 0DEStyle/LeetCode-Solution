/*Challenge link:https://leetcode.com/problems/compare-strings-by-frequency-of-the-smallest-character/
Question:
Let the function f(s) be the frequency of the lexicographically smallest character in a non-empty string s. For example, if s = "dcce" then f(s) = 2 because the lexicographically smallest character is 'c', which has a frequency of 2.

You are given an array of strings words and another array of query strings queries. For each query queries[i], count the number of words in words such that f(queries[i]) < f(W) for each W in words.

Return an integer array answer, where each answer[i] is the answer to the ith query.

 

Example 1:

Input: queries = ["cbd"], words = ["zaaaz"]
Output: [1]
Explanation: On the first query we have f("cbd") = 1, f("zaaaz") = 3 so f("cbd") < f("zaaaz").
Example 2:

Input: queries = ["bbb","cc"], words = ["a","aa","aaa","aaaa"]
Output: [1,2]
Explanation: On the first query only f("bbb") < f("aaaa"). On the second query both f("aaa") and f("aaaa") are both > f("cc").
 

Constraints:

1 <= queries.length <= 2000
1 <= words.length <= 2000
1 <= queries[i].length, words[i].length <= 10
queries[i][j], words[i][j] consist of lowercase English letters.

*/

//***************Solution********************
//binary search method
public class Solution {
     public static int getFrequncy(string s) {
        char chr = 'z';
        int count = 0;


        //loop through each charactert in string s
        //if character is smaller than 'z', set count to back 1, set chr to current character
        //else if they are the same, increase count by 1.
        foreach(char ch in s.ToCharArray()) {
            if (ch < chr) {
                count = 1;
                chr = ch;
            } 
            else if (chr == ch) 
                count++;
        }
        return count;
    }

    public int[] NumSmallerByFrequency(string[] queries, string[] words) {
        
        //create arr with the size of queries and words
        var q = new int[queries.Length];
        var w = new int[words.Length];
        int qLen = q.Length, wLen = w.Length;
        var res = new int[qLen];

        //fill q and w for each array member
        for (int i = 0; i < qLen; i++)
            q[i] = getFrequncy(queries[i]);
        for (int i = 0; i < wLen; i++)
            w[i] = getFrequncy(words[i]);

        //visualization
        //["bbb","cc"] => 3,2
        //["a","aa","aaa","aaaa"] => 1,2,3,4
        //Console.WriteLine(string.Join(",", q));
        //Console.WriteLine(string.Join(",", w));
        
        //sort array in ascending order for binary search
        Array.Sort(w);

        //loop through qLen amount of time
        for (int i = 0; i < qLen; i++) {
            //low as 0, high as the end
            int low = 0, high = wLen - 1;

            while (low <= high) {
                //find mid index
                int mid = low + (high - low) / 2;

                //compare frenquncy of current element
                //if w[mid] is less than or equal to q[i], shift the low to right by 1 index
                //else shift high to left by 1 index
                if (w[mid] <= q[i])
                    low = mid + 1;
                else 
                    high = mid - 1;
            }
            res[i] = wLen - low;
        }
        return res;
    }
}
