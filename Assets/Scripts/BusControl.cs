using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusControl : MonoBehaviour
{
    public float enginePower = 100.0f;
    public float maxDriveSpeed = 5.0f;
    public float breakRatio = 1.0f;

    [Range(0.0f, 90.0f)]
    public float maxSteerAngle = 45.0f;


    public WheelCollider frontLeftWheel = null;
    public WheelCollider frontRightWheel = null;
    public WheelCollider backLeftWheel = null;
    public WheelCollider backRightWheel = null;
    
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        PerformMovement();
    }

    private void PerformMovement()
    {
        //Input.GetAxis("Horizontal");
        //Input.GetAxis("Vertical");
        //Input.GetButton("Gas");
        //Input.GetButton("Break");
        //Input.GetButton("Boost");

        float steerAngle = Input.GetAxis("Horizontal") * maxSteerAngle;

        frontLeftWheel.steerAngle = steerAngle;
        frontRightWheel.steerAngle = steerAngle;

        if (Input.GetButton("Gas"))
        {
            float velocity = maxDriveSpeed * Time.deltaTime * enginePower;

            frontLeftWheel.brakeTorque = 0.0f;
            frontRightWheel.brakeTorque = 0.0f;
            backLeftWheel.brakeTorque = 0.0f;
            backRightWheel.brakeTorque = 0.0f;

            backLeftWheel.motorTorque = velocity;
            backRightWheel.motorTorque = velocity;
        }
        else
        {
            backLeftWheel.motorTorque = 0.0f;
            backRightWheel.motorTorque = 0.0f;
        }

        if (Input.GetButton("Break"))
        {
            float breakingForce = this.GetComponent<Rigidbody>().mass * breakRatio;

            frontLeftWheel.brakeTorque = breakingForce;
            frontRightWheel.brakeTorque = breakingForce;
            backLeftWheel.brakeTorque = breakingForce;
            backRightWheel.brakeTorque = breakingForce;

            backLeftWheel.motorTorque = 0.0f;
            backRightWheel.motorTorque = 0.0f;
        }
        else
        {
            frontLeftWheel.brakeTorque = 0.0f;
            frontRightWheel.brakeTorque = 0.0f;
            backLeftWheel.brakeTorque = 0.0f;
            backRightWheel.brakeTorque = 0.0f;
        }
    }
}
