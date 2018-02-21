using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed;
    private Touch mTouch;
    public string HorizontalInput;
    public string VerticalInput;
    
    private Rigidbody rig;
    // Use this for initialization

    void Start () {
        rig = GetComponent<Rigidbody>();
	}

    // Update is called once per frame

    void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch t in Input.touches)
            {
                Ray ray = Camera.main.ScreenPointToRay(t.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.name == gameObject.name)
                    {
                        mTouch = t;
                        Debug.Log("User tapped on game object " + hit.collider.gameObject.name);
                    }
                }
                if (t.phase == TouchPhase.Moved)
                {
                    Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, 10));
                    touchedPos.y = 1;
                    AttemptMove(touchedPos - transform.position);
                }
            }
            

        }
        
    }

    void FixedUpdate () {
        Vector3 Movement;

//#if UNITY_STANDALONE || UNITY_WEBPLAYER

        float moveHori = Input.GetAxis(HorizontalInput);
        float moveVert = Input.GetAxis(VerticalInput);
        Movement = new Vector3(moveHori,0,-moveVert);

        


    }

    protected void AttemptMove(Vector3 move)
    {
        rig.velocity = move * speed;
    }

}
