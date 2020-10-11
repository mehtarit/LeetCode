public class Solution {
    public int NumIslands(char[][] grid) {
        
        var islandCount = 0;
        
        var q = new Queue<Tuple<int, int>>();
        
        for(int i = 0; i <grid.Length; i++){
            for(int j = 0; j<grid[i].Length; j++){
                var current = grid[i][j];
                            
                if (current == '1'){
                    
                    q.Enqueue(Tuple.Create(i, j));                    
                }
                
                if(current == '0') continue;
                
                while(q.Count != 0){
                    
                    var front = q.Dequeue();
                    grid[front.Item1][front.Item2] = '0'; //visited
                    var around = new List<Tuple<int, int>>();
                    around.Add(Tuple.Create(front.Item1+1, front.Item2)); //up
                    around.Add(Tuple.Create(front.Item1-1, front.Item2)); //down;
                    around.Add(Tuple.Create(front.Item1, front.Item2+1)); //right
                    around.Add(Tuple.Create(front.Item1, front.Item2-1)); //left
                    
                    foreach(var tuple in around){
                        if(tuple.Item1 < 0 || tuple.Item1 >= grid.Length) continue;
                        if(tuple.Item2 < 0 || tuple.Item2 >= grid[i].Length) continue;
                        if(grid[tuple.Item1][tuple.Item2] == '1') {
                            q.Enqueue(tuple);
                            grid[tuple.Item1][tuple.Item2] = '0';
                        }
                        
                    }                 
                }
                
                islandCount++;
                        
            }
        }
        
        return islandCount;
        
    }
}