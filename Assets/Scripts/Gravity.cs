using UnityEngine;

public class Gravity : MonoBehaviour
{
    public enum States { DOWN, UP };
    protected Gravity.States state;
    protected new ConstantForce constantForce;

    // public float normalGravity = 9.81f; // normal gravity 
    // public float lowGravity = 4.0f;     // love gravity
    // public float highGravity = 20f;     // high gravity
    // private Rigidbody rb;
    // private int gravityMode = 0;         // 0: Normal Gravity, 1: Low Gravity, 2: High Gravity

    public virtual void Start()
    {
        this.constantForce = this.gameObject.GetComponent<ConstantForce>();
        this.UpdateGravity();

        // rb = GetComponent<Rigidbody>();  // rigid body of player 
        // rb.useGravity = true;            // making sure rigibody uses gravity
        // SetGravityMode(gravityMode);     // setting initial gravity mode
    }

    // void Update()
    // {
        // if (Input.GetKeyDown(KeyCode.Space)) // space key changes gravity mode
        // {
        //     SwitchGravityMode(); // function to switch modes
        // }

    // }

    public virtual void Update() {
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
            default:
                Debug.Log("Update Gravity: DEAD CODE");
                break;
        }
    }

    // void SwitchGravityMode()
    // {
    //     gravityMode = (gravityMode + 1) % 3; // cycling modes
    //     SetGravityMode(gravityMode);         // set new mode
    // }

    // void SetGravityMode(int mode)
    // {
    //     switch (mode)
    //     {
    //         case 0: 
    //             rb.gravityScale = normalGravity;
    //             break;
    //         case 1: 
    //             rb.gravityScale = lowGravity;
    //             break;
    //         case 2: 
    //             rb.gravityScale = highGravity;
    //             break;
    //         default:
    //             rb.gravityScale = normalGravity;
    //             break;
    //     }
    // }
}
