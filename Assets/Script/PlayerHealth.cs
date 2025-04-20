using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Slider healthSlider;

    public Transform respawnPoint;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            GameManager.Instance.PlayerDied(); // ✅ อัปเดต High Score
            Respawn();
        }
    }

    void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / maxHealth;
        }
    }

    void Respawn()
    {
        transform.position = respawnPoint.position;
        rb.velocity = Vector2.zero;
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RespawnZone"))
        {
            TakeDamage(20);
        }

        if (other.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }

        if (other.CompareTag("Bullet"))
        {
            TakeDamage(20);
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealthUI();
    }
}
