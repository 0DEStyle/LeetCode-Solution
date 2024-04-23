/*Challenge link:https://leetcode.com/problems/plates-between-candles/description/
Question:
There is a long table with a line of plates and candles arranged on top of it. You are given a 0-indexed string s consisting of characters '*' and '|' only, where a '*' represents a plate and a '|' represents a candle.

You are also given a 0-indexed 2D integer array queries where queries[i] = [lefti, righti] denotes the substring s[lefti...righti] (inclusive). For each query, you need to find the number of plates between candles that are in the substring. A plate is considered between candles if there is at least one candle to its left and at least one candle to its right in the substring.

For example, s = "||**||**|*", and a query [3, 8] denotes the substring "*||**|". The number of plates between candles in this substring is 2, as each of the two plates has at least one candle in the substring to its left and right.
Return an integer array answer where answer[i] is the answer to the ith query.

 

Example 1:
//see image in link

ex-1
Input: s = "**|**|***|", queries = [[2,5],[5,9]]
Output: [2,3]
Explanation:
- queries[0] has two plates between candles.
- queries[1] has three plates between candles.

Example 2:
//see image in link

ex-2
Input: s = "***|**|*****|**||**|*", queries = [[1,17],[4,5],[14,17],[5,11],[15,16]]
Output: [9,0,0,0,0]
Explanation:
- queries[0] has nine plates between candles.
- The other queries have zero plates between candles.
 

Constraints:

3 <= s.length <= 105
s consists of '*' and '|' characters.
1 <= queries.length <= 105
queries[i].length == 2
0 <= lefti <= righti < s.length
*/

//***************Solution********************
public class Solution {
    private List<int> candles = new List<int>();
    
    public int[] PlatesBetweenCandles(string s, int[][] queries) {
        //loop through s.length, if current index of s is a candle, add current index to candles.
        for(int c=0;c<s.Length; c++){
            if(s[c]=='|')
                candles.Add(c);
        }

        List<int> platesInQueries = new List<int>();
        //loop through queries' length,
        //pass queries into GetClosetsCandle method, to find both lower and upper candles.
        //get the difference between upper and lower, set it to candles count.
        for(int i=0; i< queries.Length; i++){
            int lowerCandle = GetClosetsCandle(0,candles.Count-1,queries[i][0],true);
            int upperCandle = GetClosetsCandle(0,candles.Count-1,queries[i][1],false);
            int candlesCount = upperCandle - lowerCandle;

            //if candles count is less than 1, add 0 to plates queries
            //else add difference between upper and lower, and candles count.
            if (candlesCount < 1)
                platesInQueries.Add(0);
            else
                platesInQueries.Add(candles[upperCandle] - candles[lowerCandle] - candlesCount);
        }
        //return plates array
        return platesInQueries.ToArray();
    }

    //binary search, s start, e end, m mid
    public int GetClosetsCandle(int s, int e, int target, bool lower){
        if(e < s)
            return lower ? s : e;

        //find mid index
        int m = s + (e - s)/2;

        //see if mid index equal the target, if true, return mid
        //else if check if mid index is greater than target, if true, recurrsive method, start, mid shift to left by 1
        //else recurrsive method, mid shift to right by 1 index, end.
        if (candles[m] == target)
            return m;
        else if (candles[m] > target)
            return GetClosetsCandle(s,m-1, target, lower);
        else
            return GetClosetsCandle(m+1,e, target, lower);
    }
}
