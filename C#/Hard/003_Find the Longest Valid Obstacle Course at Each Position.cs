/*Challenge link:https://leetcode.com/problems/find-the-longest-valid-obstacle-course-at-each-position/description/
Question:
You want to build some obstacle courses. You are given a 0-indexed integer array obstacles of length n, where obstacles[i] describes the height of the ith obstacle.

For every index i between 0 and n - 1 (inclusive), find the length of the longest obstacle course in obstacles such that:

You choose any number of obstacles between 0 and i inclusive.
You must include the ith obstacle in the course.
You must put the chosen obstacles in the same order as they appear in obstacles.
Every obstacle (except the first) is taller than or the same height as the obstacle immediately before it.
Return an array ans of length n, where ans[i] is the length of the longest obstacle course for index i as described above.

 

Example 1:

Input: obstacles = [1,2,3,2]
Output: [1,2,3,3]
Explanation: The longest valid obstacle course at each position is:
- i = 0: [1], [1] has length 1.
- i = 1: [1,2], [1,2] has length 2.
- i = 2: [1,2,3], [1,2,3] has length 3.
- i = 3: [1,2,3,2], [1,2,2] has length 3.
Example 2:

Input: obstacles = [2,2,1]
Output: [1,2,1]
Explanation: The longest valid obstacle course at each position is:
- i = 0: [2], [2] has length 1.
- i = 1: [2,2], [2,2] has length 2.
- i = 2: [2,2,1], [1] has length 1.
Example 3:

Input: obstacles = [3,1,5,6,4,2]
Output: [1,1,2,3,2,2]
Explanation: The longest valid obstacle course at each position is:
- i = 0: [3], [3] has length 1.
- i = 1: [3,1], [1] has length 1.
- i = 2: [3,1,5], [3,5] has length 2. [1,5] is also valid.
- i = 3: [3,1,5,6], [3,5,6] has length 3. [1,5,6] is also valid.
- i = 4: [3,1,5,6,4], [3,4] has length 2. [1,4] is also valid.
- i = 5: [3,1,5,6,4,2], [1,2] has length 2.
 

Constraints:

n == obstacles.length
1 <= n <= 105
1 <= obstacles[i] <= 107
*/

//***************Solution********************
//visualization https://www.youtube.com/watch?v=Xq9VT7p0lic
public class Solution {
    public int[] LongestObstacleCourseAtEachPosition(int[] obstacles) {
        var result = new int[obstacles.Length];
        var lis = new List<int>();

        //loop through obstacles length
        for(int i = 0; i < obstacles.Length; i++){
            //if lis count equal 0 OR current obstacles is greater or equal to the last index of lis
            //add current obstacle to lis, set result i to lis.count
            if (lis.Count == 0 || obstacles[i] >= lis[lis.Count - 1]){
                lis.Add(obstacles[i]);
                result[i] = lis.Count;
            }
            else{
                //get binary index of obstacles i
                var insertPos = lis.BinarySearch(obstacles[i]);

                //if pos is less than 0, bit wise completment index pos, because it return negative if index not found.
                //update lis and result for next iteration
                if (insertPos < 0){
                    lis[~insertPos] = obstacles[i];
                    result[i] = (~insertPos) + 1;
                }
                //if insert pos is not less then 0
                else{
                    //loop while insertpos is less than lis count AND current insert pos index equal to current obstacles
                    //increase insertpos by 1
                    while(insertPos < lis.Count && lis[insertPos] == obstacles[i])
                        insertPos++;

                    //update lis and result for next iteration
                    lis[insertPos] = obstacles[i];
                    result[i] = insertPos + 1;
                }
            }
        }
        return result;
    }
}
