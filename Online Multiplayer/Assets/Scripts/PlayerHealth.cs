using UnityEngine;
using Mirror;

public class PlayerHealth : NetworkBehaviour
{

    [SyncVar]
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            health = 0;
            gameObject.SetActive(false);
            Debug.Log("You Died");
        }
    }

}
