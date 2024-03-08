using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerceptionPlatform : Manipulatable 
{
    [SerializeField] private Material invisible;
    [SerializeField] private Material visible;

    protected GameState.Perception state;

    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        this.UpdatePerception();
    }

    public override void UpdatePerception() {
        if (this.state != GameState.PerceptionState)
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
}
