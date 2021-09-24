using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour, IItem
{
    [SerializeField] private int _count;
    [SerializeField] private int _maxCount;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private int _id;
    [SerializeField] private object _metaData;
    public Sprite Img;
    public ItemType ItemType;

    public int Count { get => _count; set => _count = value; }
    public int MaxCount { get => _maxCount; set => _maxCount = value; }
    public string Name { get => _name; set => _name = value; }
    public string Description { get => _description; set => _description = value; }
    public int ID { get => _id; set => _id = value; }
    public object MetaData { get => _metaData; set => _metaData = value; }

    //public static bool operator == (Item item1, Item item2)
    //{
    //    if (item1 is null || item2 is null)
    //        return false;
    //    return item1._name == item2._name;
    //}
    //public static bool operator != (Item item1, Item item2)
    //{
    //    if (item1 is null || item2 is null)
    //        return false;
    //    return item1._name != item2._name;
    //}
}
