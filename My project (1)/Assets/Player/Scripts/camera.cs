using UnityEngine;

public class camera : MonoBehaviour
{
    Transform Player;
    [SerializeField] float speed;
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        Vector3 player = Player.position;
        player.y = transform.position.y;
        player.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, player, speed * Time.deltaTime);
    }
}
