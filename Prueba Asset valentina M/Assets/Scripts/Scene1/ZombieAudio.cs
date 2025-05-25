using UnityEngine;

/// <summary>
/// Controla el audio del zombie con volumen dinámico basado en la distancia al jugador.
/// </summary>
/// <remarks>
/// Ajusta el volumen y pitch del sonido para mayor realismo.
/// </remarks>
public class ZombieAudio : MonoBehaviour
{
    /// <summary>
    /// Referencia al transform del jugador.
    /// </summary>
    public Transform player;

    private AudioSource audioSource;

    /// <summary>
    /// Volumen máximo cuando el zombie está cerca.
    /// </summary>
    public float maxVolume = 0.8f;

    /// <summary>
    /// Volumen mínimo cuando el zombie está lejos.
    /// </summary>
    public float minVolume = 0.2f;

    /// <summary>
    /// Distancia mínima para volumen máximo.
    /// </summary>
    public float minDistance = 2f;

    /// <summary>
    /// Distancia máxima para volumen mínimo.
    /// </summary>
    public float maxDistance = 10f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.Play();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);
        float normalizedDistance = Mathf.InverseLerp(maxDistance, minDistance, distance);
        float dynamicVolume = Mathf.Lerp(minVolume, maxVolume, normalizedDistance);

        audioSource.volume = dynamicVolume;
        audioSource.pitch = Random.Range(0.9f, 1.1f);
    }
}