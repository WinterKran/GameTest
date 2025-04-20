using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackHitboxPrefab; // Prefab ของ Hitbox
    public float attackDuration = 0.5f; // เวลาที่ Hitbox จะอยู่
    public Transform attackPoint; // จุดที่เกิด Hitbox (จะเป็นตำแหน่งมือหรือที่ไหนก็ได้)

    private void Update()
    {
        // กดปุ่มโจมตี (สามารถเปลี่ยนปุ่มได้)
        if (Input.GetButtonDown("Fire1"))
        {
            // เรียกฟังก์ชันโจมตี
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        // สร้าง Hitbox ที่จุด Attack Point
        GameObject hitbox = Instantiate(attackHitboxPrefab, attackPoint.position, attackPoint.rotation);

        // ทำให้ Hitbox อยู่ในโลกแค่ช่วงเวลาที่กำหนด (attackDuration)
        Destroy(hitbox, attackDuration);

        // รอจนกว่า Hitbox จะหายไป
        yield return new WaitForSeconds(attackDuration);
    }
}
