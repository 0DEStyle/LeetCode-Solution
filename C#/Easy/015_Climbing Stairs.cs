/*Challenge link:https://leetcode.com/problems/climbing-stairs/description/
Question:
You are climbing a staircase. It takes n steps to reach the top.

Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

 

Example 1:

Input: n = 2
Output: 2
Explanation: There are two ways to climb to the top.
1. 1 step + 1 step
2. 2 steps
Example 2:

Input: n = 3
Output: 3
Explanation: There are three ways to climb to the top.
1. 1 step + 1 step + 1 step
2. 1 step + 2 steps
3. 2 steps + 1 step
 

Constraints:

1 <= n <= 45
*/

//***************Solution********************
/*
brute force -> memorisation
dynamic programming
depth first search pattern
	      1
      2    5
    3  4  6  7
in the format of steps, n = 5, +1 on left, + 2 on right
  	              0
          1              2
       2      3        3    4
    3   4   4  5    4   5  5  6
  4  5 5 6 5 6    5  6       
5  6 

there are 8 "5"s, all "6" are out of bound, 
  	              0
          1              2
       2      3        3    4
    3   4   4  5    4   5  5  
  4  5 5  5       5         
5   

because there are repeated pattern, we can simplify it using memorisation
see right side pattern already occured in left side

  	              0
          1              2
       2      3        3    4
    3   4   4  5    4   5  5  
  4  5 5  5       5         
5   
simplified to
  	              0
          1              
       2      3       
    3   4   4  5     
  4  5 5  5            
5   
The same pattern for 3, can be simplified to
  	              0
          1              
       2           
    3   4     
  4  5 5         
5   
The same with 4
  	              0
          1              
       2           
    3     
  4  5          
5   
bottom up, starting from the bottom i.e 5, n as the base case, 
DP is dynamic programming stack to store the number of possible step to get to next stair
stair 0   1   2   3   4   5
DP    8 | 5 | 3 | 2 | 1 | 1 | 
so there are 8 possible ways to get to 5
from the above patterm we can simplify using only 2 varaible, one and two, time complexity of O(n)
1 + 1 = 2
2 + 3 = 5
3 + 5 = 8
*/
public class Solution {
    public int ClimbStairs(int n) {
        int one = 1, two = 1, temp;
        for(int i = 0; i < n - 1; i++){
            temp = one;
            one += two;
            two = temp;
        }
        return one;
    }
}

//efficient method
//because the pattern is fibonacci, we can simplify further
//https://medium.com/@adarshtyagi/fibonacci-in-constant-time-945546c9e64c
//since x start at 1, so we do x + 1 to shift into the right position.
//this method is O(1), can deal wtih large number extremely fast compare to memorization.
using static System.Math;
public class Solution {
    public int ClimbStairs(int x)=> (int)(1/Sqrt(5)*(Pow(((1+Sqrt(5))/2),x+1)-Pow((((1-Sqrt(5))/2)),x+1)));
}
