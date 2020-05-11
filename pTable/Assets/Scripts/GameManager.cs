using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PeriodicTableLoader tableLoader;

    private void Start()
    {
        tableLoader.LoadTable();
    }


}
