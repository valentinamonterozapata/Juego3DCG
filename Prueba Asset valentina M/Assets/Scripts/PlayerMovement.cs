using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float runSpeed = 47f;
    public float jumpForce = 5f;
    public float rotationSpeed = 200f;

    int isBackwalkHash;
    int isWalkingHash;
    int isRunningHash;

    private Animator anim;
    private Rigidbody rb;
    private bool isGrounded;
    private float currentSpeed;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        isBackwalkHash = Animator.StringToHash("isBackwalk");
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    void Update()
    {
        bool isRunning = anim.GetBool(isRunningHash);
        bool isWalking = anim.GetBool(isWalkingHash);
        bool isBackwalk = anim.GetBool(isBackwalkHash);

        bool backwalkPressed = Input.GetKey("s");
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Caminata hacia adelante
        if (!isWalking && forwardPressed)
        {
            anim.SetBool(isWalkingHash, true);
        }
        if (isWalking && !forwardPressed)
        {
            anim.SetBool(isWalkingHash, false);
        }

        // Caminata hacia atrás
        if (!isBackwalk && backwalkPressed)
        {
            anim.SetBool(isBackwalkHash, true);
        }
        if (isBackwalk && !backwalkPressed)
        {
            anim.SetBool(isBackwalkHash, false);
        }

        // Rotación
        transform.Rotate(0, moveHorizontal * rotationSpeed * Time.deltaTime, 0);

        // Correr hacia adelante solamente
        if (!isRunning && (forwardPressed && runPressed))
        {
            anim.SetBool(isRunningHash, true);
        }
        if (isRunning && (!forwardPressed || !runPressed))
        {
            anim.SetBool(isRunningHash, false);
        }

        // Determinar velocidad actual
        currentSpeed = isRunning ? runSpeed : walkSpeed;

        // Movimiento
        if (moveVertical != 0)
        {
            // Evitar correr hacia atrás
            if (!(moveVertical < 0 && runPressed))
            {
                transform.Translate(0, 0, moveVertical * currentSpeed * Time.deltaTime);
            }
        }

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("Jump");
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
