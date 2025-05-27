using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; // Importa TextMeshPro

/// <summary>
/// este script maneja el menú principal del juego, incluyendo la navegación entre diferentes paneles,
/// para especificar lo que tienen que hacer los botones del menú, y la entrada del nombre del jugador.
/// </summary>

public class Menu : MonoBehaviour
{

    /// <summary>
    /// Paneles del menú principal.
    /// </summary>

    public GameObject opcionesPanel;
    public GameObject instruccionesPanel;
    public GameObject creditosPanel;
    public GameObject MostrarControles;
    public GameObject menuPrincipalPanel;
    public Slider volumeSlider;

    public GameObject panelIngresoNombre;

    public TMP_InputField inputNombre;

    /// <summary>
    /// Método para iniciar el juego y mostrar el panel de ingreso de nombre.   
    /// </summary>


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

    /// <summary>
    /// Muestra el panel de opciones: como bajar olumen y cargar del menú principal.
    /// </summary>

    public void MostrarOpciones()
    {
        CerrarTodosLosPaneles();
        opcionesPanel.SetActive(true);
    }

    /// <summary>
    /// Muestra el panel de instrucciones del juego.
    /// </summary>

    public void MostrarInstrucciones()
    {
        CerrarTodosLosPaneles();
        instruccionesPanel.SetActive(true);
    }

    /// <summary>
    /// Muestra el panel de créditos del juego.
    /// </summary>

    public void MostrarCreditos()
    {
        CerrarTodosLosPaneles();
        creditosPanel.SetActive(true);
    }

    /// <summary>
    /// Muestra el panel de controles de como manejar al player desde el teclado del juego.
    /// </summary>

    public void MostrarControless()
    {
        CerrarTodosLosPaneles();
        MostrarControles.SetActive(true);
    }

    /// <summary>
    /// Confirma el nombre ingresado por el jugador y lo guarda en PlayerPrefs.
    /// </summary>

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

        // Cargar escena
        SceneManager.LoadScene("Scene1VMZ");
    }

    /// <summary>
    /// Cierra la aplicación del juego cuando se presiona el botón de salir.
    /// </summary>
    public void Salir()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    /// <summary>
    /// cierra todos los paneles del menú principal para evitar superposiciones.
    /// </summary>
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