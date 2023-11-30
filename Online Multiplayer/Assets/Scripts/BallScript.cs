using UnityEngine;

public class BallScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        IDamagable damagable = other.GetComponent<IDamagable>();
        if(damagable != null)
        {
            damagable.OnDamage();
        }
    }
}
