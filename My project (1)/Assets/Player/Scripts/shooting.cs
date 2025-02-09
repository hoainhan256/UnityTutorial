using UnityEngine;

public class shooting : MonoBehaviour
{
    [SerializeField]private Transform pos;
    [SerializeField] GameObject bullet;
    [SerializeField] move player;
    [SerializeField] float speed;
    void Start()
    {
        player = GetComponent<move>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            player.anim.SetTrigger("throw");
           
        }
    }
    public void Throwing()
    
    {
        if (player.flipRight == true)
        {
            GameObject bullets = Instantiate(bullet, pos.position, Quaternion.Euler(new Vector3(0, 0, -90)));
            bullets.GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed * Time.fixedDeltaTime);

        }
        else
        {
            GameObject bullets = Instantiate(bullet, pos.position, Quaternion.Euler(new Vector3(0, 0, 90)));
            bullets.GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed * Time.fixedDeltaTime);


        }
    }
}
