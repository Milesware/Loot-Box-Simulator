using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed;
    public string HorizontalInput;
    public string VerticalInput;

    private Touch mTouch;
    private Vector3 lastPosition;
    private Rigidbody rig;
    // Use this for initialization

    void Start () {
        rig = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 Movement;

//#if UNITY_STANDALONE || UNITY_WEBPLAYER

        float moveHori = Input.GetAxis(HorizontalInput);
        float moveVert = Input.GetAxis(VerticalInput);
        Movement = new Vector3(moveHori,0,-moveVert);
        
        if (Input.touchCount > 0)
        {
            foreach(Touch t in Input.touches)
            {
                if (t.phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(t.position);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        Debug.Log("User tapped on game object " + hit.collider.gameObject.name);
                        if (hit.collider.gameObject == this)
                        {
                            mTouch = t;
                            lastPosition = hit.transform.position;
                        }
                    }
                }
                if (t.phase == TouchPhase.Moved)
                {
                    Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(mTouch.position.x, mTouch.position.y, 10));
                    transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);

                }
            }
            
        }

    }

    protected void AttemptMove(Vector3 move)
    {
        rig.velocity = move * speed;
    }

}
