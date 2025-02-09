using UnityEngine;

public class attack : MonoBehaviour
{
    [SerializeField] move player;

    void Start()
    {
        player = GetComponent<move>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            player.anim.SetTrigger("attack");

        }
    }
}
