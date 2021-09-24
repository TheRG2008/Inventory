using System.Collections;
using System.Collections.Generic;
using System;


public class Inventory : IInventory
{
    private IItem[] _items;
    public int Size { get; }
    public event Action OnStateChanged;

    public Inventory(int size)
    {
        Size = size;
        _items = new IItem[size];
       
    }

    public bool CheckItem(IItem item)
    {
        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i] == item)
                return true;
        }
        return false;
        
    }
    private bool _AddItem(IItem item)
    {
        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i] == null)
            {
                _items[i] = item;
                OnStateChanged?.Invoke();
                return true;
            }
        }
        return false;
    }

    public bool AddItem(IItem item)
    {
        int count = 0;

        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i] != null && _items[i].Name == item.Name)
            {
                if (_items[i].Count <= item.MaxCount - item.Count)
                {
                    _items[i].Count += item.Count;
                    OnStateChanged?.Invoke();
                    return true;
                }
                else
                {
                    count = (_items[i].Count + item.Count) - item.MaxCount;
                    _items[i].Count = item.MaxCount;
                    item.Count = count;
                    OnStateChanged?.Invoke(); //
                    return _AddItem(item);
                }

            }
        }
        return _AddItem(item);
    }
    public bool RemoveItem(IItem item)
    {
        for (int i = 0; i < _items.Length; i++)
        {
            if(_items[i] == item)
            {
                _items[i] = null;
                OnStateChanged?.Invoke();
                return true;
            }
        }
        return false;
    }

    public IItem GetItem(int index)
    {
        return _items[index];
    }

    public T GetItem<T>(int index) where T : IItem
    {
        return (T) _items[index];
    }
}
    
