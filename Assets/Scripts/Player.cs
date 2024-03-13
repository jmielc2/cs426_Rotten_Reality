using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField,Range(5f, 15f)] private int movementSpeed = 15;
    [SerializeField] private int jumpForce = 500;

    protected new Rigidbody rigidbody;
    protected ConstantForce gravityForce;
    protected new CapsuleCollider collider;
    protected Transform cameraTransform;
    protected Transform modelTransform;
    protected ThirdPersonCamera cameraController;

    void Start()
    {
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

        // Process Player Movement Input
        bool updateModelOrientation = false;
        Vector3 move = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            move += this.modelTransform.forward;
            updateModelOrientation = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            move += -1 * this.modelTransform.forward;
            updateModelOrientation = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            move += -1 * this.modelTransform.right;
            updateModelOrientation = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move += this.modelTransform.right;
            updateModelOrientation = true;
        }
        if (this.IsGrounded())
        {
            if (Input.GetButtonDown("Jump"))
            {
                this.rigidbody.AddForce(this.jumpForce * this.modelTransform.up);
            }
        }

        // Update Player Position and Model Orientation
        this.transform.position += (this.movementSpeed * Time.deltaTime * Vector3.Normalize(move));
        if (updateModelOrientation)
        {
            this.modelTransform.rotation = Quaternion.Slerp(
                this.modelTransform.rotation, 
                Quaternion.Euler(0, this.cameraTransform.eulerAngles.y, this.modelTransform.eulerAngles.z),
                0.35f
            );
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(this.modelTransform.position, this.modelTransform.up * -1, this.collider.height * 0.5f);
    }
}
