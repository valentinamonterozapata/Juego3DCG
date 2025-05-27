using UnityEngine;

using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;
    private Animator anim;
    private bool isDead = false;
    public HUDZ healthUI; // Referencia al HUD de vidas
    public GameObject panelHasGanado;   

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        if (healthUI != null)
            healthUI.UpdateHearts(currentHealth);
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;

        if (healthUI != null)
            healthUI.UpdateHearts(currentHealth);

        if (anim != null)
            anim.SetTrigger("HitToHead");

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        isDead = true;

        if (anim != null)
            anim.SetTrigger("SwordAndShieldDead");

        // Mostrar el panel de victoria
        if (panelHasGanado != null)
            panelHasGanado.SetActive(true);

        // Opcional: Desactivar el zombie visualmente si quieres
        // gameObject.SetActive(false);

        // Esperar 3 segundos y luego cambiar escena si quieres
        Invoke(nameof(EndScene), 3f);

        // También puedes destruir el objeto zombie si quieres
        Destroy(gameObject, 3f);
    }

    void EndScene()
    {
        
    }
}