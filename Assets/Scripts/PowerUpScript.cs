using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {

    public int add = 1;
    public string type = "hitPoints";

    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerScript hero = collision.gameObject.GetComponent<PlayerScript>();
        if (hero != null)
        {
            switch (type)
            {
                case "hitPoints":
                    HealthScript life = hero.gameObject.GetComponent<HealthScript>();
                    life.Restore(add);
                    Destroy(gameObject);
                    break;
                case "shootingRate":
                    WeaponScript weapon = hero.gameObject.GetComponent<WeaponScript>();
                    weapon.shootingRate *= (float) 0.8;
                    Destroy(gameObject);
                    break;
            }            
        }
        else
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }       
    }
}
