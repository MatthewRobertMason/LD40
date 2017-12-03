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

        //this.transform.LookAt(GameController.Player.transform.position);
        //Vector3 lookDirection = GameController.Player.transform.position - this.transform.position;
        //lookDirection.y = 0.0f;
        
        //this.transform.rotation.SetLookRotation(lookDirection);
	}

    void Jump(Vector3 playerPos) {
        Debug.Log("Jumping");
        Vector3 targetPos = (playerPos - transform.position);
        targetPos += new Vector3(0, 0.2f, 0);
        rb.AddForce(targetPos * jumpForce);
        hasJumped = true;
    }

    void OnCollisionEnter(Collision collision) {
        if (!hasBeenAdded 
            && (collision.gameObject.GetComponent<BusControl>() != null 
            ||  collision.gameObject.GetComponent<AiControl>() != null)) {
            //FixedJoint joint = gameObject.AddComponent<FixedJoint>();
            //joint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
            GameController.AttachPassenger();
            hasBeenAdded = true;
            Destroy(rb);
            this.transform.parent = GameController.Player.transform.Find("ClingOns");
        }        
    }
}
