/*Challenge link:https://leetcode.com/problems/palindrome-linked-list/description/
Question:
Given the head of a singly linked list, return true if it is a 
palindrome
 or false otherwise.

 

Example 1:


Input: head = [1,2,2,1]
Output: true
Example 2:


Input: head = [1,2]
Output: false
 

Constraints:

The number of nodes in the list is in the range [1, 105].
0 <= Node.val <= 9
 

Follow up: Could you do it in O(n) time and O(1) space?
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
    public bool IsPalindrome(ListNode head) {
        ListNode slow = head, fast = head, prev = null;

        //reverse first half of the list
        while (fast != null && fast.next != null){
            fast = fast.next.next;
            ListNode next = slow.next;
            slow.next = prev;
            prev = slow;
            slow = next;
        }

        //if list has odd number of elements skip middle element
        if (fast != null)
            slow = slow.next;
        
        //compare first and second half of the list
        while (slow != null){
            if (slow.val != prev.val)
                return false;

            slow = slow.next;
            prev = prev.next;
        }

        return true;
    }
}
