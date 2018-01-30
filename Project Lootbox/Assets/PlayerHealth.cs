using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float Health;
    public GameObject Sword;
	public GameObject[] Arena;
	int AlternateID = 0;
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

	public void SwitchArena()
	{
		AlternateID = Mathf.Abs(AlternateID - 1);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sword" & other.gameObject != Sword)
        {
            DecrementHealth(Time.deltaTime * 20);
        }
		if (other.gameObject == Arena[AlternateID]) 
		{
			DecrementHealth (Time.deltaTime * 3);
		}
    }
}
