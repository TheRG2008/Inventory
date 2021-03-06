using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemViewer : MonoBehaviour
{
    [SerializeField] private List<GameObject> _slots;
    [SerializeField] private List<GameObject> _chestSlots;
    [SerializeField] private CountOfSell _countOfSale;
    [SerializeField] private GameObject _chestInventory;
    private Inventory _inventory;
    private Inventory _ChestInventory;
    public int Index;
    public int CountItemForSell;
    

    private void Awake()
    {
        AddSlotID(_slots);
        AddSlotID(_chestSlots);
    }
    private void Start()
    {
        _inventory = (Inventory)GetComponent<CreateInventory>().Inventory;
        _ChestInventory = (Inventory)_chestInventory.GetComponent<CreateChestInventory>().ChestInventory;
        _inventory.OnStateChanged += UpdateInventory;
        _ChestInventory.OnStateChanged += UpdateInventory;
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

        for (int i = 0; i < _ChestInventory.Size; i++)
        {
            Item item = _ChestInventory.GetItem<Item>(i);

            if (item != null)
            {
                Slot slot = _chestSlots[i].GetComponent<Slot>();
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

    public void MoveItemToChest()
    {
        Item item = _inventory.GetItem<Item>(Index);
        CountItemForSell = _countOfSale.CountOfSale;
        for (int i = 0; i < CountItemForSell; i++)
        {
            Item ChestItem = item;
            ChestItem.Count = 1;
            _ChestInventory.AddItem(item);
        }
        for (int i = 0; i < CountItemForSell; i++)
        {
            _inventory.RemoveItem(item);
        }
       
        UpdateInventory();
        _countOfSale.CountOfSale = 1;
        _countOfSale.CountUpdate();

    }
    
    private void AddSlotID(List<GameObject> slots)
    {
        int counter = 0;
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].GetComponent<Slot>().ID = counter;
            counter++;
        }
    }

  
}