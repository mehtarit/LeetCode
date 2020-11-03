public class Solution {
    public bool IsStrobogrammatic(string num) {
                
        var cArr = num.ToCharArray();
        
        for(int i = 0; i < cArr.Length; i++)
        {
            int n = cArr[i]-'0';
            
            if(n == 2 || n == 3 || n ==4 || n==5 || n == 7) return false;
            
            if(n == 6) cArr[i] = '9';
            if(n == 9) cArr[i] = '6';
        }
        
        var upsideDownNum = new string(cArr.Reverse().ToArray());
        return num.Equals(upsideDownNum);
    }
}