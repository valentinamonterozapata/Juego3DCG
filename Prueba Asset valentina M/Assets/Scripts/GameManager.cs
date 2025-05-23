using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Image[] corazonesUI; // Máximo 5 corazones visibles
    public int totalCorazones = 10; // Total de corazones en la escena
    private int corazones = 0; // Corazones actuales del jugador (máx 5)
    private int corazonesRecolectados = 0; // Corazones recogidos en total

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        for (int i = 0; i < corazonesUI.Length; i++)
        {
            corazonesUI[i].enabled = false;
        }
    }

    public void AgregarCorazon()
    {
        if (corazonesRecolectados < totalCorazones)
        {
            corazonesRecolectados++;
            if (corazones < corazonesUI.Length)
            {
                corazones++;
                ActualizarCorazonesUI();
            }
        }
    }

    public void QuitarCorazon()
    {
        if (corazones > 0)
        {
            corazones--;
            ActualizarCorazonesUI();
        }
        RevisarFinDeJuego();
    }

    private void ActualizarCorazonesUI()
    {
        for (int i = 0; i < corazonesUI.Length; i++)
        {
            corazonesUI[i].enabled = i < corazones;
        }
    }

    private void RevisarFinDeJuego()
    {
        GameObject[] corazonesEnEscena = GameObject.FindGameObjectsWithTag("corazon");
        Debug.Log("Corazones en escena: " + corazonesEnEscena.Length + " | Corazones jugador: " + corazones);

        if (corazonesEnEscena.Length == 0 && corazones == 0)
        {
            Debug.Log("Reiniciando escena...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}



