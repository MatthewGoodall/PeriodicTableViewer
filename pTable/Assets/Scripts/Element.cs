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

    private Image image;

    public void SetData()
    {
        chemSymbol.SetText(data.symbol);
        atomicNumber.SetText(data.number);
        image = GetComponent<Image>();
    }

    private void Update()
    {
        if (isHilighted)
        {
            Color color = Color.red;
            image.color = color;
        } else
        {
            Color color = Color.white;
            color.a = 0.50f;
            image.color = color;           
        }
    }

}
