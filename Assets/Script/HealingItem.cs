using UnityEngine;

public class HealingItem : MonoBehaviour
{
    public int healAmount = 20; // จำนวน HP ที่เพิ่ม
    private HealingItemSpawner spawner; // ตัวแปรเพื่อเก็บ HealingItemSpawner

    private void Start()
    {
        // หาตัว HealingItemSpawner ที่อยู่ใกล้
        spawner = FindObjectOfType<HealingItemSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // เพิ่ม HP ให้ Player
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount); // เรียกฟังก์ชัน Heal ใน PlayerHealth
            }

            // ทำให้ Healing Object หายไป
            Destroy(gameObject);

            // เรียกฟังก์ชันใน Spawner ให้สร้าง Healing Item ใหม่
            if (spawner != null)
            {
                spawner.OnHealingItemDestroyed();
            }
        }
    }
}
