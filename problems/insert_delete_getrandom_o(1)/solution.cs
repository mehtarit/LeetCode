public class RandomizedSet {
    
    Dictionary<int, int> _map;
    List<int> _set;
    Random rand;

    /** Initialize your data structure here. */
    public RandomizedSet() {
        
        _map = new Dictionary<int, int>();
        _set = new List<int>();
        rand = new Random();
        
    }
    
    /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
    public bool Insert(int val) {
        
        if(_map.ContainsKey(val)) return false;
        _set.Add(val);
        _map.Add(val, _set.Count-1);
        return true;
    }
    
    /** Removes a value from the set. Returns true if the set contained the specified element. */
    public bool Remove(int val) {
        
        if(!_map.ContainsKey(val)) return false;
        var currentIndex = _map[val];
        var last = _set[_set.Count-1];
        
        _map[last] = currentIndex;
        _set[currentIndex] = last;
        _set[_set.Count-1] = val;
        
        _map.Remove(val);
        _set.RemoveAt(_set.Count-1);
        return true;
        
    }
    
    /** Get a random element from the set. */
    public int GetRandom() {
        
        var randomIndex = rand.Next(_set.Count);
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