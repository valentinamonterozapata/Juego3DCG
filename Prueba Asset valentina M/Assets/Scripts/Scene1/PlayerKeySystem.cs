using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerKeySystem : MonoBehaviour
{
    [Header("Configuración Llave")]
    public bool hasKey = false;
    public TextMeshProUGUI keyCounterText;
    public float pickupRange = 3f;
    public AudioClip pickupSound;

    [Header("Configuración Puerta")]
    public string nextSceneName = "Scene2EC";
    public AudioClip doorSound;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryPickupKey();
        }
    }

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