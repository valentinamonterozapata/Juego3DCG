using UnityEngine.SceneManagement;

using UnityEngine;

/// <summary>
/// Controla la salud del jugador y maneja eventos de daño y muerte.
/// </summary>
/// <remarks>
/// Se comunica con el sistema de escenas para reiniciar el nivel al morir.
/// </remarks>
public class PlayerHealth : MonoBehaviour
{
    /// <summary>
    /// Salud máxima del jugador.
    /// </summary>
    public int maxHealth = 3;

    /// <summary>
    /// Salud actual del jugador (solo lectura desde otros scripts).
    /// </summary>
    public int currentHealth { get; private set; }

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("Salud inicial: " + currentHealth);
    }

    /// <summary>
    /// Aplica daño al jugador y verifica si ha muerto.
    /// </summary>
    /// <param name="damage">Cantidad de daño a aplicar.</param>
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Daño recibido. Salud actual: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Maneja la lógica de muerte del jugador.
    /// </summary>
    void Die()
    {
        Debug.Log("¡Jugador muerto!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}