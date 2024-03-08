using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerceptionManip : Manipulation 
{
    public PerceptionManip(Manipulation nested = null) : base(nested)
    {

    }

    public override void Manipulate(GameObject obj)
    {
        if (this.nested != null)
        {
            this.nested.Manipulate(obj);
        }   

        // Implement Perception Manip Here

    }
}
