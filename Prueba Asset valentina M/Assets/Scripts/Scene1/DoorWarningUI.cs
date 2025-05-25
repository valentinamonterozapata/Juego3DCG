using UnityEngine;

/// <summary>
/// Controla la visualización de advertencias cuando el jugador se acerca a una puerta sin llave.
/// </summary>
/// <remarks>
/// Depende de <see cref="PlayerKeySystem"/> para verificar el estado de la llave.
/// </remarks>
public class DoorWarningUI : MonoBehaviour
{
    /// <summary>
    /// Panel de UI que muestra la advertencia.
    /// </summary>
    public GameObject warningPanel;

    /// <summary>
    /// Distancia a la que se muestra la advertencia.
    /// </summary>
    public float displayDistance = 3f;

    private Transform player;
    private Transform door;
    private PlayerKeySystem playerKeySystem;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        door = GameObject.FindGameObjectWithTag("Door").transform;
        playerKeySystem = player.GetComponent<PlayerKeySystem>();
        warningPanel.SetActive(false);
    }

    void Update()
    {
        if (player == null || door == null) return;

        float distance = Vector3.Distance(player.position, door.position);

        if (distance <= displayDistance && !playerKeySystem.hasKey)
        {
            warningPanel.SetActive(true);
        }
        else
        {
            warningPanel.SetActive(false);
        }
    }
}