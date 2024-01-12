/*Challenge link:https://leetcode.com/problems/valid-parentheses/
Question:
Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:

Open brackets must be closed by the same type of brackets.
Open brackets must be closed in the correct order.
Every close bracket has a corresponding open bracket of the same type.
 

Example 1:

Input: s = "()"
Output: true
Example 2:

Input: s = "()[]{}"
Output: true
Example 3:

Input: s = "(]"
Output: false
 

Constraints:

1 <= s.length <= 104
s consists of parentheses only '()[]{}'.
*/

//***************Solution********************
using System.Text.RegularExpressions;

public class Solution {
    public bool IsValid(string input) {
        //for checking the difference
        int lengthCheck = input.Length; 
        
        while(input.Length != 0){
            input = Regex.Replace(input, @"\(\)", "");    //remove pattern: ()
            input = Regex.Replace(input, @"\[\]", "");    //remove pattern: []
            input = Regex.Replace(input, @"\{\}", "");    //remove pattern: {}

            //if length check stays the same, or reached 0
            //return true if length is zero, meaning no more brackets left
            if (lengthCheck == input.Length || input.Length == 0) return input.Length == 0; 
            else lengthCheck = input.Length; //overwrite lengthcheck, more parentheses to check!
            }
    //if string is empty, return true.
    return input.Length == 0;
    }
}


//solution 2
public class Solution {
    public bool IsValid(string parentheses) {
        Stack<char> stack = new();

        Dictionary<char, char> dict = new(){
            {'(', ')'}, 
            {'{', '}'}, 
            {'[', ']'}
        };

        for (int i = 0; i < parentheses.Length; i++)
        {
            if(dict.Keys.Contains(parentheses[i]))
                stack.Push(parentheses[i]); 
            else if(stack.Count > 0 && parentheses[i] == dict[stack.Peek()])
                stack.Pop();
            else
                return false;
        }

        return stack.Count == 0;
    }
}
