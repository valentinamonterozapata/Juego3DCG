using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    public LayerMask enemyLayer;        // Capa donde están los zombies
    public Transform attackPoint;       // Punto desde donde atacas (punta de espada)
    public float attackRadius = 0.5f;   // Radio de daño
    public int damage = 1;              // Daño por golpe

    // Método que se llamará en el frame de impacto (Animation Event)
    public void DealDamage()
    {
        Collider[] hits = Physics.OverlapSphere(attackPoint.position, attackRadius, enemyLayer);

        foreach (var hit in hits)
        {
            if (hit.CompareTag("Zombie"))
            {
                ZombieHealth zh = hit.GetComponent<ZombieHealth>();
                if (zh != null)
                {
                    zh.TakeDamage(damage);
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}