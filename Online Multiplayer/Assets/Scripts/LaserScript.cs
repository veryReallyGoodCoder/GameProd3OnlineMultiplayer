using UnityEngine;
using Mirror;

public class LaserScript : NetworkBehaviour
{

    public Transform laserPoint;
    public TrailRenderer laserBeam;

    public int damage = 20;

    private void Update()
    {
        
        if(isLocalPlayer && Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        else if (!isLocalPlayer)
        {
            return;
        }
    }

    public void Shoot()
    {
        Ray ray = new Ray(laserPoint.position, laserPoint.forward);
        TrailRenderer beam = Instantiate(laserBeam, laserPoint.position, Quaternion.identity);
        beam.AddPosition(laserPoint.position);

        if(Physics.Raycast(ray, out RaycastHit hit, 50f))
        {
            beam.transform.position = hit.point;

            var playerHealth = hit.collider.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth)
            {
                playerHealth.TakeDamage(damage);
            }
       
        }
        else
        {
            beam.transform.position = laserPoint.position + (laserPoint.forward * 50);
        }
    }

}
