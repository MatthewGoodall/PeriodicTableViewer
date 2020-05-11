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
        if(move.y > 0.5f && !runOnce)
        {
            tableLoader.UnHighlightElements();
            tableLoader.highlightElement(move);
            runOnce = true;

        } else if(move.y < -0.5f && !runOnce)
        {
            tableLoader.UnHighlightElements();
            tableLoader.highlightElement(move);
            runOnce = true;
        }

        if(Mathf.RoundToInt(move.y) == 0f)
        {
            runOnce = false;
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
