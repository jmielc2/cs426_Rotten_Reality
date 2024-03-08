using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeManip : Manipulation 
{
    public SizeManip(Manipulation nested) : base(nested)
    {

    }

    public override void Manipulate(Manipulatable obj)
    {
        if (this.nested != null)
        {
            this.nested.Manipulate(obj);
        }

        // Implement Size Manip Here

    }
}
