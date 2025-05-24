using UnityEngine;

public class ZombieAudio : MonoBehaviour
{
    public Transform player;
    private AudioSource audioSource;
    public float maxVolume = 0.8f; // Volumen máximo al estar cerca
    public float minVolume = 0.2f; // Volumen mínimo al estar lejos
    public float minDistance = 2f;
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

        // Calcula el volumen basado en la distancia
        float normalizedDistance = Mathf.InverseLerp(maxDistance, minDistance, distance);
        float dynamicVolume = Mathf.Lerp(minVolume, maxVolume, normalizedDistance);

        audioSource.volume = dynamicVolume;

        // Opcional: Ajusta el pitch para más realismo
        audioSource.pitch = Random.Range(0.9f, 1.1f);
    }
}