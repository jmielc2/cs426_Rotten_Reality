using UnityEngine;

public abstract class Manipulation
{
    protected Manipulation nested;

    public Manipulation(Manipulation nested = null)
    {
        this.nested = nested;
    }

    public abstract void Manipulate(GameObject obj);
}
