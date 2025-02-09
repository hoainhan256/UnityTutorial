using UnityEngine;

public class state : MonoBehaviour
{
    [SerializeField] int statment = 0;
    [SerializeField] float timePatrol = 0;
    [SerializeField] bool flipRight = true;
    [SerializeField] int X;
    [SerializeField] float speed = 2;
    public int damage = 25;
    [SerializeField] float runSpeed = 30;
    [SerializeField] float PatrolSpeed = 20;
    [Range(1f, 50f)]
    [SerializeField] float timed = 5;
    [SerializeField] Transform target;
    [SerializeField] float distance = 0;
    [SerializeField] float followDis = 4f;
    [SerializeField] float AttackDis = 1;
    public GameObject vfx;
    Rigidbody2D rig;
    public Animator anim;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
        vfx = gameObject.transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        timePatrol += Time.deltaTime;
        distance = Vector2.Distance(transform.position, target.position);
        CheckState();
    }
    void CheckState()
    {
        if (distance >= AttackDis && distance <= followDis)
        {
            statment = 1;
        }
        else if ( distance < AttackDis)
        {
            statment = 2;
           
        }
        else
        {
           
            statment = 0;
        }
        if (statment !=2)
        {
            anim.SetBool("attack", false);
        }
        timePatrol += Time.deltaTime;
        if (timePatrol >= timed && statment == 0)
        {
            theScale();
        }
        if (flipRight == true)
        {
            X = 1;
        }
        else
        {
            X = -1;
        }
        if (statment == 0)
        {
            Patrol();
        }
        else if (statment == 1)
        {
            following();
        }
        else
        {
            Attack();
        }

    }

    void theScale()
    {
        timePatrol = 0;
        flipRight = !flipRight;
        Vector2 theScale = transform.localScale;
        theScale.x = theScale.x * -1;
        transform.localScale = theScale;
    }
    
    void Patrol()
    {
        rig.linearVelocity = new Vector2(X,rig.linearVelocity.y) * PatrolSpeed * Time.fixedDeltaTime;
        
    }
    void following()
    {
        transform.position = Vector2.Lerp(transform.position, target.position, runSpeed * Time.deltaTime);
        CheckDirFlip();
    }
    void Attack()
    {
        anim.SetBool("attack", true);
        CheckDirFlip();
    }
    void CheckDirFlip()
    {
        if (transform.position.x > target.position.x)
        {
            if (flipRight)
            {
                theScale();
            }
        }
        else if (transform.position.x < target.position.x)
        {
            if (!flipRight)
            {
                theScale();
            }
        }
    }
}
