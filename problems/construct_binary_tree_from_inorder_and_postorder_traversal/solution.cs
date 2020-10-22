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
    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        
        return helper(postorder.Length-1, 0, inorder.Length-1, inorder, postorder);
        
    }
    
    public TreeNode helper(int postEnd, int inStart, int inEnd, int[] inorder, int[] postorder){
        
        if(postEnd < 0 || inStart > inEnd) return null;
        
        var root = new TreeNode(postorder[postEnd]);
        
        var inIndex = 0;
        for(int i = inStart; i <= inEnd; i++){
            if(root.val == inorder[i])
                inIndex=i;
        }
        
        root.left = helper(postEnd-(inEnd-inIndex)-1, inStart, inIndex-1, inorder, postorder);
        root.right = helper(postEnd-1, inIndex+1, inEnd, inorder, postorder);
        
        
        return root;
    }
}