using UnityEngine;

public class ZombieAttackDamage2 : MonoBehaviour
{
    [Header("Parámetros de ataque")]
    public float attackRadius = 1.5f;    // radio del golpe
    public Vector3 attackOffset;         // desplazamiento de la esfera
    public float attackRate = 1.0f;    // segundos entre golpes
    public int damage = 1;      // cuánto quita por golpe
    public LayerMask playerLayer;       // capa del Player

    private float lastAttackTime = -Mathf.Infinity;

    void Update()
    {
        // ¿Ya podemos atacar otra vez?
        if (Time.time >= lastAttackTime + attackRate)
        {
            TryAttack();
        }
    }

    void TryAttack()
    {
        // Calcula posición de la esfera
        Vector3 pos = transform.position
                    + transform.forward * attackOffset.z
                    + transform.right * attackOffset.x
                    + transform.up * attackOffset.y;

        // Dispara OverlapSphere solo en la capa del Player
        Collider[] hits = Physics.OverlapSphere(pos, attackRadius, playerLayer);

        foreach (Collider c in hits)
        {
            if (c.CompareTag("Player"))
            {
                // Golpe válido
                c.GetComponent<PlayerHealth>()?.TakeDamage(damage);
                lastAttackTime = Time.time;
                break;  // un solo golpe por ciclo
            }
        }
    }

    // Gizmo para ver el radio en el Editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 pos = transform.TransformPoint(attackOffset);
        Gizmos.DrawWireSphere(pos, attackRadius);
    }
}