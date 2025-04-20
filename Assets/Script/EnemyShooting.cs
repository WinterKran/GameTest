using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2f;           // ความถี่ในการยิง (เช่น ทุก 2 วินาที)
    public float bulletSpeed = 7f;

    private float fireCooldown;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        fireCooldown = fireRate;
    }

    void Update()
    {
        if (player == null) return;

        fireCooldown -= Time.deltaTime;

        if (fireCooldown <= 0f)
        {
            FireAtPlayer();
            fireCooldown = fireRate;
        }
    }

    void FireAtPlayer()
    {
        // คำนวณทิศทางไปหา Player
        Vector2 direction = (player.position - firePoint.position).normalized;

        // สร้างกระสุน
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // ใส่ความเร็วให้กระสุน
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;
    }
}
