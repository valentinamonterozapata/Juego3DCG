using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Image[] corazonesUI; 
    private int corazones = 0; 
    
    void Awake()
    {
        {
            if (Instance == null)
            {
                Instance = this;
                // DontDestroyOnLoad(gameObject); // Elimina o comenta esta línea
            }
            else
            {
                Destroy(gameObject);
            }
        }
        }

    private void Start()
    {
        OcultarCorazonesUI();
    }

    public void AgregarCorazon()
    {
        if (corazones < corazonesUI.Length)
        {
            corazones++;
            ActualizarCorazonesUI();
        }
    }

    public int CantidadCorazones()
    {
        return corazones;
    }

    public void ReiniciarEscena()
    {
        corazones = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ActualizarCorazonesUI()
    {
        for (int i = 0; i < corazonesUI.Length; i++)
        {
            corazonesUI[i].enabled = i < corazones;
        }
    }

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

    private void OcultarCorazonesUI()
    {
        for (int i = 0; i < corazonesUI.Length; i++)
        {
            corazonesUI[i].enabled = false;
        }
    }
}




