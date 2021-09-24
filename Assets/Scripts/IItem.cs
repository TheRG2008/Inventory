using System.Collections;
using System.Collections.Generic;
using System;

public interface IItem
{
    int Count { get; set; }
    int MaxCount { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    int ID { get; set; }
    object MetaData { get; set; }
}