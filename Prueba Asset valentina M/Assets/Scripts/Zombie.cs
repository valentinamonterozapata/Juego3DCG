using UnityEngine;

/// <summary>
/// Controla el comportamiento básico del zombie (persecución y ataque).
/// </summary>
/// <remarks>
/// Coordina con <see cref="ZombieAttackDamage"/> para los ataques.
/// </remarks>
public class Zombie : MonoBehaviour
{
    /// <summary>
    /// Referencia al jugador.
    /// </summary>
    public Transform player;

    /// <summary>
    /// Velocidad de movimiento.
    /// </summary>
    public float speed = 3f;

    /// <summary>
    /// Rango para iniciar ataque.
    /// </summary>
    public float attackRange = 1.5f;

    /// <summary>
    /// Rango para iniciar persecución.
    /// </summary>
    public float chaseRange = 10f;

    private Animator anim;
    private Rigidbody rb;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            // Modo ataque
            anim.SetBool("isWalking", false);
            anim.SetBool("isPunching", true);
        }
        else if (distanceToPlayer > attackRange && distanceToPlayer < chaseRange)
        {
            // Modo persecución
            anim.SetBool("isWalking", true);
            anim.SetBool("isPunching", false);

            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
            );
            transform.LookAt(player);
        }
        else
        {
            // Modo inactivo
            anim.SetBool("isWalking", false);
            anim.SetBool("isPunching", false);
        }
    }
}