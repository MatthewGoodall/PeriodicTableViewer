using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static PeriodicTableLoader;

public class Period : MonoBehaviour
{
    private List<ElementData> elements = new List<ElementData>();
    public List<GameObject> elementObjects = new List<GameObject>();

    public string[] catagory;
    public int periodNumber;
    public GameObject elementPrefab;
    private bool x = false;

    public void PopulateList(List<ElementData> period) 
    {
        if (!x)
        {
            foreach (ElementData element in period)
            {
                if (catagory.Contains(element.category))
                {
                    if (element.category == "lanthanide " && element.ypos == periodNumber)
                    {
                        elements.Add(element);
                        Debug.Log("Added: " + element.name);
                    }
                    else if (element.category == "actinide " && element.ypos == periodNumber)
                    {
                        elements.Add(element);
                        Debug.Log("Added: " + element.name);
                    }
                    else if (element.xpos == periodNumber)
                    {
                        elements.Add(element);
                        Debug.Log("Added: " + element.name);
                    }
                }
            }
            elements.Sort(SortElements);
            elementObjects.Sort(SortElements);
            CreateElementObjects();
            x = true;
        }
    }

    

    private void CreateElementObjects()
    {
        foreach (ElementData element in elements)
        {
            
            GameObject obj = Instantiate(elementPrefab, gameObject.transform);
            obj.GetComponent<Element>().data = element;
            obj.GetComponent<Element>().SetData();
            elementObjects.Add(obj);
        }
    }
    private int SortElements(GameObject x, GameObject y)
    {
        ElementData e1 = x.GetComponent<ElementData>();
        ElementData e2 = y.GetComponent<ElementData>();
        if (e1.category == "lanthanide " || e1.category == "actinide ")
        {
            return e1.xpos.CompareTo(e2.xpos);
        }
        return e1.ypos.CompareTo(e2.ypos);
    }
    static int SortElements(ElementData e1, ElementData e2)
    {
        if (e1.category == "lanthanide " || e1.category == "actinide ")
        {
            return e1.xpos.CompareTo(e2.xpos);
        }
        return e1.ypos.CompareTo(e2.ypos);
    }


}
