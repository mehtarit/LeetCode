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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        
                
        var resultHead = new ListNode(0,null);
        var result = resultHead;
        
        var carry = 0;
                
        while(l1 !=null || l2 !=null){
         
          int l1Val;
          int l2Val;
            
           if(l1 == null) l1Val = 0;
           else l1Val = l1.val;
            
           if(l2 == null) l2Val = 0;
           else l2Val = l2.val;
            
          var sum = l1Val + l2Val + carry;
          if(sum > 9) {              
              carry = sum/10;
              sum = sum%10; 
          }
          else carry = 0;
            
          var current = new ListNode(sum, null);
          result.next = current;
          result = result.next;  
          
          if(l1 !=null) l1=l1.next;
          if(l2 != null) l2 = l2.next;
            
        }
        
        if(carry == 0) return resultHead.next;
        else {
            var last = new ListNode(carry, null);
            result.next =last;
            result = result.next;
            return resultHead.next;
        }
        
    }
}