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

    void Start()
    {
        Debug.Log("Here");
        highlightElement(new Vector2(1,1));
    }
    public void highlightElement(Vector2 direction)
    {
        
        UnHighlightElements();
        int x = Mathf.RoundToInt(direction.x); int y = Mathf.RoundToInt(direction.y);
        if (currentPeriod <= 0) 
        {
            currentPeriod = 0;
            if (direction.x > 0.5f)
            {
                currentPeriod += x;
            }
        }
        else if (currentPeriod >= periods.Length - 1)
        {
            currentPeriod = periods.Length - 1;
            if (direction.x < -0.5f)
            {
                currentPeriod += x;
            }
        } else if (currentPeriod == 3 && currentRow != 5 && currentRow != 6)
        {
            if(direction.x > 0.5f)
            {
                currentPeriod = 6;
            }
        }
        else
        {
            currentPeriod += x; 
            Debug.Log(Mathf.RoundToInt(direction.x));
        }

        GameObject[] gameObjects = periods[currentPeriod].elementObjects.ToArray();
        Element currentElement;
        if(currentRow <= 0)
        {
            currentRow = 0;
            
            if(direction.y <= -0.5f)
            {
                currentRow -= y;
            }
        } else if (currentRow >= gameObjects.Length - 1)
        {
            currentRow = gameObjects.Length;
            if(direction.y <= -0.5f)
            {
                currentRow += y;
            }
        } else
        {
            currentRow += -y;
        }

        currentElement = gameObjects[currentRow].GetComponent<Element>();
        currentElement.isHilighted = true;
        
    }

    public void UnHighlightElements() 
    {
        
        for (int i = 0; i < periods[currentPeriod].elementObjects.Count; i++)
        {
            Element element = periods[currentPeriod].elementObjects[i].GetComponent<Element>();
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
