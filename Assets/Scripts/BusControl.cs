using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

public class BusControl : MonoBehaviour
{
    public bool controlEnabled = true;

    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;

    public Vector3 centerOfMass = new Vector3(0.0f, -1.0f, 0.0f);
    private Quaternion initialRotation = new Quaternion();

    public void Start()
    {
        this.GetComponent<Rigidbody>().centerOfMass = centerOfMass;
        initialRotation = this.transform.rotation;
    }

    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {
        if(controlEnabled)
        {
            float motor = maxMotorTorque * Input.GetAxis("Vertical");
            float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

            foreach (AxleInfo axleInfo in axleInfos)
            {
                if (axleInfo.steering)
                {
                    axleInfo.leftWheel.steerAngle = steering;
                    axleInfo.rightWheel.steerAngle = steering;
                }
                if (axleInfo.motor)
                {
                    axleInfo.leftWheel.motorTorque = motor;
                    axleInfo.rightWheel.motorTorque = motor;
                }
                ApplyLocalPositionToVisuals(axleInfo.leftWheel);
                ApplyLocalPositionToVisuals(axleInfo.rightWheel);
            }
        }

        Vector3 lookDirection = new Vector3(this.transform.forward.x, 0.0f, this.transform.forward.z);
        this.transform.rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
    }

    private void OnTriggerEnter(Collider other) {
        RemoveControlAndCamera();
        GameController.GameOver = true;
    }

    public void RemoveControlAndCamera() {
        controlEnabled = false;
        Camera cam = gameObject.GetComponentInChildren<Camera>();
        if (cam != null) {
            cam.transform.SetParent(null);
        }
    }
}