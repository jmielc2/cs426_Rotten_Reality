using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulatable : MonoBehaviour
{
    [SerializeField] protected bool affectedByGravity;
    [SerializeField] protected bool affectedBySize;
    [SerializeField] protected bool affectedByPerception;
    protected Manipulation manip = null;

    // Start is called before the first frame update
    void Start()
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
            this.manip = new PerceptionManip(this.manip);
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.manip.Manipulate(this.gameObject);
    }
}
