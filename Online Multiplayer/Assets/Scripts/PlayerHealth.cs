using UnityEngine;
using Mirror;

public class PlayerHealth : NetworkBehaviour
{

    [SyncVar]
    public int health = 100;

    private int damage = 20;

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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            TakeDamage(damage);
        }
    }

}
