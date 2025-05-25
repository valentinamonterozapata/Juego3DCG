using UnityEngine;
/// <summary>
/// Este script controla la recolección de vidas´por el player en el juego,
/// al tener contacto con el player, se agrega un corazon al GameManager y se destruye el objeto.
/// </summary>
public class RecogerVidas : MonoBehaviour
{
    /// <summary>
    /// Este método se llama cuando otro collider entra en el trigger del objeto al que este script está adjunto.
    /// Verifica si el objeto que es el Player y si ha recolectado los 5 corazones que son  necesarios par avanzar.
    /// </summary>
    /// <param name="other">Collider del objeto que entra en el trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AgregarCorazon();
            Destroy(gameObject);
        }
    }
}



