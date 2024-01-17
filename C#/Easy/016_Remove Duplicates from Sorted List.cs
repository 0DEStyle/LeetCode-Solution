/*Challenge link:https://leetcode.com/problems/remove-duplicates-from-sorted-list/description/
Question:
Given the head of a sorted linked list, delete all duplicates such that each element appears only once. Return the linked list sorted as well.

 //see image in link

Example 1:

 //see image in link

Input: head = [1,1,2]
Output: [1,2]
Example 2:


Input: head = [1,1,2,3,3]
Output: [1,2,3]
 

Constraints:

The number of nodes in the list is in the range [0, 300].
-100 <= Node.val <= 100
The list is guaranteed to be sorted in ascending order.
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
    public ListNode DeleteDuplicates(ListNode head) {
        //validation check
        if(head == null) return null;
        if(head.next == null) return head;

        //current ListNode set as head
        ListNode curr = head;

        //print out ListNode
        //node can be accessed by use head.next.next.val
        //for(ListNode i = head; i != null; i = i.next) Console.Write(i.val + ",");

        //iterate through each node in head
        //if current the val of i and curr node are the same, set the next node as i.next
        //else set curr as i
        for(ListNode i = head.next; i != null; i = i.next){
            if(i.val == curr.val)
                curr.next = i.next;
            else
                curr = i;
        }
        return head;
    }
}
