using UnityEngine;
using UnityEngine.SceneManagement;

public class Espada : MonoBehaviour
{
    // Nombre de la escena a cargar
    public string nombreEscena = "Scene4";

    // Método que se ejecuta cuando algo entra en el trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que colisiona tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            // Cargar la escena 4
            SceneManager.LoadScene(nombreEscena);
        }
    }
}
