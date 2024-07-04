/*Challenge link:https://leetcode.com/problems/maximum-number-of-robots-within-budget/description/
Question:
You have n robots. You are given two 0-indexed integer arrays, chargeTimes and runningCosts, both of length n. The ith robot costs chargeTimes[i] units to charge and costs runningCosts[i] units to run. You are also given an integer budget.

The total cost of running k chosen robots is equal to max(chargeTimes) + k * sum(runningCosts), where max(chargeTimes) is the largest charge cost among the k robots and sum(runningCosts) is the sum of running costs among the k robots.

Return the maximum number of consecutive robots you can run such that the total cost does not exceed budget.

 

Example 1:

Input: chargeTimes = [3,6,1,3,4], runningCosts = [2,1,3,4,5], budget = 25
Output: 3
Explanation: 
It is possible to run all individual and consecutive pairs of robots within budget.
To obtain answer 3, consider the first 3 robots. The total cost will be max(3,6,1) + 3 * sum(2,1,3) = 6 + 3 * 6 = 24 which is less than 25.
It can be shown that it is not possible to run more than 3 consecutive robots within budget, so we return 3.
Example 2:

Input: chargeTimes = [11,12,19], runningCosts = [10,8,7], budget = 19
Output: 0
Explanation: No robot can be run that does not exceed the budget, so we return 0.
 

Constraints:

chargeTimes.length == runningCosts.length == n
1 <= n <= 5 * 104
1 <= chargeTimes[i], runningCosts[i] <= 105
1 <= budget <= 1015
*/

//***************Solution********************
//max(chargeTimes) + k * sum(runningCosts)
//return maximum number of consecutive
public class Solution {
    public int MaximumRobots(int[] chargeTimes, int[] runningCosts, long budget) {
        //create priority queue
        PriorityQueue<int, int> pq = new();
        long sum = 0; 
        int max = 0, n = chargeTimes.Length;

        //enqueue (i, current charge time  * -1)
        for(int i = 0, j = 0; i < n; i++){
            pq.Enqueue(i, chargeTimes[i] * -1);
            //accumulate sum
            sum += runningCosts[i];

            //while greater than budget AND j less than or equal to i
            //while count is greater than 0 AND pq.peek is less than or equal to j, dequeue from pq
            //reduce sum by running cost at index j
            while(j <= i && (chargeTimes[pq.Peek()] + (i - j + 1) * sum) > budget){
                while(pq.Count > 0 && pq.Peek() <= j) 
                    pq.Dequeue();
                sum -= runningCosts[j++];
            }
            //get max between max and i - j + 1
            max = Math.Max(max, (i-j+1));
        }
        return max;
    }
}
