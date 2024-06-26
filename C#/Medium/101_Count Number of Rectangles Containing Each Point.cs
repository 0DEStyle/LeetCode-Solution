/*Challenge link:https://leetcode.com/problems/count-number-of-rectangles-containing-each-point/description/
Question:
You are given a 2D integer array rectangles where rectangles[i] = [li, hi] indicates that ith rectangle has a length of li and a height of hi. You are also given a 2D integer array points where points[j] = [xj, yj] is a point with coordinates (xj, yj).

The ith rectangle has its bottom-left corner point at the coordinates (0, 0) and its top-right corner point at (li, hi).

Return an integer array count of length points.length where count[j] is the number of rectangles that contain the jth point.

The ith rectangle contains the jth point if 0 <= xj <= li and 0 <= yj <= hi. Note that points that lie on the edges of a rectangle are also considered to be contained by that rectangle.

 

Example 1:
//see image in link

Input: rectangles = [[1,2],[2,3],[2,5]], points = [[2,1],[1,4]]
Output: [2,1]
Explanation: 
The first rectangle contains no points.
The second rectangle contains only the point (2, 1).
The third rectangle contains the points (2, 1) and (1, 4).
The number of rectangles that contain the point (2, 1) is 2.
The number of rectangles that contain the point (1, 4) is 1.
Therefore, we return [2, 1].
Example 2:
//see image in link

Input: rectangles = [[1,1],[2,2],[3,3]], points = [[1,3],[1,1]]
Output: [1,3]
Explanation:
The first rectangle contains only the point (1, 1).
The second rectangle contains only the point (1, 1).
The third rectangle contains the points (1, 3) and (1, 1).
The number of rectangles that contain the point (1, 3) is 1.
The number of rectangles that contain the point (1, 1) is 3.
Therefore, we return [1, 3].
 

Constraints:

1 <= rectangles.length, points.length <= 5 * 104
rectangles[i].length == points[j].length == 2
1 <= li, xj <= 109
1 <= hi, yj <= 100
All the rectangles are unique.
All the points are unique.
*/

//***************Solution********************
public class Solution {
    public int[] CountRectangles(int[][] rectangles, int[][] points) {
        //create dictionary based on each y >>>list of x with same y
        //as y constraint is 0 to 100
        var ans= new int[points.Length];
        Dictionary<int,List<int>> d=new();

        //loop through arr in rectangles, add arr[1] and int list to d
        //add index at arr[1] with arr[0]
        foreach(int[] arr in rectangles){
            d.TryAdd(arr[1],new List<int>());
            d[arr[1]].Add(arr[0]);
        }

        //sorting lis of x for each y
        foreach(var v in d)
                d[v.Key].Sort();

        int j = 0;
        foreach(int[] point  in points){
               int count=0;

               //foreach y >=the point y,find the x and filter out x if its small
               for(int i=point[1];i<=100;i++){
                //if dictionary contains current key, binary search index, and increase count.
                if(d.ContainsKey(i)){
                int index=BS(point[0],d[i]);
                count+= d[i].Count-index;
                }
               }
               ans[j]=count;
               j++;
        }
        return ans;
    }

    public int BS(int x, List<int> xList){
        //set boundaries
        int left=0;int right=xList.Count-1;

        while(left<=right){
            //find mid index
            int mid=left+(right-left)/2;
            //if x is less than or equal to list at mid index, shift right to left by 1 index
            //else shift left to right by 1 index.
            if(x<=xList[mid])
               right=mid-1;
            else
                left=mid+1;
        }
        return left;
    }
}
