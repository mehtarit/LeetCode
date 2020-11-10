public class Solution {
    public bool CanTransform(string start, string end) {
        
        var startXCount = 0;
        List<Tuple<char,int>> starters = new List<Tuple<char,int>>();
        
        for(int i = 0; i < start.Length; i++){
            var c = start[i];
            if(c=='X') startXCount++;
            if(c=='R' || c == 'L') starters.Add(Tuple.Create(c, i));
        }
        
        var endXCount = 0;
        List<Tuple<char,int>> enders = new List<Tuple<char,int>>();
        
        for(int i = 0; i < end.Length; i++){
            var c = end[i];
            if(c=='X') endXCount++;
            if(c=='R' || c == 'L') enders.Add(Tuple.Create(c, i));
        }
        
        if(startXCount != endXCount) return false;
        
        if(starters.Count != enders.Count) return false;
        
        for(int i = 0; i < starters.Count; i++){
            var starter = starters[i];
            var ender = enders[i];
            
            if(starter.Item1 != ender.Item1) return false;
            
            if(starter.Item1 == 'R' && ender.Item2 < starter.Item2) return false;
            if(starter.Item1 == 'L' && ender.Item2 > starter.Item2) return false;
        }
        
        return true;
    }
}