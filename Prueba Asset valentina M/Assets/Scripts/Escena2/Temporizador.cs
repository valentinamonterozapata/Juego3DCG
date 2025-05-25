using System.Collections;
using UnityEngine;
using TMPro;

public class Temporizador : MonoBehaviour
{
    public int tiempoInicial = 10;
    public TMP_Text textoContador;

    public CanvasGroup panelFinalGroup;
    public TMP_Text textoFinal;

    public GameObject panelZombie;

    public AudioSource musicaDelPanel1;  // Música inicial
    public AudioSource musicaDelPanel2;  // Música nueva (zombie, por ejemplo)

    public float tiempoVisible = 2f;
    public float tiempoFade = 1f;

    void Awake()
    {
        panelFinalGroup.alpha = 0f;
        panelFinalGroup.gameObject.SetActive(false);
        panelZombie.SetActive(false);
        if (musicaDelPanel2 != null)
            musicaDelPanel2.Stop(); // Asegúrate que la segunda no arranque sola
    }

    public void IniciarTemporizador()
    {
        StartCoroutine(ContarRegresivamente());
    }

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

        // Mostrar el panel final
        panelFinalGroup.alpha = 1f;
        panelFinalGroup.gameObject.SetActive(true);
        textoFinal.text = "¡tiempo terminado!\r\nel zombie entro \r\na la habitacion\r\n";

        //  Detener música del primer panel
        if (musicaDelPanel1 != null)
            musicaDelPanel1.Stop();

        //  Reproducir música nueva
        if (musicaDelPanel2 != null)
            musicaDelPanel2.Play();

        // Mostrar zombie panel
        panelZombie.SetActive(true);

        yield return new WaitForSeconds(tiempoVisible);

        // Desvanecer panel final
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