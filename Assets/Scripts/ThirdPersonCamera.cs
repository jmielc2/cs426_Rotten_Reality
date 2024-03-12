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


    // Start is called before the first frame update
    void Start()
    {
        targetDistance = Vector3.Distance(this.transform.position, this.target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        float rotY = Input.GetAxis("Mouse X") * this.turnSpeed;
        this.rotX += Input.GetAxis("Mouse Y") * this.turnSpeed;

        this.rotX = Mathf.Clamp(this.rotX, this.minTurnAngle, this.maxTurnAngle);
        this.transform.eulerAngles = new Vector3(-this.rotX, this.transform.eulerAngles.y + rotY, 0);
        this.transform.position = this.target.transform.position - (this.transform.forward * this.targetDistance);
    }
}
