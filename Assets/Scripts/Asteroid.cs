using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Player player;
    [SerializeField] private float _speed;

    private Rigidbody2D rb;
    private Vector2 screenBounds;

    private void Start()
    {
        player = GameObject.Find("Ship_Sprite").GetComponent<Player>();
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-_speed,0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height, Camera.main.transform.position.z));
    }

    private void Update()
    {
        if(transform.position.x < screenBounds.x)
        {
            player.RecountScore();
            Destroy(this.gameObject);
        }
        
    }
}
