using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPiker : MonoBehaviour
{
    [SerializeField] private CreateInventory _createInventory;
    private IInventory _inventory;
    private void Start()
    {
        _inventory = _createInventory.Inventory;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<Item>())
        {            
            Item item = other.GetComponent<Item>(); 
            _inventory.AddItem(item);
            other.gameObject.SetActive(false);
            //Destroy(other.gameObject);
        }
    }




}
