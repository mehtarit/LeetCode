public class Solution {
    public bool Overlaps(Tuple<int, int> first, Tuple<int,int> second){
        
        return (second.Item1 >= first.Item1 && second.Item1 <= first.Item2)
           || (second.Item2 >= first.Item1 && second.Item2 <= first.Item2);
   
    }
    
    public Tuple<int,int> CombinedInterval(Tuple<int,int> first, Tuple<int,int> second){
        
        var item1 = Math.Min(Math.Min(first.Item1, first.Item2), Math.Min(second.Item1, second.Item2));
        var item2 = Math.Max(Math.Max(first.Item1, first.Item2), Math.Max(second.Item1, second.Item2));
        
        return Tuple.Create(item1, item2);
    }
    
    public int[][] Merge(List<Tuple<int,int>> intervalTuples) {
                                
        var index =1;
        Tuple<int,int> current;
        Tuple<int,int> previous = intervalTuples[0];
        
        var result = new List<Tuple<int,int>>();
        
        while(index < intervalTuples.Count){
        
            current =intervalTuples[index];  
            if(Overlaps(previous, current)){ 
                previous = CombinedInterval(current, previous);
                index++;  
                continue;
            }
            result.Add(previous);
            previous = current;
            index++;           
        }
        
        result.Add(previous);
        
        var resultArray = new int[result.Count][];
        for(int i = 0; i < resultArray.Length; i++)
        {
            resultArray[i] = new int[2];
            resultArray[i][0] = result[i].Item1;
            resultArray[i][1] = result[i].Item2;
        }
        
        return resultArray;
        
             
    }
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        
    var intervalTuples = new List<Tuple<int,int>>();
        
        bool isInserted = false;
        
        for(int i = 0; i < intervals.Length; i++){
            var first = intervals[i][0];
            var second = intervals[i][1];
            if(!isInserted && first > newInterval[0]){
                
                intervalTuples.Add(Tuple.Create(newInterval[0], newInterval[1]));
                isInserted = true;
            }
            intervalTuples.Add(Tuple.Create(first, second));          
        }
        
        if(!isInserted) intervalTuples.Add(Tuple.Create(newInterval[0], newInterval[1]));
    
        return Merge(intervalTuples);  
    }
}