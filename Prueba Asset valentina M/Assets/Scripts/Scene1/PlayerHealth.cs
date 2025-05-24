using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth { get; private set; }

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("Salud inicial: " + currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Daño recibido. Salud actual: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("¡Jugador muerto!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}