using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Manipulatable : MonoBehaviour
{
    public virtual void UpdatePerception() { return; }
    public virtual void UpdateGravity() { return; }
    public virtual void UpdateSize() { return; }
}
