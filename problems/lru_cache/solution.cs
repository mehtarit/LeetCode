public class LRUCache {
    
    int _capacity = 0;
    LinkedList<int> _list;
    Dictionary<int,int> _map;
    

    public LRUCache(int capacity) {
        
        _capacity = capacity;
        _list = new LinkedList<int>();
        _map = new Dictionary<int,int>();
        
    }
    
    public int Get(int key) {
        
        if(!_map.ContainsKey(key)) return -1;
        var val = _map[key];
        _list.Remove(key);
        _list.AddFirst(key);
        return val;
        
    }
    
    public void Put(int key, int value) {
        
        if(_map.ContainsKey(key)) {
            _map[key] = value;
            _list.Remove(key);
        }
        else _map.Add(key, value);
        
        _list.AddFirst(key);
        if(_map.Count > _capacity){
            var remove = _list.Last();
            _map.Remove(remove);
            _list.RemoveLast();            
        }
        
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */