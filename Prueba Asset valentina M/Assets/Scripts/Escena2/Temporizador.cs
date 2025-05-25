using System.Collections;
using UnityEngine;
using TMPro;

public class Temporizador : MonoBehaviour
{
    public int tiempoInicial = 10;
    public TMP_Text textoContador;

    public CanvasGroup panelFinalGroup;   // CanvasGroup del panel final
    public TMP_Text textoFinal;           // Texto dentro del panel final

    public float tiempoVisible = 2f;      // Tiempo que el panel queda visible
    public float tiempoFade = 1f;         // Duración del desvanecimiento

    void Awake()
    {
        // Asegura que el panel esté oculto al iniciar
        panelFinalGroup.alpha = 0f;
        panelFinalGroup.gameObject.SetActive(false);
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
        textoFinal.text = "¡tiempo termiando!\r\nel zombie entro \r\na la habitacion\r\n";

        yield return new WaitForSeconds(tiempoVisible);

        // Desvanecer el panel
        float t = 0f;
        while (t < tiempoFade)
        {
            t += Time.deltaTime;
            panelFinalGroup.alpha = Mathf.Lerp(1f, 0f, t / tiempoFade);
            yield return null;
        }

        // Ocultar completamente
        panelFinalGroup.alpha = 0f;
        panelFinalGroup.gameObject.SetActive(false);
    }
}
