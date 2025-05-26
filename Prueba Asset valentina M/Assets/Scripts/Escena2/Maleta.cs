using UnityEngine;

public class Maleta : MonoBehaviour
{
    public GameObject panelCodigoUI;

    void Start()
    {
        panelCodigoUI.SetActive(false); // Ocultar al inicio
    }

    void OnMouseDown()
    {
        if (!panelCodigoUI.activeSelf)
        {
            panelCodigoUI.SetActive(true); // Mostrar panel al hacer clic
        }
    }
}