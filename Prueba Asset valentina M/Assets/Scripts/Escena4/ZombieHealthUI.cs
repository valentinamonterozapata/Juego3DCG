using UnityEngine;
using UnityEngine.UI;

public class ZombieHealthUI : MonoBehaviour
{
    public Image[] hearts;    // Arrastra aquí tus 5 Image

    /// <summary>
    /// Llama a este método para refrescar la UI de corazones.
    /// </summary>
    public void UpdateHearts(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
            hearts[i].enabled = (i < currentHealth);
    }
}