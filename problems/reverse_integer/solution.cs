public class Solution {
    public int Reverse(int x) {
        
        int start = 0;
        bool isNegative = false;
        if(x < 0) {
            start = 1;
        isNegative = true;}
        var xString = Convert.ToString(x);
        
        Console.WriteLine($"xString is {x}");
        
        var res = new LinkedList<int>();
        
        for(int i = start; i < xString.Length; i++){
            res.AddFirst(xString[i]-'0');
        }
        
        var resArr = res.ToArray();
        var result = 0;
        var count = 0;
        for(int i =resArr.Length-1; i>=0; i--)
        {
            var d = (int)Math.Pow((double)10, (double)count);
            var current = resArr[i];
            var temp = result;
            result = current*d;
            
            //check for integer overflow
            if(result/d != current) return 0;
            if(result > 0 && temp > Int32.MaxValue - result) return 0;
            
            result = result + temp;
            count++;
        }
        if(isNegative) result = result*-1;
        
        return result;
        
        
    }
}