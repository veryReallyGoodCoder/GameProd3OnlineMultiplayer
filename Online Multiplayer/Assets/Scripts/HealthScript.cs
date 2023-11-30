using UnityEngine;

public class HealthScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        IPickupable item = other.GetComponent<IPickupable>();
        if (item != null)
        {
            item.OnPickup();
        }
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
