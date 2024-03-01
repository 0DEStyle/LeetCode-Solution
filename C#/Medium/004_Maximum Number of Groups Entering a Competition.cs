/*Challenge link:https://leetcode.com/problems/maximum-number-of-groups-entering-a-competition/description/
Question:
You are given a positive integer array grades which represents the grades of students in a university. You would like to enter all these students into a competition in ordered non-empty groups, such that the ordering meets the following conditions:

The sum of the grades of students in the ith group is less than the sum of the grades of students in the (i + 1)th group, for all groups (except the last).
The total number of students in the ith group is less than the total number of students in the (i + 1)th group, for all groups (except the last).
Return the maximum number of groups that can be formed.

 

Example 1:

Input: grades = [10,6,12,7,3,5]
Output: 3
Explanation: The following is a possible way to form 3 groups of students:
- 1st group has the students with grades = [12]. Sum of grades: 12. Student count: 1
- 2nd group has the students with grades = [6,7]. Sum of grades: 6 + 7 = 13. Student count: 2
- 3rd group has the students with grades = [10,3,5]. Sum of grades: 10 + 3 + 5 = 18. Student count: 3
It can be shown that it is not possible to form more than 3 groups.
Example 2:

Input: grades = [8,8]
Output: 1
Explanation: We can only form 1 group, since forming 2 groups would lead to an equal number of students in both groups.
 

Constraints:

1 <= grades.length <= 105
1 <= grades[i] <= 105
*/

//***************Solution********************
/*
Sort all grades,
assign 1 student to the first group,
assign 2 student to the second group...
to find out the maximum result k that
1 + 2 + ... + k <= n

Sort groups by size,
so the first group has size at least 1
so the second group has size at least 2
kth group has size at least k...
upper bound will be k
*/
public class Solution {
    public int MaximumGroups(int[] grades) {
        int k = 0, total = 0, n = grades.Length;
        while (total + k + 1 <= n)
            total += ++k;
        return k;
    }
}
//binary search method
public class Solution {
    public int MaximumGroups(int[] grades) {
        //set start and end
        long low = 1,  high = grades.Length - 1;
        long target = low;

        while (low <= high) {
            //get mid index
            long mid = low + (high - low) / 2;

            //condition check if mid index + 1 * mid / 2 is less than grades' length
            //compare target and mid to for max value
            //shift low index to right by 1
            //else shift high index to left by 1
            if (mid * (mid + 1) / 2 <= grades.Length) {
                target = Math.Max(target, mid);
                low = mid + 1;
            }
            else
                high = high - 1;
        }
        //parse to int and return result.
        return (int)target;
    }
}
