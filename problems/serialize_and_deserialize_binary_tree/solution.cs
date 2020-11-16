/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {
    
    public void Serialize(TreeNode node, List<string> result){
        
        if(node == null) {
            result.Add("null");
            return;
        }
        
        result.Add(node.val.ToString());
        Serialize(node.left, result);
        Serialize(node.right, result);
    }

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        
        List<string> result = new List<string>();      
        Serialize(root, result);  
        var str = String.Join(',', result.ToArray());
        return str;
        
    }
    
    public void Deserialize(ref TreeNode node, Queue<string> q)
    {
        if(q.Count == 0) return;
        
        var front = q.Dequeue();
        if(front == "null") {
            node = null;
            return;
        }
        
        node = new TreeNode(Convert.ToInt32(front));
        Deserialize(ref node.left, q);
        Deserialize(ref node.right, q);
        
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        
        var dataStr = data.Split(',');
        var queue = new Queue<string>(dataStr);
        TreeNode root = new TreeNode();
        
        Deserialize(ref root, queue);
        return root;
        
    }
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));