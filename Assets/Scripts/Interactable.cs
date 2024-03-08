using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : Manipulatable 
{
    [SerializeField] private Material invisible;
    [SerializeField] private Material visible;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void Perception(PerceptionManip.State state)
    {
        Debug.Log("Changing material");
        MeshRenderer renderer = this.gameObject.transform.Find("Model").gameObject.GetComponent<MeshRenderer>();
        switch (state)
        {
            case PerceptionManip.State.INVISIBLE:
                renderer.material = this.invisible;
                break;
            case PerceptionManip.State.VISIBLE:
                renderer.material = this.visible;
                break;
        }
    }
}
