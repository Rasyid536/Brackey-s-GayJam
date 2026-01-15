using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Bullet")]
    public GameObject bulletPrefab;
    [Header("Fire Rate")]
    public float fireRate = 0.1f; // waktu antar peluru

    float fireTimer;

    void Update()
    {
        fireTimer -= Time.deltaTime;

        if (Input.GetMouseButton(0) && fireTimer <= 0f)
        {
            Fire();
            fireTimer = fireRate;
        }
    }

    void Fire()
    {
        // Instantiate peluru di posisi & rotasi object ini
        GameObject bullet = Instantiate(
            bulletPrefab,
            transform.position,
            transform.rotation
        );
    }
}
