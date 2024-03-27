using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField,Range(5f, 15f)] private int movementSpeed = 15;
    [SerializeField] private int jumpForce = 500;

    protected enum AnimStates { IDLE=0, RUN=1, JUMP=2, FALLING=3};
    protected Animator animator;
    protected new Rigidbody rigidbody;
    protected ConstantForce gravityForce;
    protected new CapsuleCollider collider;
    protected Transform cameraTransform;
    protected Transform modelTransform;
    protected ThirdPersonCamera cameraController;

    void Start()
    {
        this.animator = this.gameObject.GetComponent<Animator>();
        this.rigidbody = this.gameObject.GetComponent<Rigidbody>();
        this.gravityForce = this.gameObject.GetComponent<ConstantForce>();
        this.collider = this.gameObject.GetComponent<CapsuleCollider>();
        this.cameraTransform = this.transform.Find("Camera").transform;
        this.modelTransform = this.transform.Find("Model").transform;
        this.cameraController = this.cameraTransform.gameObject.GetComponent<ThirdPersonCamera>();
    }

    void Update()
    {
        // Process Player Ability Input
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameState.SwitchAbility();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameState.ToggleAbility();
            if (GameState.activeAbility == Ability.GRAVITY)
            {
                this.cameraController.Reorient();
                this.modelTransform.RotateAround(this.modelTransform.position, this.modelTransform.forward, 180f);
            }
        }

        // Process Player Input
        bool updateModelOrientation = false;
        Vector3 move = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) // Move Forward
        {
            move += this.modelTransform.forward;
            updateModelOrientation = true;
        }
        if (Input.GetKey(KeyCode.S)) // Move Backward
        {
            move += -1 * this.modelTransform.forward;
            updateModelOrientation = true;
        }
        if (Input.GetKey(KeyCode.A)) // Move Left
        {
            move += -1 * this.modelTransform.right;
            updateModelOrientation = true;
        }
        if (Input.GetKey(KeyCode.D)) // Move Right
        {
            move += this.modelTransform.right;
            updateModelOrientation = true;
        }

        bool animationSet = false;
        if (this.IsGrounded())
        {
            if (Input.GetButtonDown("Jump"))  // Can only jump when on the ground
            {
                this.animator.SetInteger("Animation", (int)AnimStates.JUMP);
                animationSet = true;
                this.rigidbody.AddForce(this.jumpForce * this.modelTransform.up);
            }
        } else
        {
            this.animator.SetInteger("Animation", (int)AnimStates.FALLING);
            animationSet = true;
        }

        // Interact with objects
        if (Input.GetButtonDown("Fire1"))
        {
            Collider[] colliders = Physics.OverlapSphere(this.modelTransform.position, 5f, 1 << LayerMask.NameToLayer("Interactables"));
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Terminal"))
                {
                    Vector3 dirToTerminal = Vector3.Normalize(collider.transform.position - this.modelTransform.position);
                    Vector3 dirCamera = this.cameraTransform.forward;
                    dirToTerminal.y = dirCamera.y = 0f;
                    if (Vector3.Dot(dirToTerminal, dirCamera) >= Mathf.Cos(0.25f * Mathf.PI))
                    {
                        collider.gameObject.GetComponent<Terminal>().TriggerTerminal();
                        break;
                    }
                }
            }
        }

        // Update Player Position and Model Orientation
        this.transform.position += (this.movementSpeed * Time.deltaTime * Vector3.Normalize(move));
        if (updateModelOrientation)
        {
            if (!animationSet)
            {
                animator.SetInteger("Animation", (int)AnimStates.RUN);
            }
            this.modelTransform.rotation = Quaternion.Slerp(
                this.modelTransform.rotation,
                Quaternion.Euler(0, this.cameraTransform.eulerAngles.y, this.modelTransform.eulerAngles.z),
                0.25f
            );
        }
        else if (!animationSet)
        {
            animator.SetInteger("Animation", (int)AnimStates.IDLE);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(this.modelTransform.position, this.modelTransform.up * -1, this.collider.height * 0.5f);
    }
}
