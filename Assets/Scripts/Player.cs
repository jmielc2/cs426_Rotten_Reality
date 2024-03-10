using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int movementSpeed = 10;

    protected Ability selectedAbility;
    protected Vector3 mousePositionPrev;
    protected CharacterController controller;
    protected Transform cameraTransform;
    protected Transform modelTransform;

    // Start is called before the first frame update
    public void Start()
    {
        this.selectedAbility = Ability.GRAVITY;
        this.mousePositionPrev = Input.mousePosition;
        this.controller = this.gameObject.GetComponent<CharacterController>();
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
        Vector3 move = Vector3.zero;
        bool updateModelOrientation = false;
        if (Input.GetKey(KeyCode.W))
        {
            move += this.modelTransform.forward;
            updateModelOrientation = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            move += (this.modelTransform.forward * -1);
            updateModelOrientation = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            move += (this.modelTransform.right * -1);
            updateModelOrientation = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move += this.transform.right;
            updateModelOrientation = true;
        }
        if (updateModelOrientation)
        {
            this.modelTransform.rotation = Quaternion.Slerp(
                this.modelTransform.rotation, 
                Quaternion.Euler(0, this.cameraTransform.eulerAngles.y, 0),
                0.25f);
        }
        this.controller.Move(this.movementSpeed * Time.deltaTime * Vector3.Normalize(move));
    }
}
