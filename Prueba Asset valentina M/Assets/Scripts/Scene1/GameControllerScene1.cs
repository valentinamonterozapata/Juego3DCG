using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScene1 : MonoBehaviour
{
    [Header("Configuración Llave")]
    /// <summary>
    /// Indica si el jugador tiene la llave.
    /// </summary>
    public bool hasKey = false;

    /// <summary>
    /// Texto UI que muestra el estado de la llave.
    /// </summary>
    public TextMeshProUGUI keyCounterText;

    /// <summary>
    /// Rango para recoger llaves.
    /// </summary>
    public float pickupRange = 3f;

    /// <summary>
    /// Sonido al recoger una llave.
    /// </summary>
    public AudioClip pickupSound;

    [Header("Configuración Puerta")]
    /// <summary>
    /// Nombre de la escena a cargar al interactuar con la puerta.
    /// </summary>
    public string nextSceneName = "Scene2EC";

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryPickupKey();
        }
    }

    /// <summary>
    /// Intenta recoger una llave mediante un raycast.
    /// </summary>
    void TryPickupKey()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        int keyLayerMask = 1 << LayerMask.NameToLayer("Key");

        if (Physics.Raycast(ray, out hit, pickupRange, keyLayerMask))
        {
            if (hit.collider.CompareTag("Key"))
            {
                hasKey = true;
                UpdateKeyUI();
                Destroy(hit.collider.gameObject);

                if (pickupSound != null)
                    AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            }
        }
    }

    /// <summary>
    /// Actualiza el contador de llaves en la UI.
    /// </summary>
    void UpdateKeyUI()
    {
        if (keyCounterText != null)
            keyCounterText.text = "Llave: " + (hasKey ? "1" : "0");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door") && hasKey)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
