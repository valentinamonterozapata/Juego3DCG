// ZombieChaseSimple.cs
using UnityEngine;

public class ZombieChaseSimple : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );
        transform.LookAt(player); // Opcional: que mire al jugador
    }
}