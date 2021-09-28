using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemViewer : MonoBehaviour
{
    [SerializeField] private List<GameObject> _slots;
    [SerializeField] private CountOfSell _countOfSale;    
    private Inventory _inventory;
    public int Index;
    public int CountItemForSell;
    

    private void Awake()
    {
        AddSlotID();
    }
    private void Start()
    {
        _inventory = (Inventory)GetComponent<CreateInventory>().Inventory;
        _inventory.OnStateChanged += UpdateInventory;
    }

    private void UpdateInventory()
    {
        
       for (int i = 0; i < _inventory.Size; i++)
        {
            Item item = _inventory.GetItem<Item>(i);           
            
            if (item != null)
            {
                Slot slot = _slots[i].GetComponent<Slot>();
                slot.Count = item.Count;
                slot.Sprite = item.Img;                
            }
        }
    }   

    public void SellItem()
    {
        CountItemForSell = _countOfSale.CountOfSale;
        for (int i = 0; i < CountItemForSell; i++)
        {
            Item item = _inventory.GetItem<Item>(Index);
            _inventory.RemoveItem(item);
        }
        _countOfSale.CountOfSale = 1;
        _countOfSale.CountUpdate();
    }
    
    private void AddSlotID()
    {
        int counter = 0;
        for (int i = 0; i < _slots.Count; i++)
        {
            _slots[i].GetComponent<Slot>().ID = counter;
            counter++;
        }
    }

  
}