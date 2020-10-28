public class Solution {
    public int LargestValsFromLabels(int[] values, int[] labels, int num_wanted, int use_limit) {
        
        var indexMap = new List<Tuple<int,int>>();
        
        for(int i = 0; i <values.Length; i++){
            
            indexMap.Add(Tuple.Create(values[i], labels[i]));            
        }
        
        indexMap = indexMap.OrderByDescending(x=>x.Item1).ToList();
        
        var labelMap = new Dictionary<int, int>();
        
        foreach(var label in labels){
            if(!labelMap.ContainsKey(label)) labelMap.Add(label, 0);
        }
        
        int sum = 0; 
        int numTotal = 0;
        
        int index = 0;
        
        while(numTotal < num_wanted && index < values.Length){
            
            var current = indexMap[index];
            //Console.WriteLine("current.Item1 is " + current.Item1);
            if(labelMap[current.Item2] >= use_limit){
                index++;
                continue;
            }
            numTotal++;
            sum = sum + current.Item1;
            labelMap[current.Item2]++;
            index++;
        }
        
        return sum;
        
    }
}