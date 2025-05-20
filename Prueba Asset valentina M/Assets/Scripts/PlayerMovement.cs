using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float runSpeed = 47f;
    public float jumpForce = 5f;
    public float rotationSpeed = 200f;

    int isBackwalk;
    int isWalking;
    int isRunning;

    private Animator anim;
    private Rigidbody rb;
    private bool isGrounded;
    private float currentSpeed;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        isBackwalk = Animator.StringToHash("isBackwalk");
        isWalking = Animator.StringToHash("isWalking");
        isRunning = Animator.StringToHash("isRunning");
    }

    void Update()
    {
        bool isRunning = anim.GetBool(this.isRunning);
        bool isWalking = anim.GetBool(this.isWalking);
        bool isBackwalk = anim.GetBool(this.isBackwalk);

        bool backwalkPressed = Input.GetKey("s");
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Caminata hacia adelante
        if (!isWalking && forwardPressed)
        {
            anim.SetBool(this.isWalking, true);
        }
        if (isWalking && !forwardPressed)
        {
            anim.SetBool(this.isWalking, false);
        }

        // Caminata hacia atrás
        if (!isBackwalk && backwalkPressed)
        {
            anim.SetBool(this.isBackwalk, true);
        }
        if (isBackwalk && !backwalkPressed)
        {
            anim.SetBool(this.isBackwalk, false);
        }

        // Rotación
        transform.Rotate(0, moveHorizontal * rotationSpeed * Time.deltaTime, 0);

        // Correr hacia adelante solamente
        if (!isRunning && (forwardPressed && runPressed))
        {
            anim.SetBool(this.isRunning, true);
        }
        if (isRunning && (!forwardPressed || !runPressed))
        {
            anim.SetBool(this.isRunning, false);
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
