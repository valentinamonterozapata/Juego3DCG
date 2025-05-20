using UnityEngine;

public class ZombieAttackDamage : MonoBehaviour
{
    [Header("Daño")]
    public int damage = 1;
    public float attackCooldown = 2f;

    [Header("Detección")]
    public float attackRadius = 1.5f;
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
                Debug.Log("¡Jugador golpeado!"); // Para verificar en consola
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