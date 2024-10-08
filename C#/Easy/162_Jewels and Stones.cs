/*Challenge link:https://leetcode.com/problems/jewels-and-stones/description/
Question:
You're given strings jewels representing the types of stones that are jewels, and stones representing the stones you have. Each character in stones is a type of stone you have. You want to know how many of the stones you have are also jewels.

Letters are case sensitive, so "a" is considered a different type of stone from "A".

 

Example 1:

Input: jewels = "aA", stones = "aAAbbbb"
Output: 3
Example 2:

Input: jewels = "z", stones = "ZZ"
Output: 0
 

Constraints:

1 <= jewels.length, stones.length <= 50
jewels and stones consist of only English letters.
All the characters of jewels are unique.
*/

//***************Solution********************
public class Solution {
    public int NumJewelsInStones(string j, string s, int sum = 0) {
        //256 size
        var gems = new int[256];

        //accumulate gem at index stone
        foreach (char stone in s)
            gems[(int)stone]++;

        //check if s contains jewel. if true, accumulate sum.
        foreach (char jewel in j) 
            if (s.Contains(jewel.ToString()))
                sum += gems[(int)jewel];

        return sum;
    }
}
