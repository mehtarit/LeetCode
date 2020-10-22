/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        
        return helper(0, 0, inorder.Length-1, preorder, inorder);
        
    }
    
    public TreeNode helper(int preStart, int inStart, int inEnd, int[] preorder, int[] inorder)
    {
        if(preStart > preorder.Length-1 || inStart > inEnd) return null;
        
        var root = new TreeNode(preorder[preStart]);
        
        var inIndex = 0;
        
        for(int i = inStart; i <=inEnd; i++){
            if(root.val == inorder[i])
                inIndex=i;
        }
        
        root.left = helper(preStart+1, inStart, inIndex-1, preorder, inorder);
        root.right = helper(preStart + inIndex - inStart + 1, inIndex+1, inEnd, preorder, inorder);
        
        return root;
    }
}