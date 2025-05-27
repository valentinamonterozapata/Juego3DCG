using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controlador de escena para recolección de una llave y transición a una nueva escena al llegar a una puerta.
/// </summary>
public class GameControllerScene2 : MonoBehaviour
{
    /// <summary>
    /// Nombre de la escena a cargar cuando el jugador tenga la llave y entre en contacto con la puerta.
    /// </summary>
    public string nombreEscenaDestino = "escena3MR";

    /// <summary>
    /// Distancia máxima desde la cual el jugador puede recoger la llave.
    /// </summary>
    public float distanciaRecoleccion = 3f;

    /// <summary>
    /// Sonido que se reproduce al recoger la llave.
    /// </summary>
    public AudioClip sonidoLlave;

    /// <summary>
    /// Indica si el jugador ha recogido la llave.
    /// </summary>
    private bool tieneLlave = false;

    /// <summary>
    /// Detecta clics del mouse para intentar recoger la llave mediante raycast.
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IntentarRecogerLlave();
        }
    }

    /// <summary>
    /// Realiza un raycast desde la cámara hacia la posición del mouse para detectar
    /// si el jugador ha hecho clic sobre un objeto etiquetado como "Key".
    /// Si se detecta una llave dentro del rango, se recoge y se destruye el objeto.
    /// </summary>
    void IntentarRecogerLlave()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        int capaLlave = 1 << LayerMask.NameToLayer("Key");

        if (Physics.Raycast(ray, out hit, distanciaRecoleccion, capaLlave))
        {
            Debug.Log("Raycast golpeó: " + hit.collider.name);

            if (hit.collider.CompareTag("Key"))
            {
                tieneLlave = true;
                Destroy(hit.collider.gameObject);

                if (sonidoLlave != null)
                {
                    AudioSource.PlayClipAtPoint(sonidoLlave, hit.point);
                }

                Debug.Log("¡Llave recogida!");
            }
        }
        else
        {
            Debug.Log("Raycast no golpeó nada");
        }
    }

    /// <summary>
    /// Detecta colisiones con el trigger de la puerta.
    /// Si el jugador tiene la llave, se carga la nueva escena.
    /// </summary>
    /// <param name="other">Colisionador del objeto con el que se entra en contacto.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door") && tieneLlave)
        {
            Debug.Log("Entrando a la puerta con llave...");
            SceneManager.LoadScene(nombreEscenaDestino);
        }
    }
}
