using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int movementSpeed = 8;
    [SerializeField] private int jumpForce = 400;

    protected Ability selectedAbility;
    protected new Rigidbody rigidbody;
    protected ConstantForce gravityForce;
    protected new CapsuleCollider collider;
    protected Transform cameraTransform;
    protected Transform modelTransform;

    // Start is called before the first frame update
    public void Start()
    {
        this.selectedAbility = Ability.GRAVITY;
        this.rigidbody = this.gameObject.GetComponent<Rigidbody>();
        this.gravityForce = this.gameObject.GetComponent<ConstantForce>();
        this.collider = this.gameObject.GetComponent<CapsuleCollider>();
        this.cameraTransform = this.transform.Find("Camera").transform;
        this.modelTransform = this.transform.Find("Model").transform;
    }

    // Update is called once per frame
    public void Update()
    {
        // Update Abilities
        if (Input.GetKeyDown(KeyCode.R))
        {
            this.selectedAbility = GameState.GetNextAbility(this.selectedAbility);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameState.ToggleAbility(this.selectedAbility);
        }

        // Update Player Movement
        bool updateModelOrientation = false;
        Vector3 move = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            move += this.movementSpeed * this.modelTransform.forward;
            updateModelOrientation = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            move += (-1 * this.movementSpeed * this.modelTransform.forward);
            updateModelOrientation = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            move += (-1 * this.movementSpeed * this.modelTransform.right);
            updateModelOrientation = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move += (this.movementSpeed * this.modelTransform.right);
            updateModelOrientation = true;
        }
        if (this.IsGrounded())
        {
            if (Input.GetButtonDown("Jump"))
            {
                this.rigidbody.AddForce(this.jumpForce * this.modelTransform.up);
            }
        }

        this.transform.position += (move * Time.deltaTime);
        if (updateModelOrientation)
        {
            this.modelTransform.rotation = Quaternion.Slerp(
                this.modelTransform.rotation, 
                Quaternion.Euler(0, this.cameraTransform.eulerAngles.y, 0),
                0.3f
            );
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(this.modelTransform.position, this.modelTransform.up * -1, this.collider.height / 2);
    }
}
