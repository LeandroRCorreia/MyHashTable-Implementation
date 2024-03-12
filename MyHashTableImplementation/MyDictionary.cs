using System;
using System.Collections.Generic;

struct MyLinkedListNode<K, V>
{

    public MyLinkedListNode(K key, V value)
    {
        this.key = key;
        this.value = value;
    }

    public K key;

    public V value;
}

public class MyDictionary<K, V>
{
    LinkedList<MyLinkedListNode<K, V>>[] buckets;
    
    public MyDictionary(int capacity)
    {
        buckets = new LinkedList<MyLinkedListNode<K, V>>[capacity * 2];
        for (int i = 0; i < buckets.Length; i++)
        {
            buckets[i] = new();
        }
    }

    public V Lookup(K key)
    {
        var returnedValue = FindLinkedListNode(key);

        return returnedValue.value;
    }

    public void Add(K key, V value)
    {
        var node = GetLinkedListbyKey(key);

        var myLinkedListNode = new MyLinkedListNode<K, V>(key, value);
        node.AddLast(myLinkedListNode);
    }

    public void Remove(K key)
    {        
        var node = FindLinkedListNode(key);
        var linkedList = GetLinkedListbyKey(key);

        linkedList.Remove(node);
    }

    private int HashFunction(K key)
    {
        return Math.Abs(key.GetHashCode()) % buckets.Length;
    }

    private LinkedList<MyLinkedListNode<K, V>> GetLinkedListbyKey(K key)
    {
        int hashIndex = HashFunction(key);
        var linkedList = buckets[hashIndex];

        return linkedList;
    }

    private MyLinkedListNode<K, V>FindLinkedListNode(K key)
    {
        var linkedList = GetLinkedListbyKey(key);
        if(linkedList.Count == 0)
        {
            return default;
        }

        var currentNode = linkedList.First;
        while(currentNode != null)
        {
            if(currentNode.Value.key.Equals(key))
            {
                break;
            }
            currentNode = currentNode?.Next;
        }

        return currentNode.Value;
    }

}
