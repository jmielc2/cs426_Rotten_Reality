using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perception : MonoBehaviour
{
    [SerializeField] protected Material invisible;
    [SerializeField] protected Material visible;

    public enum States { VISIBLE, INVISIBLE };
    protected States state;
    protected MeshRenderer meshRenderer;

    // Start is called before the first frame update
    public void Start()
    {
        this.meshRenderer = this.transform.Find("Model").GetComponent<MeshRenderer>();
        this.UpdatePerception();
    }

    // Update is called once per frame
    public void Update()
    {
        if (this.state != GameState.perceptionState)
        {
            this.UpdatePerception();
        }
    }

    protected void UpdatePerception()
    {
        this.state = GameState.perceptionState;
        switch (this.state)
        {
            case Perception.States.INVISIBLE:
                this.meshRenderer.material = invisible;
                break;
            case Perception.States.VISIBLE:
                this.meshRenderer.material = visible;
                break;
        }
    }
}
