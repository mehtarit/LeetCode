/*
// Definition for a Node.
public class Node {
    public int val;
    public Node prev;
    public Node next;
    public Node child;
}
*/

public class Solution {
    public Node Flatten(Node head) {
        

        var nodeStack = new Stack<Node>();        
        var current = head; 
        
        while(current != null){
            if(current.child != null){
                nodeStack.Push(current.next);
                current.next = current.child;
                current.next.prev = current;
                current.child = null;
            }
            else if(current.next == null){
                if(nodeStack.Count == 0) break;
               var future = nodeStack.Pop();
                current.next = future;
                if(current.next != null)
                current.next.prev = current;
            }
            current = current.next;            
        }
        
        return head;
    }
}