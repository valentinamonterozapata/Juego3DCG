using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    public int damage = 1;   // daño por golpe

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie")) // detecta zombies
        {
            ZombieHealth zh = other.GetComponent<ZombieHealth>();
            if (zh != null)
            {
                zh.TakeDamage(damage);
            }
        }
    }
}