using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerKeySystem : MonoBehaviour
{
    [Header("Configuración Llave")]
    public bool hasKey = false;
    public TextMeshProUGUI keyCounterText; // Arrastra el Texto del Canvas aquí
    public float pickupRange = 3f; // Rango para recoger con clic
    public AudioClip pickupSound; // Opcional

    [Header("Configuración Puerta")]
    public string nextSceneName = "Scene2EC";
    public AudioClip doorSound; // Opcional

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Click izquierdo
        {
            TryPickupKey();
        }
    }

    void TryPickupKey()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Añade una LayerMask para filtrar solo la capa de la llave
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

    void UpdateKeyUI()
    {
        if (keyCounterText != null)
            keyCounterText.text = "Llave: " + (hasKey ? "1" : "0");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door") && hasKey)
        {
            if (doorSound != null)
                AudioSource.PlayClipAtPoint(doorSound, transform.position);

            SceneManager.LoadScene(nextSceneName);
        }
    }
}