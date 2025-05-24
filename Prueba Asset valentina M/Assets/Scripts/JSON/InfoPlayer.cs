using System;
using UnityEngine;

[System.Serializable]
public class InfoPlayer : MonoBehaviour
{
    public static InfoPlayer Instance; // Patrón Singleton

    public string lastSaveTime;
    internal string playerName;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persiste entre escenas
            CargarPartida(); // Carga automática al iniciar
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnApplicationQuit()
    {
        GuardarPartida(); // Guarda al salir
    }
    // Start is called before the first frame update
    
    public void CargarPartida()
    {
        if (PlayerPrefs.HasKey("PlayerData"))
        {
            string jsonData = PlayerPrefs.GetString("PlayerData");
            JsonUtility.FromJsonOverwrite(jsonData, this);
            Debug.Log("Datos CARGADOS: " + jsonData);
        }
        else
        {
            Debug.Log("No hay datos guardados. Iniciando nuevo juego.");
        }
    }

    public void GuardarPartida()
    {
        lastSaveTime = System.DateTime.Now.ToString();
        string jsonData = JsonUtility.ToJson(this);
        PlayerPrefs.SetString("PlayerData", jsonData);
        PlayerPrefs.Save(); // ¡IMPORTANTE!
        Debug.Log("Datos GUARDADOS: " + jsonData);
    }
}
