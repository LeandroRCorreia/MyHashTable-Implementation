using System;
using System.Collections.Generic;

struct MyLinkedListNode<T>
{

    public MyLinkedListNode(string key, T value)
    {
        this.key = key;
        this.value = value;
    }

    public string key;

    public T value;
}

public class MyDictionary
{
    LinkedList<MyLinkedListNode<int>>[] buckets;
    

    public MyDictionary(int capacity)
    {
        buckets = new LinkedList<MyLinkedListNode<int>>[capacity * 2];
        for (int i = 0; i < buckets.Length; i++)
        {
            buckets[i] = new();
        }
    }

    public int Lookup(string key)
    {
        int hashID = HashFunction(key);
        var linkedList = buckets[hashID];
        const int NoneValue = int.MaxValue;
        if(linkedList.Count == 0)
        {
            return NoneValue;
        }


        //Se houver colisão nas chaves vamos ter que inteirar sobre a linkedlist para buscar o valor específico
        var current = linkedList.First;
        int returnedValue = int.MaxValue;
        for (int i = 0; i < buckets.Length; i++)
        {
            if(current.Value.key == key)
            {
                returnedValue = current.Value.value;
                break;
            }
            if(current?.Next == null)
            {
                break;
            } 
            current = current?.Next;
        }

        return returnedValue;
    }

    public void Add(string key, int value)
    {
        int hashIndex = HashFunction(key);
        var node = buckets[hashIndex];
        var myLinkedListNodeInit = new MyLinkedListNode<int>(key, value);
        node.AddLast(myLinkedListNodeInit);
    }

    public void Remove(string key)
    {        
        int hashID = HashFunction(key);
        var linkedList = buckets[hashID];
        if(linkedList.Count == 0)
        {
            return;
        }

        var current = linkedList.First;

        for (int i = 0; i < buckets.Length; i++)
        {
            if(current.Value.key == key)
            {
                linkedList.Remove(current.Value);   
                break;
            }
            if(current?.Next == null)
            {
                Console.WriteLine("Error! Cannot Remove because the key does not exists!");
                break;
            } 
            current = current?.Next;
        }
    }

    private int HashFunction(string key)
    {
        return Math.Abs(key.GetHashCode()) % buckets.Length;
    }

}
