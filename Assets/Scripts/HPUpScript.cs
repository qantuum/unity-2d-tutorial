using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUpScript : MonoBehaviour {

    public int restore = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        string colliderName = otherCollider.gameObject.name;
        if (colliderName == "Hero")
        {
            HealthScript life = otherCollider.GetComponent<HealthScript>();
            life.hp++;
            Destroy(this.gameObject);
        }
    }
}
