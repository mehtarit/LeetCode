public class LRUCache {
    
    int capacity;
    Dictionary<int, int> cacheMap;
    List<int> lruList;

    public LRUCache(int capacity) 
    {
        this.capacity = capacity;  
        cacheMap = new Dictionary<int, int>();
        lruList = new List<int>();
    }
    
    public int Get(int key) {
        
        if(!cacheMap.ContainsKey(key)) return -1;
        
        int value = cacheMap[key];
        lruList.Remove(key);
        lruList.Add(key);
        return value;
    }
    
    public void Put(int key, int value) {
        if(cacheMap.ContainsKey(key)){
            lruList.Remove(key);
            lruList.Add(key);
            cacheMap[key] = value;
            return;
        }
        if(cacheMap.Count < capacity || !lruList.Any()){
            lruList.Add(key);
            cacheMap.Add(key, value);
            return;
        }
        var lruKey = lruList[0];
        lruList.RemoveAt(0);
        cacheMap.Remove(lruKey);
        cacheMap.Add(key, value);
        lruList.Add(key);
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */