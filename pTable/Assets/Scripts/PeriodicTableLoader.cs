using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicTableLoader : MonoBehaviour
{
    public Period[] periods;
    public int currentPeriod;
    public int currentRow;

    [System.Serializable]
    public class ElementData 
    {
        public string name;
        public string category;
        public string spectral_img;
        public int xpos;
        public int ypos;
        public string named_by;
        public float density;
        public string color;
        public float molar_heat;
        public string symbol;
        public string discovered_by;
        public string appearance;
        public float atomic_mass;
        public float melt;
        public string number;
        public string source;
        public int period;
        public string phase;
        public string summary;
        public int boil;

    }

    public void highlightElement(Vector2 direction)
    {
        GameObject[] gameObjects = periods[currentPeriod].elementObjects.ToArray();
        if (currentRow > gameObjects.Length)
        {
            currentRow += Mathf.RoundToInt(direction.y);
            Element currentElement = gameObjects[periods.Length - 1].GetComponent<Element>();
            currentElement.highlightElement();
            
        } else if (currentRow < 0)
        {
            currentRow += Mathf.RoundToInt(direction.y);
            Element currentElement = gameObjects[0].GetComponent<Element>();
            currentElement.highlightElement();

        } else
        {
            currentRow += Mathf.RoundToInt(direction.y);
            if (gameObjects[currentRow] != null)
            {
                Element currentElement = gameObjects[currentRow].GetComponent<Element>();
                currentElement.highlightElement();
            }
        }
    }

    public void UnHighlightElements() 
    {
        
        for (int i = 0; i < periods[currentRow].elementObjects.Count; i++)
        {
            Element element = periods[currentRow].elementObjects[i].GetComponent<Element>();
            if (element.isHilighted)
            {
                element.isHilighted = false;
            }

        }
    }

    [System.Serializable]
    class ElementsData
    {
        public List<ElementData> elements;

        public static ElementsData FromJSON(string json)
        {
            return JsonUtility.FromJson<ElementsData>(json);
        }
    }
    public void LoadTable()
    {
        for (int i = 0; i < periods.Length; i++)
        {
            periods[i] = transform.GetChild(i).GetComponent<Period>();
        }
        TextAsset asset = Resources.Load<TextAsset>("JSON/data");
        List<ElementData> elements = ElementsData.FromJSON(asset.text).elements;
        foreach (Period item in periods)
        {
            item.PopulateList(elements);
        }
    }


}
