using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioRandomizer : MonoBehaviour
{
    public AudioClip[] clips = null;
    private AudioSource source = null;

	// Use this for initialization
	void Start ()
    {
        source = this.GetComponent<AudioSource>();

        int index = Random.Range(0, clips.Length);
        source.Stop();
        source.clip = clips[index];
        source.loop = true;
        source.Play();
    }
}
