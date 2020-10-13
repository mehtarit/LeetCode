public class Solution {
    public int GetSum(int a, int b) {
        while (b!=0)
        {
            int carryForward = a & b;
            a = a ^ b;
            b = carryForward << 1;
        }

        return a;
        
    }
}