using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab ของ Enemy
    public float respawnTime = 10f; // เวลาที่ Enemy จะ respawn ใหม่
    private GameObject currentEnemy; // ตัว Enemy ที่อยู่ในโลก

    void Start()
    {
        // สร้าง Enemy เริ่มต้น
        SpawnEnemy();
    }

    // ฟังก์ชันสำหรับ Spawn Enemy
    void SpawnEnemy()
    {
        if (currentEnemy == null)
        {
            // สร้าง Enemy ที่ตำแหน่งของ Spawner
            currentEnemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
            // เพิ่มฟังก์ชันเรียกเมื่อ Enemy ถูกทำลาย
            EnemyHealth enemyHealth = currentEnemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                // ตั้งให้เมื่อ Enemy ถูกทำลายจะเรียกฟังก์ชัน OnEnemyDestroyed
                enemyHealth.OnDeath += OnEnemyDestroyed;
            }
        }
    }

    // ฟังก์ชันที่เรียกเมื่อ Enemy ถูกทำลาย
    public void OnEnemyDestroyed()
    {
        // รอเวลาที่กำหนดก่อน respawn Enemy ใหม่
        StartCoroutine(RespawnEnemy());
    }

    // Coroutine ที่จะ respawn Enemy หลังจากเวลาที่กำหนด
    private IEnumerator RespawnEnemy()
    {
        yield return new WaitForSeconds(respawnTime);
        SpawnEnemy(); // สร้าง Enemy ใหม่
    }
}
