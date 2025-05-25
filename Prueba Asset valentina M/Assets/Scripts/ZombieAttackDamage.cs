using UnityEngine;

public class ZombieAttackDamage : MonoBehaviour
{
    [Header("Capa del Jugador (LayerMask)")]
    public LayerMask playerLayerMask;    // Marca aquí la capa “Player”

    [Header("Parámetros de ataque")]
    public float attackRadius = 1.5f;  // Radio de tu esfera de golpe
    public Vector3 attackOffset = new Vector3(0, 1, 0.5f); // Desplaza la esfera al frente y altura del torso
    public float attackCooldown = 1.0f;  // Segundos entre cada golpe
    public int damage = 1;     // Daño por golpe (1 vida)

    private float lastAttackTime = -Mathf.Infinity;

    void Update()
    {
        // Si ha pasado el cooldown, intentamos golpear
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            TryAttack();
        }
    }

    private void TryAttack()
    {
        // Calcula posición mundial de la esfera de ataque
        Vector3 worldPos = transform.TransformPoint(attackOffset);

        // Buscamos colisiones sólo en la capa del Player
        Collider[] hits = Physics.OverlapSphere(worldPos, attackRadius, playerLayerMask);
        foreach (Collider col in hits)
        {
            if (col.CompareTag("Player"))
            {
                Debug.Log("Zombie golpeó al Player");
                // Llamamos a TakeDamage(1) en su script de salud
                PlayerHealth ph = col.GetComponent<PlayerHealth>();
                if (ph != null)
                {
                    ((PlayerHealth)ph).takeDamage(damage); // Especifica explícitamente el método correcto
                }
                else
                {
                    Debug.LogWarning("PlayerHealth no encontrado en el Player");
                }
                lastAttackTime = Time.time;
                break; // un sólo golpe por ciclo
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Para visualizar el área de golpe en el editor
        Gizmos.color = Color.red;
        Vector3 worldPos = transform.TransformPoint(attackOffset);
        Gizmos.DrawWireSphere(worldPos, attackRadius);
    }
}