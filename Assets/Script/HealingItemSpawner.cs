using System.Collections;
using UnityEngine;

public class HealingItemSpawner : MonoBehaviour
{
    public GameObject healingItemPrefab; // Prefab ของ Healing Item
    public float respawnTime = 10f; // เวลาที่ Healing Item จะ respawn ใหม่
    private GameObject currentHealingItem; // ตัว Healing Item ที่อยู่ในโลก

    void Start()
    {
        // สร้าง Healing Item เริ่มต้น
        SpawnHealingItem();
    }

    // ฟังก์ชันสำหรับ Spawn Healing Item
    void SpawnHealingItem()
    {
        if (currentHealingItem == null)
        {
            // สร้าง Healing Item ที่ตำแหน่งของ Spawner
            currentHealingItem = Instantiate(healingItemPrefab, transform.position, transform.rotation);
        }
    }

    // ฟังก์ชันที่เรียกเมื่อ Healing Item ถูกเก็บหรือทำลาย
    public void OnHealingItemDestroyed()
    {
        // รอเวลาที่กำหนดก่อน respawn Healing Item ใหม่
        StartCoroutine(RespawnHealingItem());
    }

    // Coroutine ที่จะ respawn Healing Item หลังจากเวลา
    private IEnumerator RespawnHealingItem()
    {
        yield return new WaitForSeconds(respawnTime);
        SpawnHealingItem(); // สร้าง Healing Item ใหม่
    }
}
