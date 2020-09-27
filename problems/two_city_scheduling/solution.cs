
public class Solution {
    
  public int[] CreateDifferenceArray(int[][] costs, int[] pickedCity){
       int [] diffArray = new int[costs.Length];
      for(int i = 0; i < costs.Length; i++){
          var current = costs[i];
          var pickedIndex = pickedCity[i];
          var diffIndex = 1-pickedIndex;
          var difference = System.Math.Abs(current[pickedIndex] - current[diffIndex]);
          diffArray[i] = difference;
      }
      
      return diffArray;
   }
    
    int sum = 0;
    
    public int CalculateMinimumCost(int[][] costs, int[] pickedCity){
        for(int i =0; i< costs.Length; i++){
            var current = costs[i];
            var index = pickedCity[i];
            sum = sum + current[index];
        }
        
        return sum;
    }

    public int GetArgMin(int[] cost)
    {
        int minValue = Int32.MaxValue;
        int argmin = 0;
        for(int i = 0; i < cost.Length; i++){
            if(cost[i] < minValue){
                minValue = cost[i];
                argmin = i;
            }
        }
        
        return argmin;
    }
    
    public int FindArgMinDifference(int[] pickedArray, int[]difference, int index){
    
    int minValue = Int32.MaxValue;
    int argmin = 0;
    for(int i = 0; i < difference.Length; i++)
    {
        if(pickedArray[i] != index) continue;
        if(difference[i] < minValue){
            minValue = difference[i];
            argmin = i;
            
        } 
    }
    
    return argmin;
    
    }
    
    public void CreateNewPickedArray(int start, int end, int [] pickedArray, int[] difference, int index){
    for(int i = start; i < end; i++){
      int minDiffIndex = FindArgMinDifference(pickedArray, difference, index);
      pickedArray[minDiffIndex] = 1-index;
        }
    }
    public int TwoCitySchedCost(int[][] costs) {
        
        int[] pickedCity = new int[costs.Length];
        
        for(int i = 0; i < costs.Length; i++){
            pickedCity[i] = GetArgMin(costs[i]);
        }
        
        int sum = pickedCity.Sum();
        int expectedSum = costs.Length/2;
        
        if(sum == expectedSum) return CalculateMinimumCost(costs, pickedCity);
        
        int[] differenceArray = CreateDifferenceArray(costs, pickedCity);
        
        if(sum > expectedSum){
             CreateNewPickedArray(expectedSum, sum, pickedCity, differenceArray, 1);
        }
        else {
            CreateNewPickedArray(sum, expectedSum, pickedCity, differenceArray, 0);
        }
        
        return CalculateMinimumCost(costs, pickedCity);        
    }
}