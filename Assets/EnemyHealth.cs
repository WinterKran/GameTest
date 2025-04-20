using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // HP สูงสุดของศัตรู
    private int currentHealth; // HP ปัจจุบันของศัตรู

    public event Action OnDeath; // Event ที่จะถูกเรียกเมื่อศัตรูตาย

    void Start()
    {
        // กำหนดให้ HP เริ่มต้นเท่ากับ maxHealth
        currentHealth = maxHealth;
    }

    // ฟังก์ชันสำหรับรับความเสียหาย
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // ลด HP จากความเสียหายที่ได้รับ

        // ถ้า HP <= 0 หมายถึงศัตรูตาย
        if (currentHealth <= 0)
        {
            Die(); // เรียกฟังก์ชัน Die()
        }
    }

    // ฟังก์ชันสำหรับศัตรูตาย
    private void Die()
    {
        // ถ้ามีการสมัคร Event 'OnDeath' ให้เรียกมัน
        OnDeath?.Invoke();

        // ลบศัตรูออกจากโลก
        Destroy(gameObject);
    }


}
