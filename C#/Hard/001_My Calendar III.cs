/*Challenge link:https://leetcode.com/problems/my-calendar-iii/description/
Question:
A k-booking happens when k events have some non-empty intersection (i.e., there is some time that is common to all k events.)

You are given some events [startTime, endTime), after each given event, return an integer k representing the maximum k-booking between all the previous events.

Implement the MyCalendarThree class:

MyCalendarThree() Initializes the object.
int book(int startTime, int endTime) Returns an integer k representing the largest integer such that there exists a k-booking in the calendar.
 

Example 1:

Input
["MyCalendarThree", "book", "book", "book", "book", "book", "book"]
[[], [10, 20], [50, 60], [10, 40], [5, 15], [5, 10], [25, 55]]
Output
[null, 1, 1, 2, 3, 3, 3]

Explanation
MyCalendarThree myCalendarThree = new MyCalendarThree();
myCalendarThree.book(10, 20); // return 1
myCalendarThree.book(50, 60); // return 1
myCalendarThree.book(10, 40); // return 2
myCalendarThree.book(5, 15); // return 3
myCalendarThree.book(5, 10); // return 3
myCalendarThree.book(25, 55); // return 3

 

Constraints:

0 <= startTime < endTime <= 109
At most 400 calls will be made to book.
*/

//***************Solution********************

//900ms
 public class MyCalendarThree{
            SortedDictionary<int, int> values;
            public MyCalendarThree(){
                values = new SortedDictionary<int, int>();
            }

            public int Book(int start, int end){
                int currBooking = 0;
                int maxBooking = 0;
                if (values.ContainsKey(start))
                    values[start]++;
                else
                    values.Add(start, 1);   
                if (values.ContainsKey(end))
                    values[end]--;
                else
                    values.Add(end, -1);
                foreach (int t in values.Values){
                    currBooking += t;
                    maxBooking = Math.Max(maxBooking, currBooking);
                }
                return maxBooking;
            }
        }

//slow method 2000ms
public class MyCalendarThree {
    private SortedDictionary<int, int> tree;

    //set new sorted dictionary int int to tree
    public MyCalendarThree() {
        tree = new SortedDictionary<int, int>();
    }
    
    public int Book(int start, int end) {
        //set start and end of tree via index
        tree[start] = tree.GetValueOrDefault(start, 0) + 1;
        tree[end] = tree.GetValueOrDefault(end, 0) - 1;

        int val = 0, max = 0;
        //loop through all key in tree.keys
        //increase val by current tree key
        //select max between val and max, set to max.
        foreach (var key in tree.Keys){
            val += tree[key];
            max = System.Math.Max(val, max);
        }
        return max;
    }

}
/**
 * Your MyCalendarThree object will be instantiated and called as such:
 * MyCalendarThree obj = new MyCalendarThree();
 * int param_1 = obj.Book(startTime,endTime);
 */

