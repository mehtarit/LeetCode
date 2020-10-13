public class Solution {
    public string AddStrings(string num1, string num2) {
        
        if(string.IsNullOrEmpty(num1) || num1=="0") return num2;
        
        if(string.IsNullOrEmpty(num2) || num2=="0") return num1;
        
        var indexNum1 = num1.Length-1;
        var indexNum2 = num2.Length-1;
        
        var largestIndex = Math.Max(indexNum1, indexNum2);
        largestIndex++;
        
        int[] sumArr = new int[largestIndex+1];
        
        var carry = 0;
            
        while(largestIndex >=0){
            
            var first = 0;
            var second = 0;
            var sum = 0;
            
            if(indexNum1 >=0) first = num1[indexNum1]-'0';
            else first = 0;
            
            if(indexNum2 >=0) second = num2[indexNum2]-'0';
            else second =0;
                  
            if(carry != 0) sum = first + second + carry;
            else sum = first + second;
                
            if(sum > 9) {
            carry = sum/10;
            sum = sum %10;                
            }
            else{
                carry = 0;
            } 
            sumArr[largestIndex] = sum;
            largestIndex--;
            indexNum1--;
            indexNum2--;
            
        }
        
        if(sumArr[0] == 0) sumArr = sumArr.Skip(1).ToArray();
        return string.Join("", sumArr);
        
    }
}