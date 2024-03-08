using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerceptionManip : Manipulation 
{
    public enum State { VISIBLE, INVISIBLE };
    protected State state;
    
    public PerceptionManip(Manipulation nested, Manipulatable obj) : base(nested)
    {
        this.state = GameState.PerceptionState;
        obj.Perception(this.state);
    }

    public override void Manipulate(Manipulatable obj)
    {
        if (this.nested != null)
        {
            this.nested.Manipulate(obj);
        }

        // Implement Perception Manip Here
        PerceptionManip.State gameState = GameState.PerceptionState;
        if (gameState != this.state)
        {
            this.state = gameState;
            obj.Perception(this.state);
        }
    }
}
