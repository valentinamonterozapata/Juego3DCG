using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public int maxHealth = 5;          // Vida total
    private int currentHealth;         // Vida actual
    private Animator anim;             // Referencia al Animator
    private bool isDead = false;       // Estado muerte

    void Start()
    {
        currentHealth = maxHealth;     // Inicializa la vida
        anim = GetComponent<Animator>(); // Obtiene Animator
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;            // Ignorar si está muerto

        currentHealth -= amount;       // Resta vida

        if (anim != null)
            anim.SetTrigger("HitToHead"); // Activa animación de golpe

        if (currentHealth <= 0)
            Die();                    // Si vida ≤ 0, muere
    }

    void Die()
    {
        isDead = true;
        if (anim != null)
            anim.SetTrigger("SwordAndShieldDead"); // Animación de muerte

        Destroy(gameObject, 3f);       // Destruye el objeto después de 3s
    }
}
