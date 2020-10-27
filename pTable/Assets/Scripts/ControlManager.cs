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
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;

    }


    private void Update()
    {
        if (!runOnce && move.y >= 0.5f || !runOnce && move.y <= -0.5f)
        {
            tableLoader.highlightElement(move);
            runOnce = true;
        } else if (!runOnce && move.x >= 0.5f || !runOnce && move.x <= -0.5f)
        {
            tableLoader.highlightElement(move);
            runOnce = true;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            runOnce = false;
        }

        
        /*if (!runOnce && Mathf.RoundToInt(move.y) != 0.0f || Mathf.RoundToInt(move.x) != 0.0f )
        {
            tableLoader.highlightElement(move);
            
            runOnce = true;
        }

        else if (runOnce && move.y == 0.0f){
            runOnce = false;
        }*/
      


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
