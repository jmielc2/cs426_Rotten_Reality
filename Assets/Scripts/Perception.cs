using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perception : MonoBehaviour
{
    [SerializeField] protected Material invisible;
    [SerializeField] protected Material visible;

    public enum States { VISIBLE, INVISIBLE };
    protected Perception.States state;

    // Start is called before the first frame update
    public void Start()
    {
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
        MeshRenderer renderer = this.gameObject.transform.Find("Model").GetComponent<MeshRenderer>();
        switch (this.state)
        {
            case Perception.States.INVISIBLE:
                renderer.material = invisible;
                break;
            case Perception.States.VISIBLE:
                renderer.material = visible;
                break;
        }
    }
}
