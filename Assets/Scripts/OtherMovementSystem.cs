using UnityEngine;
using System.Collections;

public class OtherMovementSystem : MonoBehaviour {
    public OVRPlayerController ovr;


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -70f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, 70f * Time.deltaTime);
        }
	}

    void OnEnable()
    {
        ovr.RotationAmount = 0;
        ovr.RotationRatchet = 0;
    }

    void OnDisable()
    {
        ovr.RotationAmount = 1.5f;
        ovr.RotationRatchet = 45f;
    }
}
