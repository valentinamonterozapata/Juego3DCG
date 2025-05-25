using UnityEngine;

/// <summary>
/// Maneja el sistema de daño y detección de ataques del zombie.
/// </summary>
/// <remarks>
/// Incluye visualización de rango de ataque en el editor.
/// </remarks>
public class ZombieAttackDamage : MonoBehaviour
{
    [Header("Daño")]
    /// <summary>
    /// Daño que aplica el zombie por ataque.
    /// </summary>
    public int damage = 1;

    /// <summary>
    /// Tiempo entre ataques.
    /// </summary>
    public float attackCooldown = 2f;

    [Header("Detección")]
    /// <summary>
    /// Radio del área de ataque.
    /// </summary>
    public float attackRadius = 1.5f;

    /// <summary>
    /// Offset para ajustar la posición del ataque.
    /// </summary>
    public Vector3 attackOffset;

    private float lastAttackTime;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (anim.GetBool("isPunching") && Time.time - lastAttackTime >= attackCooldown)
        {
            Attack();
        }
    }

    /// <summary>
    /// Realiza un ataque y aplica daño al jugador si está en rango.
    /// </summary>
    void Attack()
    {
        Vector3 attackPosition = transform.position + transform.forward * attackOffset.z + transform.up * attackOffset.y;
        Collider[] hitPlayers = Physics.OverlapSphere(attackPosition, attackRadius);

        foreach (Collider player in hitPlayers)
        {
            if (player.CompareTag("Player"))
            {
                player.GetComponent<PlayerHealth>()?.TakeDamage(damage);
                lastAttackTime = Time.time;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Vector3 attackPosition = transform.position + transform.forward * attackOffset.z + transform.up * attackOffset.y;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition, attackRadius);
    }
}