using System.Collections;
using UnityEngine;
using TMPro;

/// <summary>
/// Controla un temporizador regresivo que, al finalizar,
/// muestra un mensaje final, reproduce sonidos y activa elementos visuales.
/// </summary>
public class Temporizador : MonoBehaviour
{
    /// <summary>
    /// Tiempo inicial del temporizador en segundos.
    /// </summary>
    public int tiempoInicial = 10;

    /// <summary>
    /// Texto en pantalla donde se mostrará la cuenta regresiva.
    /// </summary>
    public TMP_Text textoContador;

    /// <summary>
    /// Grupo de UI que contiene el mensaje final.
    /// </summary>
    public CanvasGroup panelFinalGroup;

    /// <summary>
    /// Texto que se mostrará al finalizar el temporizador.
    /// </summary>
    public TMP_Text textoFinal;

    /// <summary>
    /// Panel o GameObject que representa la aparición del zombie.
    /// </summary>
    public GameObject panelZombie;

    /// <summary>
    /// Música que suena durante el estado inicial.
    /// </summary>
    public AudioSource musicaDelPanel1;

    /// <summary>
    /// Música que se reproduce al finalizar el temporizador (ej. música de zombie).
    /// </summary>
    public AudioSource musicaDelPanel2;

    /// <summary>
    /// Tiempo que el panel final permanecerá completamente visible antes de desvanecerse.
    /// </summary>
    public float tiempoVisible = 2f;

    /// <summary>
    /// Tiempo que tomará el desvanecimiento del panel final.
    /// </summary>
    public float tiempoFade = 1f;

    /// <summary>
    /// Inicializa el estado visual del panel y detiene la música secundaria al iniciar.
    /// </summary>
    void Awake()
    {
        panelFinalGroup.alpha = 0f;
        panelFinalGroup.gameObject.SetActive(false);
        panelZombie.SetActive(false);
        if (musicaDelPanel2 != null)
            musicaDelPanel2.Stop();
    }

    /// <summary>
    /// Inicia el temporizador regresivo.
    /// </summary>
    public void IniciarTemporizador()
    {
        StartCoroutine(ContarRegresivamente());
    }

    /// <summary>
    /// Corrutina que cuenta hacia atrás, muestra un mensaje al finalizar,
    /// detiene y reproduce música, activa el zombie y desvanece el panel.
    /// </summary>
    IEnumerator ContarRegresivamente()
    {
        int tiempoActual = tiempoInicial;

        while (tiempoActual > 0)
        {
            textoContador.text = tiempoActual.ToString();
            yield return new WaitForSeconds(1f);
            tiempoActual--;
        }

        textoContador.text = "";

        // Mostrar el panel final con el mensaje
        panelFinalGroup.alpha = 1f;
        panelFinalGroup.gameObject.SetActive(true);
        textoFinal.text = "¡tiempo terminado!\r\nel zombie entro \r\na la habitacion\r\n";

        // Detener la música del primer panel
        if (musicaDelPanel1 != null)
            musicaDelPanel1.Stop();

        // Reproducir la música nueva
        if (musicaDelPanel2 != null)
            musicaDelPanel2.Play();

        // Mostrar el panel del zombie
        panelZombie.SetActive(true);

        yield return new WaitForSeconds(tiempoVisible);

        // Desvanecer el panel final
        float t = 0f;
        while (t < tiempoFade)
        {
            t += Time.deltaTime;
            panelFinalGroup.alpha = Mathf.Lerp(1f, 0f, t / tiempoFade);
            yield return null;
        }

        panelFinalGroup.alpha = 0f;
        panelFinalGroup.gameObject.SetActive(false);
    }
}
