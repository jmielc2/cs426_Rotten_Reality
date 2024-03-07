using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Size : Manipulation 
{
    public Size(Manipulation nested) : base(nested)
    {

    }

    public override void Manipulate(GameObject obj)
    {
        if (this.nested != null)
        {
            this.nested.Manipulate(obj);
        }

        // Implement Size Manip Here

    }
}
