/*Challenge link:https://leetcode.com/problems/reverse-linked-list/description/
Question:
Given the head of a singly linked list, reverse the list, and return the reversed list.

 

Example 1:
//see image in link

Input: head = [1,2,3,4,5]
Output: [5,4,3,2,1]
Example 2:
//see image in link

Input: head = [1,2]
Output: [2,1]
Example 3:

Input: head = []
Output: []
 

Constraints:

The number of nodes in the list is the range [0, 5000].
-5000 <= Node.val <= 5000
 

Follow up: A linked list can be reversed either iteratively or recursively. Could you implement both?
*/

//***************Solution********************
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode ReverseList(ListNode head) {
        ListNode prev = null, current = head, nextNode = null;
        
        while (current != null) {
            nextNode = current.next; // Save the next node
            current.next = prev; // Reverse the link
            prev = current; // Move pointers one position ahead
            current = nextNode;
        }
        // 'prev' now points to the new head of the reversed list
        return prev;
    }
}
