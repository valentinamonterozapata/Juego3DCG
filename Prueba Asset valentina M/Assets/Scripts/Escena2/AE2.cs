using System.Collections;
using UnityEngine;

/// <summary>
/// Controla la visibilidad de un panel UI con desvanecimiento,
/// reproduce un sonido opcional y lanza un temporizador tras ocultar el panel.
/// </summary>
public class AE2 : MonoBehaviour
{
    /// <summary>
    /// Referencia al <see cref="CanvasGroup"/> que se mostrará y ocultará con desvanecimiento.
    /// </summary>
    public CanvasGroup panelGroup;

    /// <summary>
    /// Fuente de audio que se reproducirá después de ocultar el panel. Opcional.
    /// </summary>
    public AudioSource audioSource;

    /// <summary>
    /// Tiempo durante el cual el panel será completamente visible (en segundos).
    /// </summary>
    public float tiempoVisible = 6f;

    /// <summary>
    /// Duración del desvanecimiento del panel (en segundos).
    /// </summary>
    public float tiempoDesvanecer = 1f;

    /// <summary>
    /// Referencia al script del temporizador que se activará una vez finalice el desvanecimiento. Opcional.
    /// </summary>
    public Temporizador temporizador;

    /// <summary>
    /// Inicia la rutina para mostrar y ocultar el panel al comenzar la escena.
    /// </summary>
    void Start()
    {
        StartCoroutine(MostrarYDesvanecer());
    }

    /// <summary>
    /// Corrutina que muestra el panel, espera un tiempo determinado, lo desvanece,
    /// reproduce un audio y luego inicia el temporizador si están definidos.
    /// </summary>
    IEnumerator MostrarYDesvanecer()
    {
        panelGroup.alpha = 1f;
        panelGroup.gameObject.SetActive(true);
        yield return new WaitForSeconds(tiempoVisible);

        float t = 0f;
        while (t < tiempoDesvanecer)
        {
            t += Time.deltaTime;
            panelGroup.alpha = 1 - (t / tiempoDesvanecer);
            yield return null;
        }

        panelGroup.alpha = 0f;
        panelGroup.gameObject.SetActive(false);

        if (audioSource != null)
        {
            audioSource.Play();
        }

        if (temporizador != null)
        {
            temporizador.IniciarTemporizador();
        }
    }
}
