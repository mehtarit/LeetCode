public class Solution {
    public string RemoveDuplicates(string S) {
    
        var stack = new Stack<char>();
        
        foreach(var c in S){
            if(stack.Count == 0) stack.Push(c);
            else if(stack.Peek() != c) stack.Push(c);
            else stack.Pop();
        }
        
        var result = new char[stack.Count];
        
        for(int i = stack.Count -1; i>=0; i--){
            result[i] = stack.Pop();
        }
        
        return new string(result);
        
    }
}