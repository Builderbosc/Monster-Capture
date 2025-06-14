using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public Camera cam;
    Rigidbody rb;
    Vector2 input;

    private Trap trapSpawner;


    private float currentSpeed;

    [Tooltip("The Strength of the Player's Jump.")]
    [SerializeField] private float jumpForce = 30;
    [Tooltip("The defualt Speed of walking movement.")]
    [SerializeField] private float walkSpeed = 30;
    [Tooltip("The Speed the player moves while Sprinting (Holding Shift)")]
    [SerializeField] private float runSpeed = 60;
    [Tooltip("The Speed the player falls.")]
    [SerializeField] private float gravity = 10;
    [Tooltip("The cooldown between spawning a trap.")]
    [SerializeField] private float trapSpawnCooldown = 0.8f;

    private float currentTrapCooldown;

    bool isGrounded;



    private CapsuleCollider capCol;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trapSpawner = GetComponent<Trap>();
        capCol = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTrapCooldown  <= trapSpawnCooldown)
        {
            currentTrapCooldown += Time.deltaTime;
        }
        currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        Vector2 currentInput = new Vector2();
        currentInput.x = Input.GetAxis("Horizontal");
        currentInput.y = Input.GetAxis("Vertical");


        //Vector3 Bc movement 3D, Where as input is 2D.
        Vector3 movement = new Vector3();
        movement.x = currentInput.x * currentSpeed;
        movement.y = rb.linearVelocity.y - gravity * Time.deltaTime;
        movement.z = currentInput.y * currentSpeed;

        transform.localEulerAngles = new Vector3(0, cam.transform.localEulerAngles.y, 0);
        movement = transform.TransformDirection(movement);

        rb.linearVelocity = movement;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && currentTrapCooldown >= trapSpawnCooldown)
        {
            trapSpawner.OnAttack();
            currentTrapCooldown = 0;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Jump()
    {
        //copy the rb movement
        Vector3 jumpMovement = new Vector3();
        //replace y velocity
        jumpMovement.y = jumpForce;
        //apply movement back to rb
        rb.linearVelocity = jumpMovement;
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, capCol.height / 2f + 0.01f);
    }

    public float GetCooldownPercent()
    {
        return currentTrapCooldown / trapSpawnCooldown;
    }
}
