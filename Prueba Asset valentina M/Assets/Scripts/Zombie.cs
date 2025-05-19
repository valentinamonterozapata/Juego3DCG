using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float attackRange = 1.5f;
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
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            // Modo ataque
            anim.SetBool("isWalking", false);
            anim.SetBool("isPunching", true);
        }
        else if (distanceToPlayer > attackRange && distanceToPlayer < chaseRange)
        {
            // Modo caminar
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
            // Modo idle
            anim.SetBool("isWalking", false);
            anim.SetBool("isPunching", false);
        }
    }
}