using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Referencias a los paneles de Opciones, Instrucciones y Cr�ditos
    public GameObject opcionesPanel;
    public GameObject instruccionesPanel;
    public GameObject creditosPanel;

    // Referencia al panel principal del men�
    public GameObject menuPrincipalPanel;

    // M�todo para el bot�n "Jugar"
    public void Jugar()
    {
        // Cargar la escena llamada "Scene1VMZ"
        SceneManager.LoadScene("Scene1VMZ");
    }

    // M�todo para el bot�n "Opciones"
    public void MostrarOpciones()
    {
        CerrarTodosLosPaneles();
        opcionesPanel.SetActive(true);
    }

    // M�todo para el bot�n "Instrucciones"
    public void MostrarInstrucciones()
    {
        CerrarTodosLosPaneles();
        instruccionesPanel.SetActive(true);
    }

    // M�todo para el bot�n "Cr�ditos"
    public void MostrarCreditos()
    {
        CerrarTodosLosPaneles();
        creditosPanel.SetActive(true);
    }

    // M�todo para el bot�n "Salir"
    public void Salir()
    {
        // Salir del juego
        Application.Quit();
#if UNITY_EDITOR
        // Si est�s en el editor, detener el modo de juego
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    // M�todo para cerrar todos los paneles
    private void CerrarTodosLosPaneles()
    {
        opcionesPanel.SetActive(false);
        instruccionesPanel.SetActive(false);
        creditosPanel.SetActive(false);
        menuPrincipalPanel.SetActive(false);
    }

    // M�todo para el bot�n "Volver al Men� Principal"
    public void VolverAlMenuPrincipal()
    {
        CerrarTodosLosPaneles();
        menuPrincipalPanel.SetActive(true);
    }
}



