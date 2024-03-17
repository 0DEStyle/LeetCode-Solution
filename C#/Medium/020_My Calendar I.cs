/*Challenge link:https://leetcode.com/problems/my-calendar-i/description/
Question:
You are implementing a program to use as your calendar. We can add a new event if adding the event will not cause a double booking.

A double booking happens when two events have some non-empty intersection (i.e., some moment is common to both events.).

The event can be represented as a pair of integers start and end that represents a booking on the half-open interval [start, end), the range of real numbers x such that start <= x < end.

Implement the MyCalendar class:

MyCalendar() Initializes the calendar object.
boolean book(int start, int end) Returns true if the event can be added to the calendar successfully without causing a double booking. Otherwise, return false and do not add the event to the calendar.
 

Example 1:

Input
["MyCalendar", "book", "book", "book"]
[[], [10, 20], [15, 25], [20, 30]]
Output
[null, true, false, true]

Explanation
MyCalendar myCalendar = new MyCalendar();
myCalendar.book(10, 20); // return True
myCalendar.book(15, 25); // return False, It can not be booked because time 15 is already booked by another event.
myCalendar.book(20, 30); // return True, The event can be booked, as the first event takes every time less than 20, but not including 20.
 

Constraints:

0 <= start < end <= 109
At most 1000 calls will be made to book.
*/

//***************Solution********************
//binary search
public class MyCalendar {
    //global sorted list events (int, int)
    SortedList<int,int> events;

    public MyCalendar() {
        events = new();
    }

    //check for intersection and return a bool value
    private bool isTimeIntersected(int start, int end, int eventStart, int eventEnd)
    => (start >= eventStart && start < eventEnd) || (start< eventStart && end > eventStart);

    public bool Book(int start, int end) {
        //set lower and upper bound.
        int low = 0, high = events.Count-1;

        while(low <= high){
            //find mid index, set start time as events.Keys[mid], set eEnd time with events[eStartTime]
            int mid = high + (low - high) / 2;
            int eStartTime = events.Keys[mid]; 
            int eEndTime = events[eStartTime];

            //check validation
            if(isTimeIntersected(start, end, eStartTime, eEndTime))
                return false;
            //shift low to right by 1 index, else shift high to left by 1 index.
            if(start > eStartTime)
                low = mid +1;
            else
                high = mid - 1;           
        }
        //add new event
        events.Add(start,end);
        return true;
    }
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */
