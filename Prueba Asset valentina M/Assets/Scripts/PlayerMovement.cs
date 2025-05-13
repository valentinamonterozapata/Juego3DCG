using UnityEngine;



public class PlayerMovement : MonoBehaviour

{

    public float walkSpeed = 3f;

    public float runSpeed = 47f;

    public float jumpForce = 5f;

    public float rotationSpeed = 200f;


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


        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }



    void Update()

    {
        bool isRunning = anim.GetBool(isRunningHash);
        bool isWalking = anim.GetBool(isWalkingHash);
        bool forwadPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");


        // Movimiento básico

        float moveVertical = Input.GetAxis("Vertical");

        float moveHorizontal = Input.GetAxis("Horizontal");

        if (!isWalking && forwadPressed)
        {
            anim.SetBool(isWalkingHash, true);
        }
        if (isWalking && !forwadPressed)
        {
            anim.SetBool(isWalkingHash, false);
        }



        // Rotación

        transform.Rotate(0, moveHorizontal * rotationSpeed * Time.deltaTime, 0);



        // Verificar si está corriendo



        currentSpeed = isRunning ? runSpeed : walkSpeed;

        if (!isRunning && (forwadPressed && runPressed))
        {
            anim.SetBool(isRunningHash, true);
        }
        if (isRunning && (!forwadPressed || !runPressed))
        {
            anim.SetBool(isRunningHash, false);
        }


        // Movimiento

        if (moveVertical != 0)

        {

            transform.Translate(0, 0, moveVertical * currentSpeed * Time.deltaTime);

        }



        // Configurar parámetros de animación







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