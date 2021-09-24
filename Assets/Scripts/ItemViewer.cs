using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemViewer : MonoBehaviour
{
    [SerializeField] private List<GameObject> _slots;
    //[SerializeField] private Transform _panel;
    [SerializeField] private GameObject _slot;
    //private List<GameObject> slots;
    private Inventory _inventory;
    

    private void Awake()
    {
        //slots = new List<GameObject>();
        AddSlotID();
    }
    private void Start()
    {
        
        _inventory = (Inventory)GetComponent<Controller>().Inventory;
        _inventory.OnStateChanged += UpdateInventory;
       
        //CreateInventorySlots();
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
    
    public void SellItem ()
    {
        

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

    //void CreateInventorySlots ()
    //{
    //    for (int i = 0; i < 35; i++)
    //    {
    //        Instantiate(_slot, _panel);
    //        slots.Add(_slot);
    //    }
    //}
}