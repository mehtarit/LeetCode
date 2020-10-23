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
    
    int maxSum = Int32.MinValue;
    public int MaxPathSum(TreeNode root) {
        
        maxGain(root);        
        return maxSum;
        
    }
    
    public int maxGain(TreeNode node){
        
        if(node == null) return 0;
        
        int left_gain = Math.Max(maxGain(node.left), 0);
        int right_gain = Math.Max(maxGain(node.right), 0);
        
        int price_newpath = node.val + left_gain + right_gain;
        
        maxSum = Math.Max(maxSum, price_newpath);
        
        return node.val + Math.Max(left_gain, right_gain);
        
        
    }
}