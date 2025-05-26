using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; // Importa TextMeshPro

public class Menu : MonoBehaviour
{
    public GameObject opcionesPanel;
    public GameObject instruccionesPanel;
    public GameObject creditosPanel;
    public GameObject MostrarControles;
    public GameObject menuPrincipalPanel;
    public Slider volumeSlider;

    public GameObject panelIngresoNombre;

    public TMP_InputField inputNombre;

    private bool isPaused = false;

    void Start()
    {
        float volume = PlayerPrefs.GetFloat("volume", 1f); // valor por defecto 1 (máximo)
        AudioListener.volume = volume;

        if (volumeSlider != null)
        {
            volumeSlider.value = volume;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }

        if (opcionesPanel != null)
            opcionesPanel.SetActive(false);
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

    public void Pause()
    {
        if (opcionesPanel != null)
            opcionesPanel.SetActive(true);

        Time.timeScale = 0f;  // Pausar el juego
        isPaused = true;
    }

    public void Resume()
    {
        if (opcionesPanel != null)
            opcionesPanel.SetActive(false);

        Time.timeScale = 1f;  // Reanudar el juego
        isPaused = false;
    }

    // Resto de tus métodos originales (Jugar, MostrarOpciones, ConfirmarNombre, etc.)

    public void Jugar()
    {
        panelIngresoNombre.SetActive(true);
        menuPrincipalPanel.SetActive(false);
    }

    public void MostrarOpciones()
    {
        CerrarTodosLosPaneles();
        opcionesPanel.SetActive(true);
    }

    public void MostrarInstrucciones()
    {
        CerrarTodosLosPaneles();
        instruccionesPanel.SetActive(true);
    }

    public void MostrarCreditos()
    {
        CerrarTodosLosPaneles();
        creditosPanel.SetActive(true);
    }

    public void MostrarControless()
    {
        CerrarTodosLosPaneles();
        MostrarControles.SetActive(true);
    }

    public void ConfirmarNombre()
    {
        string nombreJugador = inputNombre.text;

        if (string.IsNullOrEmpty(nombreJugador))
        {
            Debug.Log("Por favor ingresa un nombre válido.");
            return;
        }

        Debug.Log("Nombre ingresado: " + nombreJugador);

        PlayerPrefs.SetString("NombreJugador", nombreJugador);

        SceneManager.LoadScene("Scene1VMZ");
    }

    public void Salir()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private void CerrarTodosLosPaneles()
    {
        opcionesPanel.SetActive(false);
        instruccionesPanel.SetActive(false);
        creditosPanel.SetActive(false);
        menuPrincipalPanel.SetActive(false);
        MostrarControles.SetActive(false);
    }

    public void VolverAlMenuPrincipal()
    {
        CerrarTodosLosPaneles();
        menuPrincipalPanel.SetActive(true);
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("volume", volume);
    }
}