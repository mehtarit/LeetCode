public class Solution {
    public int RomanToInt(string s) {
        
        var map = new Dictionary<char,int>();
        
        map.Add('I', 1);
        map.Add('V', 5);
        map.Add('X', 10);
        map.Add('L', 50);
        map.Add('C', 100);
        map.Add('D', 500);
        map.Add('M', 1000);
        
        var intArr = new int[s.Length];
        
        for(int i = 0; i < s.Length; i++)
        {
            intArr[i] = map[s[i]];
        }
        
        var sum = intArr[s.Length-1];
        
        for(int i = s.Length-2; i >=0; i--){
            
            var current = intArr[i];
            var previous = intArr[i+1];
            
            if(current >= previous) sum = sum + current;
            
            else sum = sum - current;
            
        }
            
        
        return sum;
    }
}