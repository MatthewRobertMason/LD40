using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LodInfo
{
    public GameObject lodObject = null;
    public float LODDistance = 100.0f;
}

public class Lod : MonoBehaviour
{
    public List<LodInfo> LodObjects = new List<LodInfo>() {
        new LodInfo() { lodObject = null, LODDistance = 100.0f },
        new LodInfo() { lodObject = null, LODDistance = float.PositiveInfinity }
    };

    private Camera LODCam = null;
    
	// Use this for initialization
	void Start ()
    {
        LODCam = GameController.FindObjectOfType<BusControl>().GetComponentsInChildren<Camera>()[0];

        LodInfo lastLod = LodObjects[0];
		foreach (LodInfo li in LodObjects)
        {
            if (li.LODDistance < lastLod.LODDistance)
            {
                throw new System.Exception("Invalid LOD");
            }
            lastLod = li;
        }
	}

    // Update is called once per frame
    void Update()
    {
        LodInfo lastLod = new LodInfo() { lodObject = null, LODDistance = 0.0f };

		foreach  (LodInfo li in LodObjects)
        {
            float distance = Vector3.Distance(this.transform.position, LODCam.transform.position);

            if (distance <= li.LODDistance &&
                distance > lastLod.LODDistance)
            {
                li.lodObject.SetActive(true);
            }
            else
            {
                li.lodObject.SetActive(false);
            }
        
            lastLod = li;
        }
	}
}
