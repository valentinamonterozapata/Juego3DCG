using UnityEngine;

/// <summary>
/// Controla la interacción con una maleta en la escena.
/// Al hacer clic sobre ella, muestra un panel de código si aún no está visible.
/// </summary>
public class Maleta : MonoBehaviour
{
    /// <summary>
    /// Referencia al panel de interfaz de usuario que contiene el código o combinación.
    /// Se oculta al iniciar la escena.
    /// </summary>
    public GameObject panelCodigoUI;

    /// <summary>
    /// Oculta el panel de código al iniciar la escena.
    /// </summary>
    void Start()
    {
        panelCodigoUI.SetActive(false);
    }

    /// <summary>
    /// Muestra el panel de código al hacer clic sobre la maleta,
    /// si aún no está visible.
    /// </summary>
    void OnMouseDown()
    {
        if (!panelCodigoUI.activeSelf)
        {
            panelCodigoUI.SetActive(true);
        }
    }
}
