using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class GuardarCargar : MonoBehaviour
{
    [Header("Referencias UI")]
    public TMP_InputField nombreTMPInputField; // InputField de TMP

    [Header("Configuraci�n")]
    public float autosaveInterval = 60f; // Guardado autom�tico cada X segundos
    private float nextAutosaveTime;

    void Start()
    {
        // Carga inicial al iniciar
        CargarDatos();

        // Configura el autoguardado
        nextAutosaveTime = Time.time + autosaveInterval;
    }

    void Update()
    {
        // Autoguardado peri�dico
        if (Time.time > nextAutosaveTime)
        {
            GuardarDatos();
            nextAutosaveTime = Time.time + autosaveInterval;
     
        }
    }

    // ==================== M�TODOS P�BLICOS ====================
    // Llamar desde el bot�n "Guardar"
    public void GuardarDatos()
    {
        try
        {
            // Actualiza los datos desde la UI
            if (nombreTMPInputField != null && !string.IsNullOrWhiteSpace(nombreTMPInputField.text))
            {
                InfoPlayer.Instance.playerName = nombreTMPInputField.text;
            }

            InfoPlayer.Instance.lastSaveTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            InfoPlayer.Instance.GuardarPartida();

        }
        catch (System.Exception e)
        {
            Debug.LogError("Error al guardar: " + e.Message);
        
        }
    }

    // Llamar desde el bot�n "Cargar"
    public void CargarDatos()
    {
        try
        {
            InfoPlayer.Instance.CargarPartida();
         
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error al cargar: " + e.Message);
 
        }
    }

    // Llamar desde el bot�n "Nueva Partida"
    public void NuevaPartida()
    {
        InfoPlayer.Instance.playerName = "";
        InfoPlayer.Instance.lastSaveTime = "";
       
    }

    // ==================== EVENTOS UNITY ====================
    void OnApplicationQuit()
    {
        GuardarDatos();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus) // Si la app se minimiza
        {
            GuardarDatos();
        }
    }
}