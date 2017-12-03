using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiControl : MonoBehaviour {

    public float jumpDist = 15f;    
    public float jumpForce = 100f;
    
    private Rigidbody rb;
    private bool hasJumped = false;
    private bool hasBeenAdded = false;
    
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
        Vector3 targetPos = (playerPos - transform.position);
        targetPos += new Vector3(0, 0.2f, 0);
        rb.AddForce(targetPos * jumpForce);
        hasJumped = true;
    }

    void OnCollisionEnter(Collision collision) {
        if (!hasBeenAdded && (collision.gameObject.GetComponent<BusControl>() != null || collision.gameObject.GetComponent<AiControl>() != null)) {
            //FixedJoint joint = gameObject.AddComponent<FixedJoint>();
            //joint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();

            GameController.AttachPassenger();
            hasBeenAdded = true;
            Destroy(rb);
            this.transform.parent = GameController.Player.transform.Find("ClingOns");
        }        
    }
}
