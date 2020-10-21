/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        
        if(root == null) return null;
        
        if(root==p || root == q) return root;
        
        var left_lca = LowestCommonAncestor(root.left, p, q);
        var right_lca = LowestCommonAncestor(root.right, p, q);
        
        if(left_lca != null && right_lca !=null) return root;
        
        if(left_lca != null) return left_lca;
        else return right_lca;
        
    }
}