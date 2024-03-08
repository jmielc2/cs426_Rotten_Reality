using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManip : Manipulation
{
    public GravityManip(Manipulation nested = null) : base(nested)
    {

    }

    public override void Manipulate(Manipulatable obj)
    {
        if (this.nested != null)
        {
            this.nested.Manipulate(obj);
        }

        // Implement Gravity Manip Here

    }
}
