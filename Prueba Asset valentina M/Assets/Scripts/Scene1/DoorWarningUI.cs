using UnityEngine;
using UnityEngine.UI;

public class DoorWarningUI : MonoBehaviour
{
    public GameObject warningPanel; // Arrastra el Panel aquí
    public float displayDistance = 3f; // Rango para mostrar aviso
    private Transform player;
    private Transform door;
    private PlayerKeySystem playerKeySystem;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        door = GameObject.FindGameObjectWithTag("Door").transform;
        playerKeySystem = player.GetComponent<PlayerKeySystem>();
        warningPanel.SetActive(false); // Oculta al inicio
    }

    void Update()
    {
        if (player == null || door == null) return;

        float distance = Vector3.Distance(player.position, door.position);

        // Muestra el aviso si está cerca y NO tiene llave
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