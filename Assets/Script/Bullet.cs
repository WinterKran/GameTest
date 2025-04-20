using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 5f;

    void Start()
    {
        Destroy(gameObject, lifeTime); // ทำลายกระสุนหลัง 5 วิ
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // TODO: หัก HP Player ที่นี่
            Debug.Log("Player hit by bullet!");
            Destroy(gameObject);
        }

        if (!other.isTrigger) // กันยิงทะลุกำแพง
        {
            Destroy(gameObject);
        }
    }
}
