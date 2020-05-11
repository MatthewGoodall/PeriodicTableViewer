using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static PeriodicTableLoader;

public class Element : MonoBehaviour
{
    public ElementData data;

    public TextMeshProUGUI chemSymbol;
    public TextMeshProUGUI atomicNumber;

    public bool isHilighted = false;


    public void SetData()
    {
        chemSymbol.SetText(data.symbol);
        atomicNumber.SetText(data.number);
    }

    private void Update()
    {
        if (isHilighted)
        {
            GetComponent<Image>().color = Color.red;
        } else
        {
            GetComponent<Image>().color = Color.white;
        }
    }

}
