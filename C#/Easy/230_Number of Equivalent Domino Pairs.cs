/*Challenge link:https://leetcode.com/problems/number-of-equivalent-domino-pairs/description/
Question:
Given a list of dominoes, dominoes[i] = [a, b] is equivalent to dominoes[j] = [c, d] if and only if either (a == c and b == d), or (a == d and b == c) - that is, one domino can be rotated to be equal to another domino.

Return the number of pairs (i, j) for which 0 <= i < j < dominoes.length, and dominoes[i] is equivalent to dominoes[j].

 

Example 1:

Input: dominoes = [[1,2],[2,1],[3,4],[5,6]]
Output: 1
Example 2:

Input: dominoes = [[1,2],[1,2],[1,1],[1,2],[2,2]]
Output: 3
 

Constraints:

1 <= dominoes.length <= 4 * 104
dominoes[i].length == 2
1 <= dominoes[i][j] <= 9
*/

//***************Solution********************
public class Solution {
    public int NumEquivDominoPairs(int[][] dominoes) {
        //dictionary and counter
        Dictionary<int, int> dc = new();
        int counter = 0;

        //loop through each array in dominoes
        foreach (int[] d in dominoes){
            //set first element to small and second to big
            int small = d[0], big = d[1];

            //swap/rotate value
            if (d[0] > d[1])
                (big, small) = (d[0],d[1]);

            //set small to new key value
            small = small * 10 + big;

            // add value to dictionary, count pairs
            if (!dc.ContainsKey(small))
                dc.Add(small, 1);
            else{
                counter += dc[small];
                dc[small]++;
            }
        }
        return counter;
    }
}
