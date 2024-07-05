/*Challenge link:https://leetcode.com/problems/random-pick-with-blacklist/description/
Question:
You are given an integer n and an array of unique integers blacklist. Design an algorithm to pick a random integer in the range [0, n - 1] that is not in blacklist. Any integer that is in the mentioned range and not in blacklist should be equally likely to be returned.

Optimize your algorithm such that it minimizes the number of calls to the built-in random function of your language.

Implement the Solution class:

Solution(int n, int[] blacklist) Initializes the object with the integer n and the blacklisted integers blacklist.
int pick() Returns a random integer in the range [0, n - 1] and not in blacklist.
 

Example 1:

Input
["Solution", "pick", "pick", "pick", "pick", "pick", "pick", "pick"]
[[7, [2, 3, 5]], [], [], [], [], [], [], []]
Output
[null, 0, 4, 1, 6, 1, 0, 4]

Explanation
Solution solution = new Solution(7, [2, 3, 5]);
solution.pick(); // return 0, any integer from [0,1,4,6] should be ok. Note that for every call of pick,
                 // 0, 1, 4, and 6 must be equally likely to be returned (i.e., with probability 1/4).
solution.pick(); // return 4
solution.pick(); // return 1
solution.pick(); // return 6
solution.pick(); // return 1
solution.pick(); // return 0
solution.pick(); // return 4
 

Constraints:

1 <= n <= 109
0 <= blacklist.length <= min(105, n - 1)
0 <= blacklist[i] < n
All the values of blacklist are unique.
At most 2 * 104 calls will be made to pick.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Solution {
    //global list l
    List<(int start, int end)> l = new();

    public Solution(int n, int[] blacklist) {
        Array.Sort(blacklist);
        var start = 0;

        //add to list.
        for(int i = 0; i < blacklist.Length; i++){
            var end = blacklist[i] - 1;
            if (start <= end)
                l.Add(new (start, end));
			start = blacklist[i] + 1;
        }   
		if (start < n)
			l.Add(new (start, n - 1));    
    }
    
    public int Pick() {
        int i = (int)(DateTime.Now.Ticks % l.Count);
        var count = l[i].end - l[i].start + 1;
        return l[i].start + (int)(DateTime.Now.Ticks % count);
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(n, blacklist);
 * int param_1 = obj.Pick();
 */
