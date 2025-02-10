using UnityEngine;

public class move : MonoBehaviour
{
    Transform Transform;
    public Animator anim;
    public bool flipRight = false;
    [SerializeField] float velocity;
    Rigidbody2D rb;
    [SerializeField] float speed = 1.5f;
    [SerializeField] float maxSpeed = 3f;
    [SerializeField] float minSpeed = 1.5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] bool isGround = false;
    [SerializeField] AudioSource _audio;
    void Start()
    {
        _audio = GetComponentInChildren<AudioSource>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

   void Scale()
    {
        flipRight = !flipRight;
        Vector2 theScale = transform.localScale;
        theScale.x = theScale.x * -1;
        transform.localScale = theScale;
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
            rb.AddForce(new Vector2(velocity, 1) * jumpForce * Time.fixedDeltaTime);
          
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGround == false)
        {
            anim.SetBool("jump", false);
            anim.SetBool("gllide", true);
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(velocity, 0) * speed;
        anim.SetFloat("walk", Mathf.Abs(velocity));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            anim.SetBool("jump", false);
            anim.SetBool("gllide", false);
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
