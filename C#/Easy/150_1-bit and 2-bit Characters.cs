/*Challenge link:https://leetcode.com/problems/1-bit-and-2-bit-characters/description/
Question:
We have two special characters:

The first character can be represented by one bit 0.
The second character can be represented by two bits (10 or 11).
Given a binary array bits that ends with 0, return true if the last character must be a one-bit character.

 

Example 1:

Input: bits = [1,0,0]
Output: true
Explanation: The only way to decode it is two-bit character and one-bit character.
So the last character is one-bit character.
Example 2:

Input: bits = [1,1,1,0]
Output: false
Explanation: The only way to decode it is two-bit character and two-bit character.
So the last character is not one-bit character.
 

Constraints:

1 <= bits.length <= 1000
bits[i] is either 0 or 1.
*/

//***************Solution********************
/*
Personal Translation of the description :
We use three bit-representations to represent three characters : 0, 10, 11 (the corresponding characters don't matter)
So bits representation 1, 01 are not valid.
Given an array of bits ending with 0, 
find out if it's only valid to translate the last 0 into the 0 bit representation 
(means it's not valid when the last 0 is translated into the 10 bits representation)

*/
public class Solution {
    public bool IsOneBitCharacter(int[] bits, int i = 0) {
        while(i < bits.Length-1){
            if(bits[i] == 1)
                i++;
            i++;
        }
        return i == bits.Length-1;
    }
}
