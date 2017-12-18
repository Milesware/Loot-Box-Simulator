using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float Health;
    public GameObject Sword;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(GetHealth() <= 0)
        {
            Destroy(this.gameObject);
            Destroy(Sword);
        }
	}

    public float GetHealth()
    {
        return Health;
    }

    public void DecrementHealth(float decrease)
    {
        Health -= decrease;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sword" & other.gameObject != Sword)
        {
            DecrementHealth(Time.deltaTime * 20);
        }
    }
}
