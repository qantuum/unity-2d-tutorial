using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUpScript : MonoBehaviour {

    public int restore = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerScript hero = collision.gameObject.GetComponent<PlayerScript>();
        if (hero != null)
        {
            HealthScript life = hero.gameObject.GetComponent<HealthScript>();
            life.Restore(restore);
            Destroy(gameObject);
        }
        else
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
    }
}
