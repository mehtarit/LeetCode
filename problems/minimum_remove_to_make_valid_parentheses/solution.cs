public class Solution {
    public string MinRemoveToMakeValid(string s) {
        
        var sArray = new Char[s.Length];
        for(int i = 0; i < s.Length; i++){
            sArray[i] = s[i];
        }
        
        var bracketStack = new Stack<KeyValuePair<char, int>>();
        
        for(int i = 0; i < sArray.Length; i++)
        {
            var current = sArray[i];
            if(current == '(')
                bracketStack.Push(new KeyValuePair<char, int>(')', i));
            if(current == ')'){
                if(bracketStack.Count == 0) {
                    bracketStack.Push(new KeyValuePair<char, int>('(',i));
                    continue;
                }
                var topBracket = bracketStack.Peek();
                if(topBracket.Key == current) bracketStack.Pop();
                else bracketStack.Push(new KeyValuePair<char, int>('(',i));               
            }          
        }
        
        
        
        if(bracketStack.Count == 0) return s;
        
        while(bracketStack.Count !=0){
            var topBracket = bracketStack.Peek();
            bracketStack.Pop();
            s = s.Remove(topBracket.Value, 1);
        }
        
        return s;
        
    }
}