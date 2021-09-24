using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellButton : MonoBehaviour
{
    private Slot _slot;
    private int _index;

    public void SellItem ()
    {
        _index = _slot.GetComponent<Slot>().SelectSlot();
        Debug.Log(_index);
    }
}
