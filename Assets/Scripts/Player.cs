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
    public override void Start()
    {
        base.Start(); 
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (Input.GetButtonDown("Jump"))
        {
            switch (GameState.PerceptionState)
            {
                case (PerceptionManip.State.INVISIBLE):
                    GameState.PerceptionState = PerceptionManip.State.VISIBLE;
                    break;
                case (PerceptionManip.State.VISIBLE):
                    GameState.PerceptionState = PerceptionManip.State.INVISIBLE;
                    break;
            }
        }
    }

    public override void Gravity()
    {
        Debug.Log("Gravity");
    }

    public override void Size()
    {
        Debug.Log("Size");
    }
}
