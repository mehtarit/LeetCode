public class Solution {
    public int LongestConsecutive(int[] nums) {
        
        var set = new HashSet<int>();
        
        foreach(var num in nums){
            
            if(!set.Contains(num)) set.Add(num);
        }
        
        var longestStreak = 0;
        
        foreach(var num in nums){
            
            if(set.Contains(num-1)) continue;
            
            int current = num;
            int currentStreak = 1;
            
            while(set.Contains(current+1)){
                current +=1;
                currentStreak +=1;
                
            }
            
            longestStreak = Math.Max(longestStreak, currentStreak);
            
        }
        
        return longestStreak;
        
    }
}