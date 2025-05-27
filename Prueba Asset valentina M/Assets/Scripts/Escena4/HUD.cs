using UnityEngine;

public class HUD : MonoBehaviour
{
    [Header("Arrastra aquí tus 5 corazones en orden")]
    public GameObject[] corazones;

    /// <summary>Activa sólo los primeros 'health' corazones.</summary>
    public void UpdateHearts(int health)
    {
        for (int i = 0; i < corazones.Length; i++)
            corazones[i].SetActive(i < health);
    }
}