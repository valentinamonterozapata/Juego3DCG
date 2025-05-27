using UnityEngine.SceneManagement;
using UnityEngine;


public class PausaEscena1 : MonoBehaviour
{
    public GameObject opciones;  // Panel de pausa

    private bool isPaused = false;

    void Start()
    {
        if (opciones != null)
            opciones.SetActive(false);  // Panel oculto al inicio

        Time.timeScale = 1f; // Juego normal
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    void Pause()
    {
        if (opciones != null)
            opciones.SetActive(true);

        Time.timeScale = 0f;
        isPaused = true;
    }

    void Resume()
    {
        if (opciones != null)
            opciones.SetActive(false);

        Time.timeScale = 1f;
        isPaused = false;
    }

    // Métodos para los botones, asignar en el Inspector

    public void BotonVolver()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu"); // O nombre correcto de tu escena menú
    }

    public void BotonSalir()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void BotonJugar()
    {
        Resume();
    }
}