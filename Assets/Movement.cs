using UnityEngine;

public class Movement : MonoBehaviour
{
    CharacterController cc;
    //Rigidbody rb;
    [SerializeField] float speed = 270f;
   // [SerializeField] FloatingJoystick joystick;
    //float jumpHeight = 300f;

    Vector3 direction;
    float smooth_Time = 0.1f;
    float turnSmoothVelocity;
    Transform cam;
    [SerializeField] Animator animator;



    // [SerializeField] Transform groundCheck;
    // [SerializeField] LayerMask groundMask;
    // float groundDistance = 0.4f;
    // bool isGrounded;


    void Start()
    {
        //Cursor.visible = false;
       // Cursor.lockState = CursorLockMode.Locked;

       // rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        cam = Camera.main.transform;
       // Application.targetFrameRate = 60;
      
        //animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        //  isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

         float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
       //float horizontal = joystick.Horizontal;
       // float vertical = joystick.Vertical;

        direction = new Vector3(horizontal, 0f, vertical).normalized;
        //  Debug.Log(direction.magnitude);
    }

    public void GO()
    {
        float vertical = 1f;
        direction = new Vector3(0f, 0f, vertical).normalized;
    }

    public void STOP()
    {

        float vertical = 0f;
        direction = new Vector3(0f, 0f, vertical).normalized;

    }

    private void FixedUpdate()
    {


        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smooth_Time);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 MoveDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;

           cc.Move(MoveDir.normalized * speed * Time.deltaTime);
           // rb.velocity = (MoveDir.normalized * speed * Time.deltaTime);
            animator.SetBool("isRunning", true);

        }
        else
        {
            animator.SetBool("isRunning", false);
        }

    }

}


