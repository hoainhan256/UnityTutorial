using UnityEngine;
using UnityEngine.UI;

public class playerHP : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] int maxHp;
    [SerializeField] Slider hpBar;
    void Start()
    {
        maxHp = 100;
        hpBar.maxValue = maxHp;
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.value = hp;
    }

}
