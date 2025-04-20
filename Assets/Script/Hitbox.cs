using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ตรวจสอบว่าเราชนกับ Enemy หรือไม่
        if (other.CompareTag("Enemy"))
        {
            // การโจมตีเกิดขึ้นที่นี่ เช่น ลด HP ของ Enemy
            EnemyHP enemyHealth = other.GetComponent<EnemyHP>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(10); // ลด HP ของ Enemy
            }
        }
    }
}
