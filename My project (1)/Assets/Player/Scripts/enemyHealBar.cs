using UnityEngine;
using UnityEngine.UI;

public class enemyHealBar : MonoBehaviour
{
    [SerializeField] int minValue = 0;
    [SerializeField] int maxValue = 100;
    [SerializeField] int hp;
    [SerializeField] Slider slider;
    [SerializeField] bool isDead = false;
    [SerializeField] state state;
    void Start()
    {
        hp = 100;
        slider.minValue = minValue;
        slider.maxValue = maxValue;

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = hp;
        if (hp <=0 && isDead == false)
        {
            GameManager.point++;
            isDead = true;
            state.anim.SetTrigger("dead");
            slider.gameObject.SetActive(false);
            Destroy(gameObject,3);
        }
        
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            
            
                hp -= 20;
           
           
        }
    }
}
