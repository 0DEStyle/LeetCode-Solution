/*Challenge link:https://leetcode.com/problems/fizz-buzz/description/
Question:
Given an integer n, return a string array answer (1-indexed) where:

answer[i] == "FizzBuzz" if i is divisible by 3 and 5.
answer[i] == "Fizz" if i is divisible by 3.
answer[i] == "Buzz" if i is divisible by 5.
answer[i] == i (as a string) if none of the above conditions are true.
 

Example 1:

Input: n = 3
Output: ["1","2","Fizz"]
Example 2:

Input: n = 5
Output: ["1","2","Fizz","4","Buzz"]
Example 3:

Input: n = 15
Output: ["1","2","Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz","11","Fizz","13","14","FizzBuzz"]
 

Constraints:

1 <= n <= 104
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//faster
public class Solution {
    public IList<string> FizzBuzz(int n)  => 
    Enumerable
            .Range(1, n)
            .Select(x =>
                (x % 3, x % 5) switch {
                    (0, 0) => "FizzBuzz",
                    (0, _) => "Fizz",
                    (_, 0) => "Buzz",
                        _  => x.ToString()
                })
            .ToList();
}

//solution 2
public class Solution {
    public IList<string> FizzBuzz(int n){
        var list = new List<string>(n);

        for (int i = 1; i <= n; i++)
        {
            string item = (i % 3 == 0, i % 5 == 0) switch
            {
                (true, true) => "FizzBuzz",
                (true, false) => "Fizz",
                (false, true) => "Buzz",
                (false, false) => i.ToString()
            };

            list.Add(item);
        }

        return list;
        
    }
}
