using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; // Importa TextMeshPro
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    public GameObject opcionesPanel;
    public GameObject instruccionesPanel;
    public GameObject instruccionesPane2;
    public GameObject creditosPanel;
    public GameObject menuPrincipalPanel;

    public GameObject panelIngresoNombre;

    public TMP_InputField inputNombre; // Cambiado a TMP_InputField

    public void Jugar()
    {
        // Mostrar panel de ingreso de nombre
        panelIngresoNombre.SetActive(true);

        // Ocultar el menú principal
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
    public void Siguiente()
    {
        CerrarTodosLosPaneles();
        instruccionesPane2.SetActive(true);
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

        // Cargar escena
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
    }

    
    public void VolverAlMenuPrincipal()
    {
        CerrarTodosLosPaneles();
        menuPrincipalPanel.SetActive(true);
    }
}



