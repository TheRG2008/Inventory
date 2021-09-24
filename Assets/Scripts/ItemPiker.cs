using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPiker : MonoBehaviour
{
    private IInventory _inventory;
    private void Start()
    {
        _inventory = GetComponent<Controller>().Inventory;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<Item>())
        {
            Item item = new Item();
            Item OldItem = other.GetComponent<Item>();
            item.ItemType = OldItem.ItemType;
            _inventory.AddItem(other.GetComponent<Item>());
            //other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
    }




}
