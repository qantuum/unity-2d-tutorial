using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUpScript : MonoBehaviour {

    public int restore = 1;

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        PlayerScript hero = otherCollider.gameObject.GetComponent<PlayerScript>();
        if (hero != null)
        {
            HealthScript life = hero.gameObject.GetComponent<HealthScript>();
            life.hp = life.hp + restore;
            
        }
        Destroy(gameObject);
    }
}
