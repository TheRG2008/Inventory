using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{    
    [SerializeField] private Image _sprite;
    [SerializeField] private Text _text;
    [SerializeField] private Button _selectButton;
    private int _id = 0;
    public int Index;

    public int ID
    {
        get => _id;
        set => _id = value;
    }
    public Sprite Sprite
    {
        get => _sprite.sprite;
        set => _sprite.sprite = value;
    }
    public int Count
    {        
        set => _text.text = value.ToString();
    }

    public int SelectSlot()
    {
        if (_selectButton.gameObject.GetComponent<Slot>().Sprite != null)
        {
            _selectButton.Select();            
            Debug.Log(ID);
            return ID;
            
        }
        else
            Debug.Log("SelectButton was null");
        return 0;
        
    }
    public void GetIndexID ()
    {
        Index = SelectSlot();
        SaveIndex();
    }

    public void SaveIndex()
    {
        ItemViewer view = transform.GetComponentInParent<ItemViewer>();
        view.Index = Index;

    }
   

}
