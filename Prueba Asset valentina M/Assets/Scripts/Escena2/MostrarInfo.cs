using UnityEngine;
using System.Collections;

public class MostrarInfo : MonoBehaviour
{
    [Header("Objeto de Vista Previa")]
    public GameObject modeloAmpliado;      // Objeto duplicado, más grande, oculto al inicio
    public float duracionVista = 4f;       // Tiempo que se mostrará en pantalla

    void Start()
    {
        if (modeloAmpliado != null)
        {
            modeloAmpliado.SetActive(false); // Ocultar al principio
        }
    }

    void OnMouseDown()
    {
        StartCoroutine(MostrarVistaPreviaPorTiempo());
    }

    IEnumerator MostrarVistaPreviaPorTiempo()
    {
        if (modeloAmpliado == null)
            yield break;

        modeloAmpliado.SetActive(true);                      // Mostrar objeto
        yield return new WaitForSeconds(duracionVista);     // Esperar duración
        modeloAmpliado.SetActive(false);                    // Ocultar objeto
    }
}
