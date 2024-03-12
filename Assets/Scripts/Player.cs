using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int movementSpeed = 5;
    [SerializeField] private int jumpForce = 500;

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

        this.transform.position += (this.movementSpeed * Time.deltaTime * Vector3.Normalize(move));
        if (updateModelOrientation)
        {
            this.modelTransform.rotation = Quaternion.Slerp(
                this.modelTransform.rotation, 
                Quaternion.Euler(0, this.cameraTransform.eulerAngles.y, 0),
                0.35f
            );
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(this.modelTransform.position, this.modelTransform.up * -1, this.collider.height * 0.5f);
    }
}
