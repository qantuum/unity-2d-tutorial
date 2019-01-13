using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{

    /// <summary>
    /// Total hitpoints
    /// </summary>
    /// 
    public int maxHealth = 1;
    public int hp = 1;

    public Slider HealthBar;

    public Image DamageImg;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.9f);
    bool damaged; 

    /// <summary>
    /// Enemy or player?
    /// </summary>
    public bool isEnemy = true;

    void Update()
    {
        OnHeroDamage();
    }

    /// <summary>
    /// Inflicts damage and check if the object should be destroyed
    /// </summary>
    /// <param name="damageCount"></param>
    public void Damage(int damageCount)
    {
        hp -= damageCount;
     
        if (hp <= 0)
        {
           
           
            // Dead!
            Destroy(gameObject);

            if (isEnemy == true)
            {
                ManageScore.score +=10;
            }
        }

        // updating the Hero's HealthBar
        if (isEnemy == false)
        {
            damaged = true;
            HealthBar.value = hp;
        }
    }

    public void Restore(int healCount)
    {
        if (hp < maxHealth)
        {
            if (hp + healCount < maxHealth)
            {
                hp += healCount;
            }
            else
            {
                hp = maxHealth;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Is this a shot?
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            // Avoid friendly fire
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);

                // Destroy the shot
                Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
            }
        }
    }

    // changing the colour for a moment to show that the hero was damaged
    void OnHeroDamage()
    {
        if (isEnemy == false)
        {
            if (damaged)
            {
                SpecialEffectsHelper.Instance.Explosion(transform.position);
                DamageImg.color = flashColour;
                DamageImg.color = Color.Lerp(DamageImg.color, Color.clear, flashSpeed * Time.deltaTime);
            }
            else
            {
                DamageImg.color = Color.clear;
            }
            damaged = false;
        }
    }
}