using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // bergerak ke depan sesuai rotasi saat ini
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
