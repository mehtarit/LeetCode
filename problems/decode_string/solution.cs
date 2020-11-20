public class Solution {
    public string DecodeString(string s) {
        
        var counts = new Stack<int>();
        var codes = new Stack<string>();
        
        int index = 0;
        string result = "";
        
        while(index < s.Length)
        {
            var current = s[index];
            
            if(Char.IsNumber(current)){
                int previousDigit = 0;
                int number = 0;
                while(Char.IsNumber(current))
                {
                    number = 10*previousDigit + (current-'0');
                    previousDigit = number;
                    index++;
                    current = s[index];
                }
                counts.Push(number);
            }
            else if(current == '['){
                codes.Push(result);
                result="";
                index++;
                
            }
            else if(current == ']'){
                string temp = codes.Pop();              
                int count = counts.Pop();
                for(int i = 0; i < count; i++){
                    temp = temp + result;
                }
                result = temp;
                index++;               
            }
            else {
                result = result + Char.ToString(current);
                index++;                
            }
            
        }
        
        return result;
    }
}