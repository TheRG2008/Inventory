using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateInventory : MonoBehaviour
{
    [SerializeField] private int _sizeInventory;
    [SerializeField] private GameObject _inventoryPanel;
    private IInventory _inventory;
    public IInventory Inventory
        => _inventory;

    private void Awake()
    {
        _inventory = new Inventory(_sizeInventory);
    }

    private void Start()
    {
        _inventoryPanel.SetActive(false);
    }
}
