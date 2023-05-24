using UnityEngine;

public class ShootingBirdController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed = 10f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Create Obj bullet from Prefabs
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Set bullet speed
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = transform.right * bulletSpeed;
        Destroy(bullet, 3f);
    }
}
