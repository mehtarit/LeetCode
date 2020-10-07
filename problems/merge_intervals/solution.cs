public class Solution {
    
    public int[] Merge(int min, int max, int[] interval){
        int[] values = new int[4];
        values[0] = min;
        values[1] = max;
        values[2]= interval[0];
        values[3] = interval[1];
        
        int [] result = new int[2];
        //Console.WriteLine("min and max vals are: " + values.Min() + " " + values.Max());
        result[0] = values.Min();
        result[1] = values.Max();
        return result;
    }
        
    public int[][] Merge(int[][] intervals) {
        
        if(intervals.Length < 2) return intervals;
        
        Array.Sort(intervals, (arr1, arr2) => arr1[0].CompareTo(arr2[0]));
        
        var index = 0;
        var min = intervals[index][0]; //1
        var max = intervals[index][1]; //3
        
        var result = new List<Tuple<int,int>>();
        
        while(index < intervals.Length){
            
            if(max >= intervals[index][0]) {
                var mergedInterval = Merge(min, max, intervals[index]);
                min = mergedInterval[0]; //1
                max = mergedInterval[1]; //6
            }
            else{
                Console.WriteLine("Adding tuple: " + min + " " + max);
                result.Add(Tuple.Create(min, max));  
                min = intervals[index][0];//8
                max = intervals[index][1];//10
            }
            
            index++;
        }
        
        result.Add(Tuple.Create(min, max));
        
        
        var answer = new int[result.Count][];
        for(int i =0; i < result.Count; i++){
            answer[i] = new int[2];
            answer[i][0] = result[i].Item1;
            answer[i][1] = result[i].Item2;
        }
        
        return answer;
    }
}