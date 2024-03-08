using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Manipulatable : MonoBehaviour
{
    [SerializeField] protected bool affectedByGravity;
    [SerializeField] protected bool affectedBySize;
    [SerializeField] protected bool affectedByPerception;
    protected Manipulation manip = null;

    public virtual void Start()
    {
        if (affectedByGravity)
        {
            this.manip = new GravityManip(this.manip);
        }
        if (affectedBySize)
        {
            this.manip = new SizeManip(this.manip);
        }
        if (this.affectedByPerception)
        {
            this.manip = new PerceptionManip(this.manip, this);
        }
    }

    public virtual void Update()
    {
        if (this.manip != null)
        {
            this.manip.Manipulate(this);
        }
    }

    public virtual void Perception(PerceptionManip.State state)
    {
        return;
    }

    public virtual void Gravity()
    {
        return;
    }

    public virtual void Size()
    {
        return;
    }
}
