public class Solution {
    
    public bool IsPalindrome(string current){
        for (int i = 0; i < current.Length / 2; i++)
        {
            if (current[i] != current[current.Length - i - 1])
            return false;
        }
        return true;
    }
    
    public string LongestPalindrome(string s) {
        
        var window = s.Length;
        
        while(window != 0){
            
            for(int i = 0; i + window -1 < s.Length; i++){
                var current = s.Substring(i, window);
               // Console.WriteLine($"Current is {current}");
                if(IsPalindrome(current)) return current;
            }
            window--;
            
        }
        
        return s[0].ToString();
        
    }
}