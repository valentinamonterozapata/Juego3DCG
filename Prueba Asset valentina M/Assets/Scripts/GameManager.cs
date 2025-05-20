using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Image[] corazonesUI;
    private int corazones = 0;

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
        corazones++;
        ActualizarCorazonesUI();
    }

    private void ActualizarCorazonesUI()
    {
        for (int i = 0; i < corazonesUI.Length; i++)
        {
            corazonesUI[i].enabled = i < corazones;
        }
    }
}


