using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maleta : MonoBehaviour
{
    public GameObject panelCodigoUI;
    private bool yaAbierta = false;

    void Start()
    {
        panelCodigoUI.SetActive(false); // Oculta el panel al inicio
    }

    void OnMouseDown()
    {
        if (yaAbierta) return; // No abre si ya fue abierta

        panelCodigoUI.SetActive(true); // Muestra el panel

        // Limpia el display usando el método Borrar()
        CajaFuerte caja = panelCodigoUI.GetComponent<CajaFuerte>();
        if (caja != null)
        {
            caja.Borrar();
        }
    }

    // Método llamado desde CajaFuerte cuando se abre correctamente
    public void BloquearMaleta()
    {
        yaAbierta = true;
    }
}
