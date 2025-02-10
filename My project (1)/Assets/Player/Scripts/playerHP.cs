using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerHP : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] int maxHp;
    [SerializeField] Slider hpBar;
    SpriteRenderer sprite;
    [SerializeField] Color hide;
    [SerializeField] Color show;
    [SerializeField] bool takeDame =false;
    [SerializeField] float timeTakeDame =3;
    [SerializeField] bool isDead = false;
    move player;
    
    void Start()
    {
        
        maxHp = 100;
        hpBar.maxValue = maxHp;
        hp = maxHp;
        sprite = GetComponent<SpriteRenderer>();
        player = GetComponent<move>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        hpBar.value = hp;
       if (timeTakeDame <= 0)
        {
            takeDame = false;
            sprite.color = show;
        }
       if (hp <=0 && isDead == false)
        {
            player.anim.SetTrigger("dead");
            isDead = true;
            GetComponent<shooting>().enabled = false;
            GetComponent<attack>().enabled = false;
            GetComponent<move>().enabled = false;
            GetComponent<Rigidbody2D>().simulated = false;
            GetComponent<Collider2D>().enabled = false;
            Invoke("RestGame", 2f);
            
        }
        
    }
    void RestGame()
    {
        SceneManager.LoadScene(1);
    }
    private void FixedUpdate()
    {
        if (takeDame)
        {
            timeTakeDame -= Time.deltaTime;
            if (sprite.color == hide)
            {
                sprite.color = show;
            }
            else
            {
                sprite.color = hide;
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemyAttack"))
        {
            hp -= collision.GetComponentInParent<state>().damage;
            takeDame = true;
            timeTakeDame = 3;
        }
    }

}
