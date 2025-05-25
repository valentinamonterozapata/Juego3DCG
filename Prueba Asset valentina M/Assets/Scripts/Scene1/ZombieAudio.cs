using UnityEngine;

public class ZombieAudio : MonoBehaviour
{
    public Transform player;
    private AudioSource audioSource;
    public float maxVolume = 0.8f;
    public float minVolume = 0.2f;
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

       
        float normalizedDistance = Mathf.InverseLerp(maxDistance, minDistance, distance);
        float dynamicVolume = Mathf.Lerp(minVolume, maxVolume, normalizedDistance);

        audioSource.volume = dynamicVolume;

       
        audioSource.pitch = Random.Range(0.9f, 1.1f);
    }
}