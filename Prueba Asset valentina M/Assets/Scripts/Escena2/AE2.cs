using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AE2 : MonoBehaviour
{

    public CanvasGroup panelGroup;
    public AudioSource audioSource;
    public float tiempoVisible = 6f;
    public float tiempoDesvanecer = 1f;

    void Start()
    {
        StartCoroutine(MostrarYDesvanecer());
    }

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
    }
}
