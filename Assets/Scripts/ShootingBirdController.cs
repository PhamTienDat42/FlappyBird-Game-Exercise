using System.Collections;
using UnityEngine;

public class ShootingBirdController : Player
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed = 10f;

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.A))
        {
            SpecialSkill();
        }
    }

    protected override void SpecialSkill()
    {
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.SetActive(true);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = bullet.transform.right * bulletSpeed;
            StartCoroutine(DeactivateBullet(bullet));
        }
    }

    private IEnumerator DeactivateBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(1f);
        bullet.SetActive(false);
    }
}
