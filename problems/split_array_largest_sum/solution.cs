public class Solution {
    
    public bool IsPossibleSolution(int mid, int[] nums, int m){
        
        int count = 1;
        int sum = 0;
        
        foreach(var n in nums){
            
            if(n > mid) return false;
            
            sum = sum+n;
            if(sum <= mid) continue;
            count++;
            sum = n;
        } 
        
        return count <= m;
    }
    
    public int SplitArray(int[] nums, int m) {
        
        int n = nums.Length;
        int start = 1;
        int end = nums.Sum();
        
        int answer = 0;
        
        while(start <= end){
            
            var mid = (start + end)/2;
            if(IsPossibleSolution(mid, nums, m)){
                answer = mid;
                end = mid-1;
                continue;
            }
            start = mid+1;
        }
        
        return answer;      
    }   
}


    