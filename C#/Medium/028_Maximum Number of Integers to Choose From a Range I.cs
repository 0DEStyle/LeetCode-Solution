/*Challenge link:https://leetcode.com/problems/maximum-number-of-integers-to-choose-from-a-range-i/description/
Question:
You are given an integer array banned and two integers n and maxSum. You are choosing some number of integers following the below rules:

The chosen integers have to be in the range [1, n].
Each integer can be chosen at most once.
The chosen integers should not be in the array banned.
The sum of the chosen integers should not exceed maxSum.
Return the maximum number of integers you can choose following the mentioned rules.

 

Example 1:

Input: banned = [1,6,5], n = 5, maxSum = 6
Output: 2
Explanation: You can choose the integers 2 and 4.
2 and 4 are from the range [1, 5], both did not appear in banned, and their sum is 6, which did not exceed maxSum.
Example 2:

Input: banned = [1,2,3,4,5,6,7], n = 8, maxSum = 1
Output: 0
Explanation: You cannot choose any integer while following the mentioned conditions.
Example 3:

Input: banned = [11], n = 7, maxSum = 50
Output: 7
Explanation: You can choose the integers 1, 2, 3, 4, 5, 6, and 7.
They are from the range [1, 7], all did not appear in banned, and their sum is 28, which did not exceed maxSum.
 

Constraints:

1 <= banned.length <= 104
1 <= banned[i], n <= 104
1 <= maxSum <= 109
*/

//***************Solution********************
//hashset
public class Solution {
    public int MaxCount(int[] banned, int n, int maxSum) {
         HashSet<int> hash = new(banned);
        int currentSum = 0, result = 0;

        //loop through n
        //if hash contains i, continue, if currentSum + i is exceed maxSum, break
        for (int i = 1; i <= n; i++){
            if (hash.Contains(i))
                continue;
            if (currentSum + i > maxSum)
                break;
            //accumulate curretn sum and result
            currentSum += i;
            result++;
        }
        return result;
    }
}
//binary search
public class Solution {
    public static bool inarr(int i,int[] arr){
        //set boundaries
        int low = 0, high = arr.Length-1;

        while(low<=high){
            //find mid index
            int mid = (high - low)/2 + low;

            //check if mid matches i, if so return true
            //if mid is less than i, shift low to right by 1 index
            //else shift high to left by 1 index
            if(arr[mid]==i)
                return true;
            else if(arr[mid]<i)
                low=mid+1;
            else
                high = mid-1;
        }
        //no match
        return false;
    }

    public int MaxCount(int[] banned, int n, int maxSum) {
        //sort the banned array in ascending order
        Array.Sort(banned);
        int count=0, i=1, sum =0;

        //loop while i is less than or equal to n
        while(i<=n){
            //check if continue is true, increase i by 1
            //else if sum + i is less than maxSum, increase count by 1, and accumulate sum
            if(inarr(i,banned))
                i++;
            else{
                if(sum+i<=maxSum){
                    count++;
                    sum = sum+i;
                }
                i++;
            }
    }
    return count;
    }
}

