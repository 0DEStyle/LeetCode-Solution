/*Challenge link:https://leetcode.com/problems/x-of-a-kind-in-a-deck-of-cards/submissions/1362249534/
Question:
You are given an integer array deck where deck[i] represents the number written on the ith card.

Partition the cards into one or more groups such that:

Each group has exactly x cards where x > 1, and
All the cards in one group have the same integer written on them.
Return true if such partition is possible, or false otherwise.

 

Example 1:

Input: deck = [1,2,3,4,4,3,2,1]
Output: true
Explanation: Possible partition [1,1],[2,2],[3,3],[4,4].
Example 2:

Input: deck = [1,1,1,2,2,2,3,3]
Output: false
Explanation: No possible partition.
 

Constraints:

1 <= deck.length <= 104
0 <= deck[i] < 104
*/

//***************Solution********************
/*
[1,2,3,4,4,3,2,1]
[1,1,2,2,3,3,4,4]
*/
public class Solution {
    public int Gcd(int a, int b) => b == 0 ? a : Gcd(b, a % b);

    public bool HasGroupsSizeX(int[] deck) {
        var d = new Dictionary<int, int>();
        for(int i = 0; i < deck.Length; i++)
            d[deck[i]] = d.GetValueOrDefault(deck[i], 0) + 1;

        int gcd = d.First().Value;
        if(gcd == 1)
            return false;
        foreach(var x in d){
            if(x.Value == 1)
              return false;

            gcd = Gcd(gcd, x.Value);
            
            if(gcd == 1)
              return false;
        }
        return gcd > 1;
    }
    }
