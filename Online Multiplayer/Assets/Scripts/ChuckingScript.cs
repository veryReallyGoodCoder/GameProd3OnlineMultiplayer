using Mirror;
using Unity.VisualScripting;
using UnityEngine;

public class ChuckingScript : NetworkBehaviour
{
    public Transform throwingPoint;

    public GameObject ballPrefab;

    [SerializeField] private int damage = 20;
    [SerializeField] private int throwForce = 50;

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer && Input.GetMouseButtonDown(0))
        {
            Chuck();
        }
        else if (!isLocalPlayer)
        {
            return;
        }
    }

    public void Chuck()
    {
        
        GameObject ball = Instantiate(ballPrefab, throwingPoint.position, throwingPoint.rotation);
        Rigidbody ballRb = ball.GetComponent<Rigidbody>();

        ballRb.AddForce(throwingPoint.forward * throwForce, ForceMode.Impulse);

        Destroy(ball, 3);
        //Debug.Log("shoot");

    }

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.tag == "Player")
        {
            var playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("damage");
            }
        }

    }
}
