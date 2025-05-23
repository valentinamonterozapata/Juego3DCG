using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class Espada : MonoBehaviour
{
    public string nombreSiguienteEscena = "Scene4"; 
    public TextMeshProUGUI mensajeEspada; 
    public float duracionMensaje = 7f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance.CantidadCorazones() == 5)
            {
                SceneManager.LoadScene(nombreSiguienteEscena);
            }
            else
            {
                MostrarMensaje("¡RECOLECTA LOS 5 CORAZONES ANTES DE CONTINUAR !" +
                                 "TEN CUIDADO CON LAS ESTATUAS");
            }
        }
    }

    private void MostrarMensaje(string mensaje)
    {
        Debug.Log("Intentando mostrar mensaje: " + mensaje);
        if (mensajeEspada != null)
        {
            mensajeEspada.text = mensaje;
            mensajeEspada.gameObject.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(DesactivarMensaje());
        }
        else
        {
            Debug.LogWarning("mensajeEspada no está asignado en el Inspector.");
        }
    }

    private IEnumerator DesactivarMensaje()
    {
        yield return new WaitForSeconds(duracionMensaje);
        mensajeEspada.gameObject.SetActive(false);
    }
}

