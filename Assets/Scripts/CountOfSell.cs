using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountOfSell : MonoBehaviour
{
    public int CountOfSale = 1;
    [SerializeField] private Text _countText;

    private void Awake()
    {
        CountUpdate();
    }

    public void Up1()
    {
        CountOfSale++;
        CountUpdate();
    }
    public void Up10()
    {
        CountOfSale += 10;
        CountUpdate();
    }
    public void Down1()
    {
        if (CountOfSale <= 1)
        {
            return;
        }
        CountOfSale--;
        CountUpdate();
    }
    public void Down10()
    {
        if (CountOfSale <= 10)
        {
            CountOfSale = 1;
            CountUpdate();
            return;
        }
        CountOfSale -= 10;
        CountUpdate();
    }

    public void CountUpdate()
    {
        _countText.text = CountOfSale.ToString();
    }
}
