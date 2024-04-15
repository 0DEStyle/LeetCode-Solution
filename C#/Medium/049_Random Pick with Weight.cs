/*Challenge link:https://leetcode.com/problems/random-pick-with-weight/description/
Question:
You are given a 0-indexed array of positive integers w where w[i] describes the weight of the ith index.

You need to implement the function pickIndex(), which randomly picks an index in the range [0, w.length - 1] (inclusive) and returns it. The probability of picking an index i is w[i] / sum(w).

For example, if w = [1, 3], the probability of picking index 0 is 1 / (1 + 3) = 0.25 (i.e., 25%), and the probability of picking index 1 is 3 / (1 + 3) = 0.75 (i.e., 75%).
 

Example 1:

Input
["Solution","pickIndex"]
[[[1]],[]]
Output
[null,0]

Explanation
Solution solution = new Solution([1]);
solution.pickIndex(); // return 0. The only option is to return 0 since there is only one element in w.
Example 2:

Input
["Solution","pickIndex","pickIndex","pickIndex","pickIndex","pickIndex"]
[[[1,3]],[],[],[],[],[]]
Output
[null,1,1,1,1,0]

Explanation
Solution solution = new Solution([1, 3]);
solution.pickIndex(); // return 1. It is returning the second element (index = 1) that has a probability of 3/4.
solution.pickIndex(); // return 1
solution.pickIndex(); // return 1
solution.pickIndex(); // return 1
solution.pickIndex(); // return 0. It is returning the first element (index = 0) that has a probability of 1/4.

Since this is a randomization problem, multiple answers are allowed.
All of the following outputs can be considered correct:
[null,1,1,1,1,0]
[null,1,1,1,1,1]
[null,1,1,1,0,0]
[null,1,1,1,0,1]
[null,1,0,1,0,0]
......
and so on.
 

Constraints:

1 <= w.length <= 104
1 <= w[i] <= 105
pickIndex will be called at most 104 times.
*/

//***************Solution********************
/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(w);
 * int param_1 = obj.PickIndex();
 */

 //lazy binary search using method
public class Solution {
    private int[] sums;
    private Random randNum;

    public Solution(int[] w) {
        //store w.length index into sums
        sums = new int[w.Length];

        //loopthrough w.Length
        //if current inedx is less than 0, set current element sum to w[i] + sums[i-1]
        //else set it to w[i] - 1
        for (int i = 0; i < w.Length; i++)
            sums[i] = (i > 0) ? w[i] + sums[i-1] : w[i] - 1;

        //create new random number
        randNum = new Random();
    }
    
    //
    public int PickIndex() {
        //select next random number and store in weight.
        //use binarsearch method for sums and weight, store in index
        //if index is less than 0, return use  bitwise NOT operator to invert index, else return index
        int weight = randNum.Next(0, sums[^1] + 1);
        int index = Array.BinarySearch(sums, weight);
        return (index < 0) ? ~index : index;
    }
}
