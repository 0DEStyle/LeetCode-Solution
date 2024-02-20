/*Challenge link:https://leetcode.com/problems/find-smallest-letter-greater-than-target/description/
Question:
You are given an array of characters letters that is sorted in non-decreasing order, and a character target. There are at least two different characters in letters.

Return the smallest character in letters that is lexicographically greater than target. If such a character does not exist, return the first character in letters.

 

Example 1:

Input: letters = ["c","f","j"], target = "a"
Output: "c"
Explanation: The smallest character that is lexicographically greater than 'a' in letters is 'c'.
Example 2:

Input: letters = ["c","f","j"], target = "c"
Output: "f"
Explanation: The smallest character that is lexicographically greater than 'c' in letters is 'f'.
Example 3:

Input: letters = ["x","x","y","y"], target = "z"
Output: "x"
Explanation: There are no characters in letters that is lexicographically greater than 'z' so we return letters[0].
 

Constraints:

2 <= letters.length <= 104
letters[i] is a lowercase English letter.
letters is sorted in non-decreasing order.
letters contains at least two different characters.
target is a lowercase English letter.
*/

//***************Solution********************
//binary search method

public class Solution {
    public char NextGreatestLetter(char[] letters, char target) {
        int n = letters.Length;
        //start and end of array
        int low = 0, high = n - 1;
        
        while (low <= high) {
            //find idpoint
            int mid = low + (high - low) / 2;
            
            // If the character at mid is less than or equal to target, shift lower to right by 1 index
            //else shift higher to left by 1 index
            if (letters[mid] <= target) 
                low = mid + 1;
            else 
                high = mid - 1;
        }
        //if low is less than n, return low index, else return 0
        return low < n ? letters[low] : letters[0];
    }
}
