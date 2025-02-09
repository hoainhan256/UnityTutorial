using UnityEngine;
using UnityEngine.UI;

public class enemyHealBar : MonoBehaviour
{
    [SerializeField] int minValue = 0;
    [SerializeField] int maxValue = 100;
    [SerializeField] int hp;
    [SerializeField] Slider slider;
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
        if (hp <=0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            hp = hp -20;
        }
    }
}
