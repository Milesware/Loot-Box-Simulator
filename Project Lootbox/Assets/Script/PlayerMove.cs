using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed;
    private Rigidbody rig;
    public string HorizontalInput;
    public string VerticalInput;
	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHori = Input.GetAxis(HorizontalInput);
        float moveVert = Input.GetAxis(VerticalInput);
        Vector3 movement = new Vector3(moveHori,0,-moveVert);
        rig.velocity = movement * speed;
        
        
	}
}
