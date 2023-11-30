using UnityEngine;

public class HealthScript : MonoBehaviour
{

    public float healthRespawnTime = 5;

    private void OnTriggerEnter(Collider other)
    {
        IPickupable item = other.GetComponent<IPickupable>();
        if (item != null)
        {
            item.OnPickup();

            gameObject.SetActive(false);
            Invoke("RespawnHealth", healthRespawnTime);
        }
    }

    private void RespawnHealth()
    {
        gameObject.SetActive(true);
    }

    /*[SerializeField] private float coolDown = 10;
    
        float timer = coolDown;
        timer -= Time.deltaTime;
        Debug.Log(timer);

        if (timer <= 0)
        {
            timer = 0;
            //gameObject.SetActive(true);

            this.gameObject.GetComponent<Renderer>().enabled = true;
    */
}
