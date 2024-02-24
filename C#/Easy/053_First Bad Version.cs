/*Challenge link:https://leetcode.com/problems/first-bad-version/description/
Question:
You are a product manager and currently leading a team to develop a new product. Unfortunately, the latest version of your product fails the quality check. Since each version is developed based on the previous version, all the versions after a bad version are also bad.

Suppose you have n versions [1, 2, ..., n] and you want to find out the first bad one, which causes all the following ones to be bad.

You are given an API bool isBadVersion(version) which returns whether version is bad. Implement a function to find the first bad version. You should minimize the number of calls to the API.

 

Example 1:

Input: n = 5, bad = 4
Output: 4
Explanation:
call isBadVersion(3) -> false
call isBadVersion(5) -> true
call isBadVersion(4) -> true
Then 4 is the first bad version.
Example 2:

Input: n = 1, bad = 1
Output: 1
*/

//***************Solution********************

/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

//binary search method
public class Solution : VersionControl {
    public int FirstBadVersion(int n) {
        //initialized bad, low and high
        int bad = 0, low = 1, high = n;

        //while high is greater or equal to low
        while (low <= high){
            //get mid
            //int mid = (high + low) / 2; //doesn't prevent overflow
            int mid = low + (high - low) / 2;
            //check if mid is bad
            //if true, set bad as mid, then shift high to left by 1
            //else shift low to right by 1
            if (IsBadVersion(mid)){
                bad = mid;
                high = mid - 1;
            }
            else
                low = mid + 1;
            }
        //return result
        return bad;
    }
}
