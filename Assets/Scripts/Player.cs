using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Manipulatable
{
    public Player() : base()
    {
        return;
    }

    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        
        if (Input.GetButtonDown("Jump")) // Changes perception state when jump is pressed
        {
            GameState.TogglePerceptionState();
        }
    }
}
