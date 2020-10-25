public class Solution {
    public string DecodeString(string s) {
        
        var counts = new Stack<int>();
        var result = new Stack<string>();
        string current = "";
        int index = 0;
        
        while(index < s.Length){
            
            if(Char.IsDigit(s[index])){
                
                int count = 0;
                while(Char.IsDigit(s[index])){
                    count = count*10 + (s[index] - '0');
                    index++;
                }
                
                counts.Push(count);
            }
            
            else if(s[index] == '[') {
                
                result.Push(current);
                current = "";
                index++;
            }
            
            else if(s[index] == ']'){
                
                StringBuilder temp = new StringBuilder(result.Pop());
                int count = counts.Pop();
                for(int i = 0; i < count; i++){
                    temp.Append(current);
                }
                current = temp.ToString();
                index++;
            }
            
            else {
                
                current = current+s[index];
                index++;
                
            }
            
        }
        
        return current;
        
    }
}