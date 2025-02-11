using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class move : MonoBehaviour
{
    Transform Transform;
    public Animator anim;
    public bool flipRight = false;
    [Header("Jump value")]
    [SerializeField] float jumpForce = 0f;
    [SerializeField] float maxJumpForce = 10f;
    [SerializeField] float jumpAccel = 20f;
    [Header("Fall value")]
    [SerializeField] float fallForce = 0f;
    [SerializeField] float maxFallForce = -10f;
    [SerializeField] float fallAccel = -20f;
    [SerializeField] float velocity;
    [SerializeField] bool isJump = false;
    Rigidbody2D rb;
    [SerializeField] float speed = 1.5f;
    [SerializeField] float maxSpeed = 3f;
    [SerializeField] float minSpeed = 1.5f;
   
    [SerializeField] bool isGround = false;
    [SerializeField] AudioSource _audio;
    [SerializeField] TextMeshProUGUI name;
    void Start()
    {
        _audio = GetComponentInChildren<AudioSource>();
        anim = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
        name = GameObject.FindGameObjectWithTag("NamePlayer").GetComponent<TextMeshProUGUI>();
    }

   void Scale()
    {
        flipRight = !flipRight;
        Vector2 theScale = transform.localScale;
        Vector2 textScale = name.transform.localScale;
        
        theScale.x = theScale.x * -1;
        
        transform.localScale = theScale;
        textScale.x = textScale.x * -1;
        name.transform.localScale = textScale;
        
    }
    void Update()
    {
        if(velocity ==0)
        {
            _audio.loop = false;
           
        }
        velocity = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("run", true);
            speed = maxSpeed;
        }
        else
        {
            anim.SetBool("run", false);
            speed = minSpeed;
        }
        if(velocity >0 && flipRight == false)
        {
            Scale();
        }
        else if (velocity < 0 && flipRight == true)
        {
            Scale();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            isJump = true;
          
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGround == false)
        {
            anim.SetBool("jump", false);
            anim.SetBool("gllide", true);
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(velocity * speed, rb.linearVelocity.y);
        anim.SetFloat("walk", Mathf.Abs(velocity));
        if (isJump == true)
        {
            jumpForce += jumpAccel * Time.fixedDeltaTime;
            if (jumpForce >= maxJumpForce)
            {
                jumpForce = maxJumpForce;
                isJump = false;
            }
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        else if(jumpForce >= maxJumpForce)
        {
            fallForce += fallAccel * Time.fixedDeltaTime;
            if(fallForce >= maxFallForce)
            {
                fallForce = maxFallForce;
            }
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fallForce);
        }
        else
        {
            fallForce = 0;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            anim.SetBool("jump", false);
            anim.SetBool("gllide", false);
            jumpForce = 0;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
            anim.SetBool("jump", true);
            
        }
    }
}
