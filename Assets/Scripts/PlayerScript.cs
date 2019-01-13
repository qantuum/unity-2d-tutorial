using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    /// <summary>
    /// 1 - The speed of the ship
    /// </summary>
    public Vector2 speed = new Vector2(50, 50);

    // 2 - Store the movement and the component
    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;

    void Update()
    {
        // 3 - Retrieve axis information
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");


        // block player from going off-screen !!!
        var bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);

        var topRight = Camera.main.ScreenToWorldPoint(new Vector3(
            Camera.main.pixelWidth, Camera.main.pixelHeight));

        var cameraRect = new Rect(
            bottomLeft.x,
            bottomLeft.y,
            topRight.x - bottomLeft.x,
            topRight.y - bottomLeft.y);
        transform.position = new Vector3(
        Mathf.Clamp(transform.position.x, cameraRect.xMin, cameraRect.xMax),
        Mathf.Clamp(transform.position.y, cameraRect.yMin, cameraRect.yMax),
        transform.position.z);
        


        // 4 - Movement per direction
        movement = new Vector2(
          speed.x * inputX,
          speed.y * inputY);



        // 5 - Shooting
        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");
        // Careful: For Mac users, ctrl + arrow is a bad idea

        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                // false because the player is not an enemy
                weapon.Attack(false);
            }

        }
    }

    void FixedUpdate()
    {
        // 5 - Get the component and store the reference
        if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

        // 6 - Move the game object
        rigidbodyComponent.velocity = movement;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        bool damagePlayer = false;

        // Collision with enemy
        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            // Kill the enemy
            HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
            if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp);

            damagePlayer = true;
        }

        // Damage the player
        if (damagePlayer)
        {
            HealthScript playerHealth = this.GetComponent<HealthScript>();
            if (playerHealth != null) playerHealth.Damage(1);
        }
    }

    // on hero's death
    void OnDestroy()
    {
        Canvas.FindObjectOfType<PauseMenu>().pauseMenuUI.SetActive(true);
        Button[] buttons = PauseMenu.FindObjectsOfType<Button>();
        // turning off "Resume button" in the menu after death of the hero
        buttons[1].interactable = false;
    }
}
