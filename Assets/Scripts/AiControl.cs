using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiControl : MonoBehaviour {

    public float jumpDist = 15f;    
    public float jumpForce = 100f;

    private Rigidbody rb;
    private bool hasJumped = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPos = GameController.Player.transform.position;
        float distToPlayer = Vector3.Distance(transform.position, playerPos);
        if (!hasJumped && distToPlayer <= jumpDist) {
            Jump(playerPos);
        }
	}

    void Jump(Vector3 playerPos) {
        print("jumping");
        rb.AddForce((playerPos - transform.position) * jumpForce);
        hasJumped = true;
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponent<BusControl>() != null) {
            FixedJoint joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
        }        
    }
}
