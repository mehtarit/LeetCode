/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */

public class Solution {
    
    public int FindLength(ListNode node){
        var length = 0;
        
        if(node == null) return length;
        while(node !=null){
            node=node.next;
            length++;
        }
        
        return length;
    }
    
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        
        var currentA = headA;
        var lengthA = FindLength(currentA);
        var currentB = headB;
        var lengthB = FindLength(currentB);
        
        var diff = 0;
        
        if(lengthA > lengthB) {
            
            diff = lengthA-lengthB;
            int i = 0;
            while(i < diff){
                headA=headA.next;
                i++;
            }
            
        }
        
        if(lengthB > lengthA) {
            
            diff = lengthB-lengthA; 
            int i = 0;
            while(i < diff){
                headB=headB.next;
                i++;
            }
        }
        
        while(headA !=null){
            
            if(headA == headB) return headA;
            headA=headA.next;
            headB=headB.next;
        }
        
        return null;

    }
}