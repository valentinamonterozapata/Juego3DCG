using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public GameObject puerta; // Asigna la PuertaSalida en el Inspector

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            puerta.SetActive(false); // Desactiva la puerta
            Destroy(gameObject); // Destruye la llave
        }
    }
}