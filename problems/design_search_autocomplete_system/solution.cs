public class Node {
    public Dictionary<char,Node> Children;
    public bool IsCompleteWord;
    
    public Node(){
        Children = new Dictionary<char, Node>();
        IsCompleteWord = false;
    }
}

public class Trie {
    
    public Node CreateTrie(Dictionary<string, int> freqMap){
        
        var root = new Node();
        var current = root;
        
        foreach(var word in freqMap.Keys){
            for(int i = 0; i < word.Length; i++){
                var c = word[i];
                if(!current.Children.ContainsKey(c)) {
                    current.Children.Add(c, new Node());                    
                }
                current = current.Children[c];
                if(i == word.Length-1) current.IsCompleteWord = true;
            }
            current = root;
        }
        
        return root;        
    }
    
    public void UpdateTrie(Node root, string word){
        
        var current = root;
        for(int i = 0; i < word.Length; i++)
        {
            var c = word[i];
            if(!current.Children.ContainsKey(c)) current.Children.Add(c, new Node());
            current = current.Children[c];
            if(i == word.Length-1) current.IsCompleteWord = true;
        }        
    }
    
    public List<string> GetAllWords(Node root, List<char> chars)
    {
        var result = new List<string>();
        FindAllWords(root, result, chars);
        return result;
    }
    
    public Node FindNode(Node root, List<Char> path){
        foreach(var c in path){
           // Console.WriteLine($"Looking at {c}");
            if(root.Children.ContainsKey(c)) root = root.Children[c];
            else return new Node();
        }
        return root;       
    }
    
    public void FindAllWords(Node node, List<string> result, List<char> chars){
        var current = node;
        if(current.IsCompleteWord) result.Add(new string(chars.ToArray()));
        
        foreach(var pair in current.Children){
            var c = pair.Key;
            //Console.WriteLine($"Reading {c}");
            var temp = new List<char>(chars);
            temp.Add(c);
            FindAllWords(current.Children[c], result, temp);
            current = node;
        }
    }
}

public class AutocompleteSystem {
    
    Node _root;
    Dictionary<string, int> _freqMap;
    List<char> _result;
    Trie _trie;

    public AutocompleteSystem(string[] sentences, int[] times) {
    
        _freqMap = new Dictionary<string, int>();
        for(int i = 0; i < sentences.Length; i++){
            _freqMap.Add(sentences[i], times[i]);
        }
        _trie = new Trie();
        _root = _trie.CreateTrie(_freqMap);
        _result = new List<char>();
        
    }
    
    public IList<string> Input(char c) {
        
        var searchStr = new string(_result.ToArray());
        if(c == '#'){
            _result = new List<char>();
            if(_freqMap.ContainsKey(searchStr)) _freqMap[searchStr]++;
            else {
                _freqMap.Add(searchStr, 1);
                _trie.UpdateTrie(_root, searchStr);
            }            
            return new List<string>();
        }
        
        _result.Add(c);
        searchStr = new string(_result.ToArray());
       // Console.WriteLine($"Search String is: {searchStr}");
        var allWords = _trie.GetAllWords(_trie.FindNode(_root, searchStr.ToCharArray().ToList()), searchStr.ToCharArray().ToList());
        
        var map = new Dictionary<string, int>();
        foreach(var word in allWords){ 
          //  Console.WriteLine($"Word under consideration is: {word}");
            map.Add(word,_freqMap[word]);
        }           
        var sortedMap = map.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key).ToDictionary(x=>x.Key, x=>x.Value);
        var sortedList = sortedMap.Keys.ToList();
        sortedList = sortedList.Take(3).ToList();
         return sortedList;           
      
    }
}

/**
 * Your AutocompleteSystem object will be instantiated and called as such:
 * AutocompleteSystem obj = new AutocompleteSystem(sentences, times);
 * IList<string> param_1 = obj.Input(c);
 */