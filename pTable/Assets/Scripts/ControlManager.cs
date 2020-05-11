using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlManager : MonoBehaviour
{

    UserControls controls;
    public PeriodicTableLoader tableLoader;

    Vector2 move;
    public bool runOnce = false;
    

    private void Awake()
    {
        controls = new UserControls();
        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();

    }
    private void Update()
    {
        Debug.Log(move);
        if (move.y != 0 || move.x != 0 && !runOnce)
        {
            tableLoader.highlightElement(move);
        }
        else {
            runOnce = true;
        }
      


    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
