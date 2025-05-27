using System.Collections;
using UnityEngine;

public class LeonardController : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        bool isWalking = Mathf.Abs(h) > 0.1f || Mathf.Abs(v) > 0.1f;
        anim.SetBool("isWalking", isWalking);

        if (Input.GetButtonDown("Fire1"))
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Stable Sword Inward Slash"))
            {
                anim.SetTrigger("SwordAttack");
                StartCoroutine(ResetSwordAttackTrigger());
            }
        }
    }

    IEnumerator ResetSwordAttackTrigger()
    {
        yield return new WaitForSeconds(0.7f); // Ajusta al tiempo de la animación Slash
        anim.ResetTrigger("SwordAttack");
    }
}