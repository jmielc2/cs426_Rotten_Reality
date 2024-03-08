using UnityEngine;

public abstract class Manipulation
{
    protected Manipulation nested;

    public Manipulation(Manipulation nested)
    {
        this.nested = nested;
    }

    public abstract void Manipulate(Manipulatable obj);
}
