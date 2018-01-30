using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour {

	public PlayerHealth Health;
	public GameObject HealthBar;

	// Use this for initialization
	void Start () {
		
	}

	void Update () {
		float y = HealthBar.gameObject.transform.localScale.y;
		float z = HealthBar.gameObject.transform.localScale.z;
		HealthBar.gameObject.transform.localScale.Set(Health.Health, y ,z);
	}
}
