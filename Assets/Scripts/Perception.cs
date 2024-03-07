using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perception : Manipulation 
{
    public Perception(Manipulation nested = null) : base(nested)
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
