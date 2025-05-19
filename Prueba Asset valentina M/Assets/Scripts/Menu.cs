using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    public GameObject opcionesPanel;
    public GameObject instruccionesPanel;
    public GameObject instruccionesPane2;
    public GameObject creditosPanel;


    
    public GameObject menuPrincipalPanel;

    
    public void Jugar()
    {
        
        SceneManager.LoadScene("Scene1VMZ");
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



