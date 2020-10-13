public class RandomizedSet {

    /** Initialize your data structure here. */
    Dictionary<int, int> _indexMap;
    List<int> _set;
    
    public RandomizedSet() {
        
        _indexMap = new Dictionary<int, int>();
        _set = new List<int>();
        
    }
    
    /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
    public bool Insert(int val) {
        
        if(_indexMap.ContainsKey(val)) return false;
        _set.Add(val);
        _indexMap.Add(val, _set.Count -1);
        return true;
        
    }
    
    /** Removes a value from the set. Returns true if the set contained the specified element. */
    public bool Remove(int val) {
                
        if(!_indexMap.ContainsKey(val)) return false;
        
        var index = _indexMap[val];
        
        var lastElement = _set[_set.Count-1];
        _set[index] = lastElement;
        _set[_set.Count-1] = val;
               
        _indexMap[lastElement] = index;
        _set.RemoveAt(_set.Count-1);
        _indexMap.Remove(val);
        return true;
        
    }
    
    /** Get a random element from the set. */
    public int GetRandom() {
                
        var random = new Random();
        var randomIndex = random.Next(_set.Count);
        return _set[randomIndex];
        
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */