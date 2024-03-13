using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Size : MonoBehaviour
{
    //[SerializeField] protected bool isbig = false;

    public enum States { BIG, SMALL };
    protected States state;
    [SerializeField, Range(1.0f, 4.0f)] protected float shrinkFactor = 2f;
    protected Vector3 largeScale;
    protected Vector3 smallScale;

    public void Start()
    {
        this.largeScale = this.transform.localScale;
        this.smallScale = this.largeScale * (1.0f / this.shrinkFactor);
        this.UpdateSize();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.state != GameState.sizeState)
        {
            this.UpdateSize();
        }
    }

    protected void UpdateSize()
    {
        this.state = GameState.sizeState;
        switch (this.state)
        {
            case Size.States.SMALL:
                transform.localScale = smallScale;
                break;
            case Size.States.BIG:
                transform.localScale = largeScale;
                break;
        }
    }
}
