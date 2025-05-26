using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// Este script controla la recolección de corazones en el juego.
/// Es el que actuaiza la UI de los corazones y reinicia la escena si el jugador no tiene corazones.
/// </summary>

public class GameController3 : MonoBehaviour
{
    /// <summary>
    /// Referencia a la instancia del GameManager.
    /// </summary>
    public static GameController3 Instance;

    /// <summary>
    /// Array de imágenes que representan los corazones en la UI.
    /// </summary>
    public Image[] corazonesUI;

    /// <summary>
    /// Contador de corazones recolectados por el jugador.
    /// </summary>
    private int corazones = 0;

    /// <summary>
    /// Método Awake se llama al iniciar el juego.
    /// </summary>
    void Awake()
    {
        {
            if (Instance == null)
            {
                Instance = this;
                // DontDestroyOnLoad(gameObject); 
            }
            else
            {
                Destroy(gameObject);
            }
        }
        }
    /// <summary>
    /// Método Start se llama al inicio del juego,para que oculte los corazones en la UI apenas comienze la escena.
    /// </summary>
    private void Start()
    {
        OcultarCorazonesUI();
    }
    /// <summary>
    /// Método que agrega un corazón al contador y actualiza la UI.
    /// </summary>
    public void AgregarCorazon()
    {
        if (corazones < corazonesUI.Length)
        {
            corazones++;
            ActualizarCorazonesUI();
        }
    }
    /// <summary>
    /// Método que devuelve la cantidad de corazones recolectados por el jugador.
    /// </summary>
    /// <returns></returns>
    public int CantidadCorazones()
    {
        return corazones;
    }

    public void ReiniciarEscena()
    {
        corazones = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Actualiza la UI de los corazones según la cantidad de corazones recolectados.
    /// </summary>
    private void ActualizarCorazonesUI()
    {
        for (int i = 0; i < corazonesUI.Length; i++)
        {
            corazonesUI[i].enabled = i < corazones;
        }
    }

    /// <summary>
    /// Método que quita un corazón al contador y actualiza la UI.
    /// </summary>
    public void QuitarCorazon()
    {
        if (corazones > 0)
        {
            corazones--;
            ActualizarCorazonesUI();
        }
        if (corazones == 0)
        {
            ReiniciarEscena();
        }
    }
    /// <summary>
    /// Método que oculta los corazones en la UI.
    /// </summary>
    private void OcultarCorazonesUI()
    {
        for (int i = 0; i < corazonesUI.Length; i++)
        {
            corazonesUI[i].enabled = false;
        }
    }
}




