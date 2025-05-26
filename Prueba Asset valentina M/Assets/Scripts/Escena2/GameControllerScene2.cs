using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScene2 : MonoBehaviour
{
    public string nombreEscenaDestino = "escena3MR"; 
    public float distanciaRecoleccion = 3f;
    public AudioClip sonidoLlave;

    private bool tieneLlave = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IntentarRecogerLlave();
        }
    }

    void IntentarRecogerLlave()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        int capaLlave = 1 << LayerMask.NameToLayer("Key");

        if (Physics.Raycast(ray, out hit, distanciaRecoleccion, capaLlave))
        {
            Debug.Log("Raycast golpeó: " + hit.collider.name); // Verifica qué golpea

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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door") && tieneLlave)
        {
            Debug.Log("Entrando a la puerta con llave...");
            SceneManager.LoadScene(nombreEscenaDestino);
        }
    }
}
