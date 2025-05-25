using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Configuración de salud")]
    public int MaxHealth = 5;      // Corazones totales al iniciar

    private int _currentHealth;    // Cambiado a un campo privado con un guion bajo
    private HUD hud;

    void Start()
    {
        // 1) Referencia al HUD de la escena
        hud = FindObjectOfType<HUD>();
        if (hud == null) Debug.LogError("HUD no encontrado en la escena");

        // 2) Inicializa vida al máximo
        _currentHealth = MaxHealth;

        // 3) Refresca el HUD
        hud.UpdateHearts(_currentHealth);
    }

    /// <summary>
    /// Resta 'amount' de vida, actualiza el HUD y recarga la escena al llegar a 0.
    /// </summary>
    public void takeDamage(int amount)
    {
        _currentHealth = Mathf.Max(_currentHealth - amount, 0);
        Debug.Log($"PlayerHealth: daño {amount}, vida restante = {_currentHealth}");

        if (hud != null)
            hud.UpdateHearts(_currentHealth);

        if (_currentHealth == 0)
        {
            Debug.Log("PlayerHealth: ¡Muerto! Reiniciando escena...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}