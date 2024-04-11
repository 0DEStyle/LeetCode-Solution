/*Challenge link:https://leetcode.com/problems/friends-of-appropriate-ages/description/
Question:
There are n persons on a social media website. You are given an integer array ages where ages[i] is the age of the ith person.

A Person x will not send a friend request to a person y (x != y) if any of the following conditions is true:

age[y] <= 0.5 * age[x] + 7
age[y] > age[x]
age[y] > 100 && age[x] < 100
Otherwise, x will send a friend request to y.

Note that if x sends a request to y, y will not necessarily send a request to x. Also, a person will not send a friend request to themself.

Return the total number of friend requests made.

 

Example 1:

Input: ages = [16,16]
Output: 2
Explanation: 2 people friend request each other.
Example 2:

Input: ages = [16,17,18]
Output: 2
Explanation: Friend requests are made 17 -> 16, 18 -> 17.
Example 3:

Input: ages = [20,30,100,110,120]
Output: 3
Explanation: Friend requests are made 110 -> 100, 120 -> 110, 120 -> 100.
 

Constraints:

n == ages.length
1 <= n <= 2 * 104
1 <= ages[i] <= 120
*/

//***************Solution********************
//binary search method
public class Solution {
    public int NumFriendRequests(int[] ages) {
        //initiateres and sort ages in ascending order
        int res = 0;
        Array.Sort(ages);

        //loop through ages.Length
        for (int i = 0; i < ages.Length; ++i) {
            //get lower and upper ages by passing in ages into the Binary search function(firstIdx)
            //select max value between upper-lower-1 and 0, accumulate to result.
            int age = ages[i], lower = firstIdx(ages, age/2+7), upper = firstIdx(ages, age);
            res += Math.Max(upper-lower-1, 0);
        }
        return res;
    }
    
    private static int firstIdx(int[] ages, int target) {
        //set boundaries
        int low = 0, high = ages.Length-1;

        while (low <= high) {
            //get mid index
            int mid = low + (high - low)/2;

            //check for condition
            //if true, shift low to right by 1 index
            //else shift high to left by 1 index
            if (ages[mid] <= target) 
                low = mid + 1;
            else 
                high = mid - 1;
        }
        return low;
    }
}
