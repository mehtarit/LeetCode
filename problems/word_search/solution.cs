public class Solution {
    public bool Exist(char[][] board, string word) {
        
        for(int i = 0; i < board.Length; i++){
            for(int j = 0; j < board[i].Length; j++){
                if(board[i][j] == word[0] && Dfs(board, i, j, 0, word)){
                    return true;
                }
            }
        }
        
        return false;
        
    }
    
    public bool Dfs(char[][] board, int i, int j, int count, string word){
        
        if(count == word.Length) return true;
        
        if(i < 0 || i >= board.Length || j<0 || j >=board[i].Length || board[i][j] != word[count])
            return false;
        
        char temp = board[i][j];
        board[i][j] = '\0';
        
        bool found = Dfs(board, i+1, j, count+1, word) 
            || Dfs(board, i-1, j, count+1, word) 
            || Dfs(board, i, j+1, count+1, word) 
            || Dfs(board, i, j-1, count+1, word);
        
        board[i][j] = temp;
        
        return found;      
    }
}