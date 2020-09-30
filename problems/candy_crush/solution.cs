public static class Extensions {
    public static void Add(this HashSet<Tuple<int, int>> set, List<Tuple<int, int>> listOfPairs){
        foreach(var pair in listOfPairs){
            if(!set.Contains(pair)) set.Add(pair);
        }
    }
}

public class Solution {
    
    public void CrushCandies(int[][] board, HashSet<Tuple<int, int>> candiesToCrush){
        
        int rowCount = board.Length;
        int columnCount = board[0].Length;
        
        for(int j=0; j< columnCount; j++){
            var bottom = rowCount-1;
            var top = bottom;
            
            while(top >=0)
            {
                if(!candiesToCrush.Contains(Tuple.Create(top, j)))
                {
                    board[bottom][j] = board[top][j];
                    bottom--;
                }
                top --;                
            }
            
            while (bottom != top){
                board[bottom][j] = 0;
                bottom--;
            }
            
            }
        }
    
    public HashSet<Tuple<int,int>> FindCandiesToCrush(int[][] board){
        
        int rowCount = board.Length;
        int columnCount = board[0].Length;
        
        var candiesToCrush = new HashSet<Tuple<int, int>>();
        var visited = new HashSet<Tuple<int, int>>();
        
        for(int i = rowCount-1; i >=0; i--){
            for(int j=0; j < columnCount; j++){
                
                if(board[i][j] == 0) continue;
                if(visited.Contains(Tuple.Create(i, j))) continue;
                
                var adjacencyQueue = new Queue<Tuple<int, int>>();
                adjacencyQueue.Enqueue(Tuple.Create(i, j));
                
                while(adjacencyQueue.Count != 0){
                    
                    var current = adjacencyQueue.Dequeue();
                    visited.Add(current);
                    var row = current.Item1;
                    var col = current.Item2;
                    //Look up
                    if(row-1 >=0 && row-2 >=0){
                        if(board[row-1][col] == board[row-2][col]){
                            if(board[row][col] == board[row-1][col]){
                                var aboveCurrent = Tuple.Create(row-1, col);
                                var aboveAboveCurrent = Tuple.Create(row-2, col);
                                adjacencyQueue.Enqueue(aboveCurrent);
                                adjacencyQueue.Enqueue(aboveAboveCurrent);
                                candiesToCrush.Add(new List<Tuple<int, int>>(){current, aboveCurrent,aboveAboveCurrent}); 
                            }
                        }
                    }
                    //Look Right
                    if(col+1 < columnCount && col+2 < columnCount){
                        if(board[row][col+1] == board[row][col+2]){
                            if(board[row][col] == board[row][col+1]){
                                var rightOfCurrent = Tuple.Create(row, col+1);
                                var rightOfRightOfCurrent = Tuple.Create(row, col+2);
                                adjacencyQueue.Enqueue(rightOfCurrent );
                                adjacencyQueue.Enqueue(rightOfRightOfCurrent);
                                candiesToCrush.Add(new List<Tuple<int, int>>(){current, rightOfCurrent,rightOfRightOfCurrent}); 
                            }
                        }
                    }
                }
            }
        }
        
        return candiesToCrush;
    }
    public int[][] CandyCrush(int[][] board) {
        
        int rowCount = board.Length;
        int columnCount = board[0].Length;
                        
        while(true) 
        {
            var candiesToCrush = FindCandiesToCrush(board);
            if(candiesToCrush.Count == 0) return board;
             CrushCandies(board, candiesToCrush);           
        }
        
    }
}