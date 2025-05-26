using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

/// <summary>
/// Este script controla la escena 3, donde permite cambiar de escena si el jugador ha recolectado 5 corazones,
/// de lo contrario muestra un mensaje si el jugador intenta pasar de escena sin recolectar los 5 corazones.
/// </summary>

public class Espada : MonoBehaviour
{ 
    /// <summary>
    /// Nombre de la siguiente escena a cargar cuando el jugador recolecta 5 corazones.
    /// </summary>
    public string nombreSiguienteEscena = "Scene4";

    /// <summary>
    /// Referencia al componente TextMeshProUGUI que muestra el mensaje al jugador.
    /// </summary>
    public TextMeshProUGUI mensajeEspada;

    /// <summary>
    /// Duracion en segundos del mensaje que se muestra al jugador cuando intenta pasar de escena sin recolectar los 5 corazones.
    /// </summary>
    public float duracionMensaje = 7f;


    /// <summary>
    /// Este método se llama cuando otro collider entra en el trigger del objeto al que este script está adjunto.
    /// Verifica si el objeto que es el Player y si ha recolectado los 5 corazones que son  necesarios par avanzar.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameController3.Instance.CantidadCorazones() == 5)
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

    /// <summary>
    /// Muestra un mensaje en pantalla al jugador.
    /// </summary>
    /// <param name="mensaje">el mensaje que se mostrará al jugador.</param> 

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
    /// <summary>
    /// Desactiva el mensaje después de un tiempo determinado.
    /// </summary>
    /// <returns></returns>
    private IEnumerator DesactivarMensaje()
    {
        yield return new WaitForSeconds(duracionMensaje);
        mensajeEspada.gameObject.SetActive(false);
    }
}

