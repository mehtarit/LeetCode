public class Solution {
    
    public int CalculateArea(int x1, int y1, int x2, int y2){
        
        return Math.Abs(x2 - x1)*Math.Abs(y2-y1);
        
    }
    
    public int MinAreaRect(int[][] points) {
        
        var set = new HashSet<Tuple<int,int>>();
        
        foreach(var pair in points){
            set.Add(Tuple.Create(pair[0], pair[1]));
        }
        
        var minArea = Int32.MaxValue;
        
        for(int i = 0; i < points.Length; i++){
            int x1 = points[i][0];
            int y1 = points[i][1];
                              
            for(int j = 0; j < points.Length; j++){
                var x2 = points[j][0];
                var y2 = points[j][1];
                
                if(x1 == x2 || y1 == y2) continue;
                
                var diag1 = Tuple.Create(x1,y2);
                var diag2 = Tuple.Create(x2, y1);
                
                if(set.Contains(diag1) && set.Contains(diag2)){
                    var area = CalculateArea(x1, y1, x2, y2);
                    if(area < minArea) minArea = area;
                }                
                
            }                              
            
        }
        
        if(minArea == Int32.MaxValue) return 0;                     
        else return minArea;
        
    }
}