using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Referencias a los paneles de Opciones, Instrucciones y Créditos
    public GameObject opcionesPanel;
    public GameObject instruccionesPanel;
    public GameObject creditosPanel;

    // Referencia al panel principal del menú
    public GameObject menuPrincipalPanel;

    // Método para el botón "Jugar"
    public void Jugar()
    {
        // Cargar la escena llamada "Scene1VMZ"
        SceneManager.LoadScene("Scene1VMZ");
    }

    // Método para el botón "Opciones"
    public void MostrarOpciones()
    {
        CerrarTodosLosPaneles();
        opcionesPanel.SetActive(true);
    }

    // Método para el botón "Instrucciones"
    public void MostrarInstrucciones()
    {
        CerrarTodosLosPaneles();
        instruccionesPanel.SetActive(true);
    }

    // Método para el botón "Créditos"
    public void MostrarCreditos()
    {
        CerrarTodosLosPaneles();
        creditosPanel.SetActive(true);
    }

    // Método para el botón "Salir"
    public void Salir()
    {
        // Salir del juego
        Application.Quit();
#if UNITY_EDITOR
        // Si estás en el editor, detener el modo de juego
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    // Método para cerrar todos los paneles
    private void CerrarTodosLosPaneles()
    {
        opcionesPanel.SetActive(false);
        instruccionesPanel.SetActive(false);
        creditosPanel.SetActive(false);
        menuPrincipalPanel.SetActive(false);
    }

    // Método para el botón "Volver al Menú Principal"
    public void VolverAlMenuPrincipal()
    {
        CerrarTodosLosPaneles();
        menuPrincipalPanel.SetActive(true);
    }
}



