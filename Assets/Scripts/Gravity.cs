using UnityEngine;

public class Gravity : MonoBehaviour
{
    public enum States { DOWN, UP };
    protected States state;
    protected new ConstantForce constantForce;

    void Start()
    {
        this.constantForce = this.gameObject.GetComponent<ConstantForce>();
        this.UpdateGravity();
    }

    void Update() {
        if (this.state != GameState.gravityState) {
            this.UpdateGravity();
        }
    }

    protected void UpdateGravity() {
        this.state = GameState.gravityState;
        Vector3 newForce = this.constantForce.force;
        switch (this.state) {
            case Gravity.States.DOWN:
                newForce.y = -20;
                this.constantForce.force = newForce;
                break;
            case Gravity.States.UP:
                newForce.y = 20;
                this.constantForce.force = newForce;
                break;
        }
    }
}
