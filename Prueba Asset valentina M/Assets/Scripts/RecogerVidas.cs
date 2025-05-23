using UnityEngine;

public class RecogerVidas : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AgregarCorazon();
            Destroy(gameObject);
        }
    }
}



