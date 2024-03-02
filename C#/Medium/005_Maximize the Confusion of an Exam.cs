/*Challenge link:https://leetcode.com/problems/maximize-the-confusion-of-an-exam/description/
Question:
A teacher is writing a test with n true/false questions, with 'T' denoting true and 'F' denoting false. He wants to confuse the students by maximizing the number of consecutive questions with the same answer (multiple trues or multiple falses in a row).

You are given a string answerKey, where answerKey[i] is the original answer to the ith question. In addition, you are given an integer k, the maximum number of times you may perform the following operation:

Change the answer key for any question to 'T' or 'F' (i.e., set answerKey[i] to 'T' or 'F').
Return the maximum number of consecutive 'T's or 'F's in the answer key after performing the operation at most k times.

 

Example 1:

Input: answerKey = "TTFF", k = 2
Output: 4
Explanation: We can replace both the 'F's with 'T's to make answerKey = "TTTT".
There are four consecutive 'T's.
Example 2:

Input: answerKey = "TFFT", k = 1
Output: 3
Explanation: We can replace the first 'T' with an 'F' to make answerKey = "FFFT".
Alternatively, we can replace the second 'T' with an 'F' to make answerKey = "TFFF".
In both cases, there are three consecutive 'F's.
Example 3:

Input: answerKey = "TTFTTFTT", k = 1
Output: 5
Explanation: We can replace the first 'F' to make answerKey = "TTTTTFTT"
Alternatively, we can replace the second 'F' to make answerKey = "TTFTTTTT". 
In both cases, there are five consecutive 'T's.
 

Constraints:

n == answerKey.length
1 <= n <= 5 * 104
answerKey[i] is either 'T' or 'F'
1 <= k <= n
*/

//***************Solution********************
//binary search method
public class Solution {
    public int MaxConsecutiveAnswers(string answerKey, int k) {
        //string length, max consecutive, max changes count, left side of sliding window
        int n = answerKey.Length, maxConsecutive = 0, maxCount = 0, left = 0;
        //count array, for true and false using alphabetic index order
        int[] counts = new int[26];
        
        //iterate through the string answer keep start from right
        for (int right = 0; right < n; right++) {
            //subtract current element by 'A' ASCII value, select that index and add it to counts
            //compare maxcount with counts and select max
            counts[answerKey[right] - 'A']++;
            maxCount = Math.Max(maxCount, counts[answerKey[right] - 'A']);
            
            //while right - left + 1 - maxCount > max number of perform operation allowed
            //decrease current element - 'A' by 1,
            //shift to right
            while (right - left + 1 - maxCount > k) {
                counts[answerKey[left] - 'A']--;
                left++;
            }
            //select max between maxConsecutive and right - left + 1
            maxConsecutive = Math.Max(maxConsecutive, right - left + 1);
        }
        return maxConsecutive;
    }
}
