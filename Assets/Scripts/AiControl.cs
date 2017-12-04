using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JumpSound
{
    public AudioClip sound;
    public int weight = 1;
}

public class AiControl : MonoBehaviour {

    public float jumpDist = 15f;    
    public float jumpForce = 100f;
    
    private Rigidbody rb;
    private bool hasJumped = false;
    private bool hasBeenAdded = false;
    
    public List<JumpSound> jumpSounds;
    private AudioSource audioSource = null;
    
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        audioSource = this.GetComponent<AudioSource>();
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
        PlayJumpSound();
        Vector3 targetPos = (playerPos - transform.position);
        targetPos += new Vector3(0, 0.2f, 0);
        rb.AddForce(targetPos * jumpForce);
        hasJumped = true;
    }

    void OnCollisionEnter(Collision collision) {
        var other_ai = collision.gameObject.GetComponent<AiControl>();
        if (!hasBeenAdded 
            && (collision.gameObject.GetComponent<BusControl>() != null 
            ||  other_ai != null)) 
        {
            if(other_ai != null && !other_ai.hasBeenAdded){
                return;
            }

            this.transform.position += Vector3.up;

            GameController.AttachPassenger();
            hasBeenAdded = true;
            Destroy(rb);
            this.transform.parent = GameController.Player.transform.Find("ClingOns");
        }        
    }

    private void PlayJumpSound()
    {
        int maxTrackToPlay = 0;

        foreach(JumpSound js in jumpSounds)
        {
            maxTrackToPlay += js.weight;
        }

        int trackToPlay = Random.Range(0, maxTrackToPlay);
        int trackId = 0;

        foreach (JumpSound js in jumpSounds)
        {
            trackToPlay -= js.weight;

            if (trackToPlay <= 0)
            {
                audioSource.PlayOneShot(js.sound);
                return;
            }

            trackId++;
        }
    }
}
