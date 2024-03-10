using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] float turnSpeed = 4f;
    [SerializeField] GameObject target;
    protected float targetDistance;
    protected float minTurnAngle = -90f;
    protected float maxTurnAngle = 30f;
    protected float rotX;


    // Start is called before the first frame update
    void Start()
    {
        targetDistance = Vector3.Distance(this.transform.position, this.target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Mouse X") * this.turnSpeed;
        this.rotX += Input.GetAxis("Mouse Y") * this.turnSpeed;

        rotX = Mathf.Clamp(this.rotX, minTurnAngle, maxTurnAngle);
        this.transform.eulerAngles = new Vector3(-this.rotX, this.transform.eulerAngles.y + y, 0);
        this.transform.position = this.target.transform.position - (this.transform.forward * targetDistance);
    }
}
