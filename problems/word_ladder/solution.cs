public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        
        var visited = new Dictionary<string, bool>();
        foreach(var s in wordList.ToList()){
            visited.Add(s, false);
        }

        if(!visited.ContainsKey(endWord)) return 0;
        
      //  Console.WriteLine("here3");
        var allCombos = new Dictionary<string, List<string>>();
        
        foreach(var s in wordList){
            
            var sArray = s.ToCharArray();
            for(int i = 0; i < s.Length; i++){
                sArray[i] = '*';
                var intermediate = new string(sArray);
                
              //  Console.WriteLine("Creating intermediate: " + intermediate);
                sArray[i] = s[i];
                if(allCombos.ContainsKey(intermediate)) 
                {
                    allCombos[intermediate].Add(s);
                }
                else {allCombos.Add(intermediate, new List<string>(){s});}
            }
        }
        
        var adjacentQ = new Queue<Tuple<string,int>>();
        
        adjacentQ.Enqueue(Tuple.Create(beginWord, 1));
        if(!visited.ContainsKey(beginWord)) visited.Add(beginWord, false);
        
        while(adjacentQ.Count != 0)
        {
            var front = adjacentQ.Dequeue();
            var current = front.Item1;
            
           // Console.WriteLine("Current word is: " + current);
            
            if(visited[current]) continue;
            if(current == endWord) return front.Item2;
            
            var sArray = current.ToCharArray();
            
            for(int i = 0; i < front.Item1.Length; i++){
                sArray[i] = '*';
                var s = new string(sArray);
             //   Console.WriteLine("Considering intermediate word " + s);
                if(allCombos.ContainsKey(s)){
                    var possibleNextWords = allCombos[s];
                    foreach(var word in possibleNextWords){
                        adjacentQ.Enqueue(Tuple.Create(word, front.Item2 + 1));
                 //       Console.WriteLine("Adding similar word " + word + " to the queue");
                    }
                }
                sArray[i] = current[i]; 
            }
            visited[current] = true;
                                    
        }       
        return 0;
        
    }
}