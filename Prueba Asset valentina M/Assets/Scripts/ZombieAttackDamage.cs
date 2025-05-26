using UnityEngine;

public class ZombieAttackDamage : MonoBehaviour
{
    [Header("Capa del Player")]
    public LayerMask playerLayerMask;

    [Header("Parámetros de ataque")]
    public float attackRadius = 1.5f;
    public Vector3 attackOffset = new Vector3(0f, 1f, 0.5f);
    public float attackCooldown = 1f;
    public int damage = 1;

    private Animator anim;
    private float lastAttackTime = -Mathf.Infinity;

    void Awake()
    {
        anim = GetComponent<Animator>();
        if (anim == null)
            Debug.LogError("Animator no encontrado en Zombie");
    }

    void Update()
    {
        // 1) Chequea si el Animator está en el estado "ZombiePunching"
        var state = anim.GetCurrentAnimatorStateInfo(0);
        if (state.IsName("ZombiePunching"))
        {
            // 2) Respeta cooldown entre golpes
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                lastAttackTime = Time.time;
                TryAttack();
            }
        }
    }

    void TryAttack()
    {
        // 3) Calcula la esfera de daño en world space
        Vector3 worldPos = transform.TransformPoint(attackOffset);

        // 4) OverlapSphere solo contra la capa del Player
        Collider[] hits = Physics.OverlapSphere(
            worldPos,
            attackRadius,
            playerLayerMask,
            QueryTriggerInteraction.Ignore
        );

        // 5) Si detecta al Player, le resta vida
        foreach (var col in hits)
        {
            if (col.CompareTag("Player"))
            {
                Debug.Log("💥 Zombie golpeó al Player");
                var ph = col.GetComponent<PlayerHealth>();
                if (ph != null) ph.takeDamage(damage);
                else Debug.LogError("PlayerHealth no encontrado en el Player");
                break; // un solo golpe por ciclo
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 worldPos = transform.TransformPoint(attackOffset);
        Gizmos.DrawWireSphere(worldPos, attackRadius);
    }
}