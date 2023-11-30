using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class PlayerHealth : NetworkBehaviour, IPickupable
{

    [SyncVar]
    public float health = 100;

    private int damage = 20;

    [SerializeField] public int healthInc = 20;

    [SerializeField] private Slider healthBar;

    public Canvas canvas;

    private void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            canvas.enabled = false;
            return;
        }
        else
        {
            UpdateHealthBar();

        }


    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        Debug.Log("taking damage");

        if(health <= 0)
        {
            health = 0;
            gameObject.SetActive(false);
            Debug.Log("You Died");
        }
    }

    public void OnPickup()
    {
        if(health >= 100)
        {
            health = 100;
        }
        else
        {
            health += healthInc;
        }

        Debug.Log(health);

    }

    public void UpdateHealthBar()
    {
        //float currHealth = health;

        //healthBar.value = health / 100;
        healthBar.normalizedValue = health / 100;

        //Debug.Log("healthbar update " + healthBar.value);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            TakeDamage(damage);
        }
    }

    

}
