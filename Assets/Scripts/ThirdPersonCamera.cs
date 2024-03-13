using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] float turnSpeed = 4f;
    [SerializeField] GameObject target;
    protected float targetDistance;
    protected float minTurnAngle = -80f;
    protected float maxTurnAngle = 50f;
    protected float rotX;
    protected float rotZ;


    // Start is called before the first frame update
    void Start()
    {
        this.rotX = 0f;
        targetDistance = Vector3.Distance(this.transform.position, this.target.transform.position);
        this.Reorient();
    }

    // Update is called once per frame
    void Update()
    {
        float inverse = (GameState.gravityState == Gravity.States.DOWN) ? 1 : -1;
        float rotY = Input.GetAxis("Mouse X") * this.turnSpeed * inverse;
        this.rotX += Input.GetAxis("Mouse Y") * this.turnSpeed * inverse;

        this.rotX = Mathf.Clamp(this.rotX, this.minTurnAngle, this.maxTurnAngle);
        this.transform.eulerAngles = new Vector3(-this.rotX, this.transform.eulerAngles.y + rotY, this.rotZ);
        this.transform.position = this.target.transform.position - (this.transform.forward * this.targetDistance);
    }

    public void Reorient()
    {
        this.rotX *= -1;
        this.rotZ = (GameState.gravityState == Gravity.States.DOWN)? 0f : 180f;
    }
}
