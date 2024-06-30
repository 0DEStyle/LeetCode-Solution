/*Challenge link:https://leetcode.com/problems/russian-doll-envelopes/description/
Question:
You are given a 2D array of integers envelopes where envelopes[i] = [wi, hi] represents the width and the height of an envelope.

One envelope can fit into another if and only if both the width and height of one envelope are greater than the other envelope's width and height.

Return the maximum number of envelopes you can Russian doll (i.e., put one inside the other).

Note: You cannot rotate an envelope.

 

Example 1:

Input: envelopes = [[5,4],[6,4],[6,7],[2,3]]
Output: 3
Explanation: The maximum number of envelopes you can Russian doll is 3 ([2,3] => [5,4] => [6,7]).
Example 2:

Input: envelopes = [[1,1],[1,1],[1,1]]
Output: 1
 

Constraints:

1 <= envelopes.length <= 105
envelopes[i].length == 2
1 <= wi, hi <= 105
*/

//***************Solution********************
//envelopes[i] = [wi, hi]
public class Solution {
    public int MaxEnvelopes(int[][] envelopes) {
            var arr = envelopes.OrderBy(x => x[0]).ThenByDescending(x => x[1]).ToArray();
            int sum = 0;
            var ls = new List<int>();

            for(int i = 0; i < arr.Length; i++) {
                int bx = arr[i][1];
                if(ls.Count == 0)
                    ls.Add(bx);
                else if(ls[ls.Count-1] < bx) 
                    ls.Add(bx);
                else {
                    //set boundaries
                    int start = 0, end = ls.Count - 1, ind = -1;
                    while(start <= end) {
                        //find mid index
                        int mid = start + (end - start) / 2;
                        //shift index accordingly
                        if(ls[mid] >= bx) {
                            ind = mid;
                            end = mid - 1;
                        }
                        else
                            start = mid + 1;
                    }
                    ls[ind] = bx;
                }
            }
            return ls.Count;
    }
}
