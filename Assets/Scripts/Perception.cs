using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perception : MonoBehaviour
{
    [SerializeField] protected Material invisible;
    [SerializeField] protected Material visible;

    protected GameState.Perception state;

    // Start is called before the first frame update
    public void Start()
    {
        this.UpdatePerception();
    }

    // Update is called once per frame
    public void Update()
    {
        if (this.state != GameState.PerceptionState)
        {
            this.UpdatePerception();
        }
    }

    protected void UpdatePerception()
    {
        this.state = GameState.PerceptionState;
        MeshRenderer renderer = this.gameObject.transform.Find("Model").GetComponent<MeshRenderer>();
        switch (this.state)
        {
            case GameState.Perception.INVISIBLE:
                renderer.material = invisible;
                break;
            case GameState.Perception.VISIBLE:
                renderer.material = visible;
                break;
        }
    }
}
