/*Challenge link:https://leetcode.com/problems/data-stream-as-disjoint-intervals/description/
Question:
Given a data stream input of non-negative integers a1, a2, ..., an, summarize the numbers seen so far as a list of disjoint intervals.

Implement the SummaryRanges class:

SummaryRanges() Initializes the object with an empty stream.
void addNum(int value) Adds the integer value to the stream.
int[][] getIntervals() Returns a summary of the integers in the stream currently as a list of disjoint intervals [starti, endi]. The answer should be sorted by starti.
 

Example 1:

Input
["SummaryRanges", "addNum", "getIntervals", "addNum", "getIntervals", "addNum", "getIntervals", "addNum", "getIntervals", "addNum", "getIntervals"]
[[], [1], [], [3], [], [7], [], [2], [], [6], []]
Output
[null, null, [[1, 1]], null, [[1, 1], [3, 3]], null, [[1, 1], [3, 3], [7, 7]], null, [[1, 3], [7, 7]], null, [[1, 3], [6, 7]]]

Explanation
SummaryRanges summaryRanges = new SummaryRanges();
summaryRanges.addNum(1);      // arr = [1]
summaryRanges.getIntervals(); // return [[1, 1]]
summaryRanges.addNum(3);      // arr = [1, 3]
summaryRanges.getIntervals(); // return [[1, 1], [3, 3]]
summaryRanges.addNum(7);      // arr = [1, 3, 7]
summaryRanges.getIntervals(); // return [[1, 1], [3, 3], [7, 7]]
summaryRanges.addNum(2);      // arr = [1, 2, 3, 7]
summaryRanges.getIntervals(); // return [[1, 3], [7, 7]]
summaryRanges.addNum(6);      // arr = [1, 2, 3, 6, 7]
summaryRanges.getIntervals(); // return [[1, 3], [6, 7]]
 

Constraints:

0 <= value <= 104
At most 3 * 104 calls will be made to addNum and getIntervals.
At most 102 calls will be made to getIntervals.
 

Follow up: What if there are lots of merges and the number of disjoint intervals is small compared to the size of the data stream?
*/

//***************Solution********************
//The word "intervals" is the source of confusion. They meant, summarize "contiguous numbers" as intervals. Thus, numbers {1, 2, 3, 4, 6, 8, 9} will be summarized as {[1,4], [6,6], [8,9]}

public class SummaryRanges {
    private Dictionary<int, int[]> num;
    private SortedSet<int[]> _intervals;

    private class IntervalComparer : IComparer<int[]>{
        public int Compare(int[]? x, int[]? y) => x[0].CompareTo(y[0]);
    }

    public SummaryRanges(){
        num = new Dictionary<int, int[]>();
        _intervals = new SortedSet<int[]>(new IntervalComparer());
    }

    public void AddNum(int value){
        if (num.ContainsKey(value)) return;

        int[] range;
        if(num.ContainsKey(value - 1)){
            if (num.ContainsKey(value + 1)){
                range = new int[] { num[value - 1][0], num[value + 1][1] };

                for (int i = num[value - 1][0]; i < num[value - 1][1]; i++)
                    num[i] = range;
                for (int i = num[value + 1][0] + 1; i <= num[value + 1][1]; i++)
                    num[i] = range;

                _intervals.Remove(num[value - 1]);
                _intervals.Remove(num[value + 1]);
                _intervals.Add(range);

                num[value - 1] = range;
                num[value + 1] = range;
            }
            else{
                num[value - 1][1] = value;
                range = num[value - 1];
            }
        }
        else if(num.ContainsKey(value + 1)){
            num[value + 1][0] = value;
            range = num[value + 1];
        }
        else{
            range = new[] { value, value };
            _intervals.Add(range);
        }

        num.Add(value, range);
    }

    public int[][] GetIntervals() =>  _intervals.ToArray();
}



/**
 * Your SummaryRanges object will be instantiated and called as such:
 * SummaryRanges obj = new SummaryRanges();
 * obj.AddNum(value);
 * int[][] param_2 = obj.GetIntervals();
 */
