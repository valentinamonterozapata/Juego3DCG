using UnityEngine;
using System.Collections;

/// <summary>
/// Permite mostrar un modelo ampliado temporalmente cuando el usuario hace clic sobre el objeto.
/// </summary>
public class MostrarInfo : MonoBehaviour
{
    /// <summary>
    /// Objeto de vista previa que se mostrará de forma ampliada.
    /// Se oculta automáticamente al inicio.
    /// </summary>
    [Header("Objeto de Vista Previa")]
    public GameObject modeloAmpliado;

    /// <summary>
    /// Duración (en segundos) durante la cual el modelo ampliado será visible.
    /// </summary>
    public float duracionVista = 4f;

    /// <summary>
    /// Oculta el modelo ampliado al inicio de la escena.
    /// </summary>
    void Start()
    {
        if (modeloAmpliado != null)
        {
            modeloAmpliado.SetActive(false);
        }
    }

    /// <summary>
    /// Detecta el clic del usuario sobre el objeto y lanza la vista previa.
    /// </summary>
    void OnMouseDown()
    {
        StartCoroutine(MostrarVistaPreviaPorTiempo());
    }

    /// <summary>
    /// Corrutina que muestra el modelo ampliado durante un tiempo determinado
    /// y luego lo oculta automáticamente.
    /// </summary>
    IEnumerator MostrarVistaPreviaPorTiempo()
    {
        if (modeloAmpliado == null)
            yield break;

        modeloAmpliado.SetActive(true);
        yield return new WaitForSeconds(duracionVista);
        modeloAmpliado.SetActive(false);
    }
}
