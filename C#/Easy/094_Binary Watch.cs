/*Challenge link:https://leetcode.com/problems/binary-watch/description/
Question:
A binary watch has 4 LEDs on the top to represent the hours (0-11), and 6 LEDs on the bottom to represent the minutes (0-59). Each LED represents a zero or one, with the least significant bit on the right.

For example, the below binary watch reads "4:51".
//see image in link

Given an integer turnedOn which represents the number of LEDs that are currently on (ignoring the PM), return all possible times the watch could represent. You may return the answer in any order.

The hour must not contain a leading zero.

For example, "01:00" is not valid. It should be "1:00".
The minute must consist of two digits and may contain a leading zero.

For example, "10:2" is not valid. It should be "10:02".
 

Example 1:

Input: turnedOn = 1
Output: ["0:01","0:02","0:04","0:08","0:16","0:32","1:00","2:00","4:00","8:00"]
Example 2:

Input: turnedOn = 9
Output: []
 

Constraints:

0 <= turnedOn <= 10
*/

//***************Solution********************
public class Solution {
    public IList<string> ReadBinaryWatch(int turnedOn) {
        var res = new List<string>();

        //loop 60 mins and 12 hours
        //pass minute and hour into count bit, then find the sum to see if it equal to turnedon
        //if true, format time and add to res.
        for (var minute = 0; minute < 60; minute++)
            for (var hour = 0; hour < 12; hour++)
                if (CountBits(minute) + CountBits(hour) == turnedOn)
                    res.Add($"{hour}:{minute:D2}");
        return res;

        //count bit function
        //while num is not zero
        //AND num - 1 with num, increase count by 1
        int CountBits(int num){
            var count = 0;
            while (num != 0){
                num &= num - 1;
                count++;
            }
            return count;
        }
    }
}
