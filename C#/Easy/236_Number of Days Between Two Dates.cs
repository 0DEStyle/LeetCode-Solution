/*Challenge link:https://leetcode.com/problems/number-of-days-between-two-dates/description/
Question:
Write a program to count the number of days between two dates.

The two dates are given as strings, their format is YYYY-MM-DD as shown in the examples.

 

Example 1:

Input: date1 = "2019-06-29", date2 = "2019-06-30"
Output: 1
Example 2:

Input: date1 = "2020-01-15", date2 = "2019-12-31"
Output: 15
 

Constraints:

The given dates are valid dates between the years 1971 and 2100.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Solution {
    public int DaysBetweenDates(string d1, string d2) =>
     Math.Abs((DateTime.Parse(d2) - DateTime.Parse(d1)).Days);
}
