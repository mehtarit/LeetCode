public class Solution {
    public int[] PlusOne(int[] digits) {
        
        var index = digits.Length-1;        
        var carry = -1;
        
        while(index >=0){ 
            
            var sum = 0;
            if(carry != -1) sum = digits[index] + carry;
            else sum = digits[index]+1;
            carry = sum/10;
            
            if(sum > 9) sum = sum %10;
            digits[index] = sum;
            index--;
        }
        
        if(carry != 0) {
            var result = new int[digits.Length + 1];
            result[0] = carry;
            Array.Copy(digits, 0, result, 1, digits.Length);
            return result;
        }
        
        return digits;
        
    }
}