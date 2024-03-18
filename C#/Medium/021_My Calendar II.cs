/*Challenge link:https://leetcode.com/problems/my-calendar-ii/description/
Question:
You are implementing a program to use as your calendar. We can add a new event if adding the event will not cause a triple booking.

A triple booking happens when three events have some non-empty intersection (i.e., some moment is common to all the three events.).

The event can be represented as a pair of integers start and end that represents a booking on the half-open interval [start, end), the range of real numbers x such that start <= x < end.

Implement the MyCalendarTwo class:

MyCalendarTwo() Initializes the calendar object.
boolean book(int start, int end) Returns true if the event can be added to the calendar successfully without causing a triple booking. Otherwise, return false and do not add the event to the calendar.
 

Example 1:

Input
["MyCalendarTwo", "book", "book", "book", "book", "book", "book"]
[[], [10, 20], [50, 60], [10, 40], [5, 15], [5, 10], [25, 55]]
Output
[null, true, true, true, false, true, true]

Explanation
MyCalendarTwo myCalendarTwo = new MyCalendarTwo();
myCalendarTwo.book(10, 20); // return True, The event can be booked. 
myCalendarTwo.book(50, 60); // return True, The event can be booked. 
myCalendarTwo.book(10, 40); // return True, The event can be double booked. 
myCalendarTwo.book(5, 15);  // return False, The event cannot be booked, because it would result in a triple booking.
myCalendarTwo.book(5, 10); // return True, The event can be booked, as it does not use time 10 which is already double booked.
myCalendarTwo.book(25, 55); // return True, The event can be booked, as the time in [25, 40) will be double booked with the third event, the time [40, 50) will be single booked, and the time [50, 55) will be double booked with the second event.
 

Constraints:

0 <= start < end <= 109
At most 1000 calls will be made to book.
*/

//***************Solution********************
//Segment tree method
public class MyCalendarTwo {
  public class Node{

    public int start, mid, end, count;
    public Node left, right;

    //setting node to start, mid, end, and count
    public Node(int s, int e, int c){
            start = s;
            mid = -1;
            end = e;
            count = c;
        }
    }

    //root, start 0, end 1000000000, count 0
    public Node root;
    public MyCalendarTwo() {
        root = new Node(0, 1000000000, 0);
    }

    //if query is greater than 1, return false
    //else add the start, end root and return true
    public bool Book(int start, int end) {
        if(Query(start, end, root) > 1) return false;
        else Add(start, end, root);
            return true;
    }
    

    int Query(int start, int end, Node root){
        //if mid root is not equal to -1
        //if start is >= to mid root, pass root.right into Query
        //else if end is <= mid root, pass root.left into Query
        //else nothing matches, return the Max value betweeen root.left and root.right from Query.
        if(root.mid != -1){
            if(start >= root.mid) return Query(start, end, root.right);
            else if(end <= root.mid) return Query(start, end, root.left);
            else return Math.Max(Query(start, root.mid, root.left), Query(root.mid, end, root.right));
        }
        //if start is >= to root.start OR end is less than root.end, return root.Count
        //else return 0
        if(start >= root.start || end <= root.end) return root.count;
        else return 0;
    }

    void Add(int start, int end, Node root){
        //if root.mid is not equal to -1
        if(root.mid != -1){
            if(start >= root.mid) Add(start, end, root.right);
            else if(end <= root.mid) Add(start, end, root.left);
            else{
                Add(start, root.mid, root.left);
                Add(root.mid, end, root.right);
            }
            return;
        }

        //if within boundary, increase root.count by 1
        if(start == root.start && end == root.end) root.count++;

        //if start is equal to root.start
        else if(start == root.start){
            root.mid = end;
            root.left = new Node(start, end, root.count+1);
            root.right = new Node(end, root.end, root.count);
        }
        //if end is equal to root.end
        else if(end == root.end){
            root.mid = start;
            root.left = new Node(root.start, start, root.count);
            root.right = new Node(start, end, root.count+1);
        }
        else{
            root.mid = start;
            root.left = new Node(root.start, root.mid, root.count);
            root.right = new Node(root.mid, root.end, root.count);
            Add(start, end, root.right);
        }
    }
}

/**
 * Your MyCalendarTwo object will be instantiated and called as such:
 * MyCalendarTwo obj = new MyCalendarTwo();
 * bool param_1 = obj.Book(start,end);
 */
