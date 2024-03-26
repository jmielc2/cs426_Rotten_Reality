using UnityEngine;

public class Gravity : MonoBehaviour
{
    public enum States { DOWN, UP };
    protected States state;
    protected ConstantForce constantForce;
    protected static float FORCE = 20f;

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
                newForce.y = -1 * Gravity.FORCE;
                this.constantForce.force = newForce;
                break;
            case Gravity.States.UP:
                newForce.y = Gravity.FORCE;
                this.constantForce.force = newForce;
                break;
        }
    }
}
